using PMSWin.Dao;
using PMSWin.Model;
using PMSWin.PurchasingOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMSWin.PurchasingOrder
{
    public partial class POSetQtyForm : BaseForm
    {
        public POSetQtyForm()
        {
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            panel1.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
            btnAddToPO.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            btnPickupPart.BackColor = Color.FromArgb(242, 213, 143);
            panel2.BackColor = Color.FromArgb(112, 177, 181);  //底部淺綠色
        }

        public enum CommandMode
        {
            Add, Edit, OrderEdit
        }

        public CommandMode CmdMode { get; set; }
        public string PartNumber { get; set; }
        public string Qty { get; set; }
        public int SourceListOID { get; set; }
        public int ListIndex { get; set; }
        public int SourceOrderListOID { get; set; }

        Model.Part PartData;
        List<Model.SourceList> sourceLists;
        SourceOrderList SourceOrderListData;
        OrderPart OrderPartData;

        private void POSetQtyForm_Load(object sender, EventArgs e)
        {
            //測試用
            //this.CmdMode = CommandMode.OrderEdit;
            //this.SourceOrderListOID = 1;
            Init();
        }

        void Init()
        {
            switch (this.CmdMode)
            {
                case CommandMode.Add:
                    POInit();
                    break;
                case CommandMode.Edit:
                    POInit();
                    EditInitShow();
                    break;
                case CommandMode.OrderEdit:
                    OrderInit();
                    EditInitShow();
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// 新增採購單的起始內容
        /// </summary>
        void POInit()
        {
            this.SetShowData(this.PartNumber);

            this.lblPODCount.Text = PurchasingOrderUtil.GetPurchasingOrderDetailStatus();
        }

        /// <summary>
        /// 編輯訂單時的起始內容
        /// </summary>
        void OrderInit()
        {
            SourceOrderListDao dao = new SourceOrderListDao();
            this.SourceOrderListData = dao.FindSourceOrderListBySourceOrderListOID(this.SourceOrderListOID);
            this.Qty = this.SourceOrderListData.Qty.ToString();
            this.OrderPartData = this.SourceOrderListData.GetOrderPart();

            this.SetShowData(this.OrderPartData.PartNumber);

            //TODO:未來應以SourceOrderList的新增欄位SourceListOID來判斷
            foreach (Model.SourceList sl in sourceLists)
            {
                if (sl.Discount == this.SourceOrderListData.Discount && sl.Batch == this.SourceOrderListData.Batch)
                {
                    this.SourceListOID = sl.SourceListOID;
                    this.cbSourceList.SelectedValue = this.SourceListOID;
                }
            }
            this.lblNavText.Text = "編輯訂單 > 設定貨源清單及採購數量";
            this.btnPickupPart.Hide();
            this.lblPODCount.Hide();
        }

        void SetShowData(string pn)
        {
            //string partNumber = Convert.ToString(Util.GetSessionValueThenRemove("PartNumber"));
            PartDao pDao = new PartDao();
            this.PartData = pDao.FindPartByPartNumber(pn);
            this.lblPartNumber.Text = PartData.PartNumber;
            this.lblPartName.Text = PartData.PartName;
            this.lblPartSpec.Text = PartData.PartSpec;
            this.lblUnitPrice.Text = PartData.UnitPrice.ToString();
            this.lblSupplierName.Text = PartData.GetSupplierInfo().SupplierName;
            SourceListDao slDao = new SourceListDao();
            this.sourceLists = slDao.FindSourceListByPartNumber(PartData.PartNumber);
            var q = from sl in sourceLists
                    select new { Value = sl.SourceListOID, Display = $"批量：{sl.Batch,4} - 折扣：{Math.Round(sl.Discount * 10, 1)}折  - 單價：{Math.Round(PartData.UnitPrice.Value * sl.Batch * sl.Discount, 0)}" };
            this.cbSourceList.DataSource = q.ToList();
            this.cbSourceList.DisplayMember = "Display";
            this.cbSourceList.ValueMember = "Value";
        }

        /// <summary>
        /// 更新編輯模式的顯示內容
        /// </summary>
        void EditInitShow()
        {
            this.txtQty.Text = this.Qty;
            this.cbSourceList.SelectedValue = this.SourceListOID;
            this.btnAddToPO.Text = "更新";
        }

        private void btnPickupPart_Click(object sender, EventArgs e)
        {
            POPickupPartForm frm = new POPickupPartForm();
            Common.ContainerForm.NextForm(frm);
        }

        private void btnAddToPO_Click(object sender, EventArgs e)
        {
            int qty = 0;
            if (!int.TryParse(txtQty.Text.Trim(), out qty))
            {
                MessageBox.Show("請輸入正確數字");
                return;
            }
            switch (this.CmdMode)
            {
                case CommandMode.Add:
                    PurchasingOrderDetail pod = new PurchasingOrderDetail()
                    {
                        SourceListOID = Convert.ToInt32(this.cbSourceList.SelectedValue),
                        Qty = qty
                    };
                    PurchasingOrderUtil.SetPurchasingOrderDetail(pod);
                    this.lblPODCount.Text = PurchasingOrderUtil.GetPurchasingOrderDetailStatus();
                    break;
                case CommandMode.Edit:
                    PurchasingOrderDetail updatePod = PurchasingOrderUtil.GetPurchasingOrderDetail()[this.ListIndex];
                    updatePod.SourceListOID = Convert.ToInt32(this.cbSourceList.SelectedValue);
                    updatePod.Qty = qty;
                    Common.ContainerForm.NextForm(new POAddMainForm());
                    break;
                case CommandMode.OrderEdit:
                    Model.SourceList sl = this.sourceLists.Find(s => s.SourceListOID.Equals(Convert.ToInt32(this.cbSourceList.SelectedValue)));

                    this.SourceOrderListData.Batch = sl.Batch;
                    this.SourceOrderListData.Discount = sl.Discount;
                    this.SourceOrderListData.Qty = Convert.ToInt32(this.txtQty.Text);

                    SourceOrderListDao dao = new SourceOrderListDao();
                    dao.Update(this.SourceOrderListData);

                    CheckOrderForm cof = new CheckOrderForm(this.SourceOrderListData.GetOrderPart().OrderID, "edit");
                    Common.ContainerForm.NextForm(cof);
                    break;
                default:
                    break;
            }

        }

        private void lblPODCount_Click(object sender, EventArgs e)
        {
            Common.ContainerForm.NextForm(new POAddMainForm());
        }

    }
}

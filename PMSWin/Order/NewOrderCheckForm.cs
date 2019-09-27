using PMSWin.Dao;
using PMSWin.DataSource;
using PMSWin.Model;
using PMSWin.PurchasingOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMSWin
{
    public partial class NewOrderCheckForm : BaseForm
    {
        public NewOrderCheckForm()
        {
            InitializeComponent();
            //if (this.PurchasingOrderID != null && this.PurchasingOrderDetailListOID != null)
            //{
            //    showData();
            //}

        }

        public string PurchasingOrderID { get; set; }
        public List<int> PodOIDList { get; set; }
        DataTable PodData;
        decimal Total;
        string SupplierCode;

        void Init()
        {
            OrderDao dao = new OrderDao();
            this.PodData = dao.FindPurchasingOrderDetail(this.PurchasingOrderID, PodOIDList);
            this.dataGridView1.DataSource = this.PodData;
            if (this.PodData.Rows.Count > 0)
            {
                //隱藏欄位 si.SupplierCode, PartSpec, PartUnitName, Discount
                int colIndex = this.dataGridView1.GetColumnIndex("SupplierCode");
                this.dataGridView1.Columns[colIndex].Visible = false;
                //取得供應商代碼
                this.SupplierCode = this.dataGridView1.Rows[0].Cells[colIndex].Value.ToString();
                colIndex = this.dataGridView1.GetColumnIndex("PartSpec");
                this.dataGridView1.Columns[colIndex].Visible = false;
                colIndex = this.dataGridView1.GetColumnIndex("PartUnitName");
                this.dataGridView1.Columns[colIndex].Visible = false;
                colIndex = this.dataGridView1.GetColumnIndex("Discount");
                this.dataGridView1.Columns[colIndex].Visible = false;
            }

            foreach (DataRow dr in this.PodData.Rows)
            {
                this.Total += Convert.ToDecimal(dr["小計"].ToString());
            }
            this.lblTotal.Text = this.Total.ToString();
        }

        private void NewOrderCheckForm_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dtpDateRequired.Value < DateTime.Now)
            {
                MessageBox.Show("請輸入大於本日的日期");
                return;
            }

            if (MessageBox.Show("您確定要將訂單送出嗎?\n確認無誤後，系統會產生訂單編號，請填寫收貨人資訊", "訂單確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Order
                OrderDao dao = new OrderDao();
                Model.Order o = new Model.Order();
                o.PurchasingOrderID = PurchasingOrderID;
                o.SupplierCode = this.SupplierCode;
                SupplierAccountDao saDao = new SupplierAccountDao();
                o.SupplierAccountID = saDao.FindSupplierAccountBySupplierCode(o.SupplierCode).SupplierAccountID;
                o.EmployeeID = Common.ContainerForm.BuyerLoginAccount.EmployeeID;
                o.DateRequired = this.dtpDateRequired.Value;

                //OrderChanged
                Model.OrderChanged oc = new Model.OrderChanged();
                oc.OrderChangedCategoryCode = "N";
                oc.RequestDate = DateTime.Now;
                oc.RequesterRole = "P";
                oc.RequesterID = o.EmployeeID;

                //OrderPartList
                List<Model.OrderPart> opList = new List<Model.OrderPart>();
                foreach (DataRow dr in this.PodData.Rows)
                {
                    Model.OrderPart op = new Model.OrderPart();
                    op.PartNumber = dr["料件編號"].ToString();
                    op.PartName = dr["料件品名"].ToString();
                    op.PartSpec = dr["PartSpec"].ToString();
                    op.PartUnitName = dr["PartUnitName"].ToString();
                    op.UnitPrice = Convert.ToInt32(dr["批量單價"]);
                    opList.Add(op);
                }

                //SourceOrderList
                List<Model.SourceOrderList> soList = new List<Model.SourceOrderList>();
                foreach (DataRow dr in this.PodData.Rows)
                {
                    Model.SourceOrderList sol = new Model.SourceOrderList();
                    sol.Batch = Convert.ToInt32(dr["批量"]);
                    sol.Discount = Convert.ToDecimal(dr["Discount"]);
                    sol.Qty = Convert.ToInt32(dr["採購數量"]);
                    sol.PurchasingOrderDetailListOID = Convert.ToInt32(dr["採購單明細識別碼"]);
                    soList.Add(sol);
                }

                string OrderID = dao.InsertNewOrder(o, oc, opList, soList);

                if (string.IsNullOrEmpty(OrderID))
                {
                    MessageBox.Show("訂單新增失敗");
                    return;
                }

                SendOrderForm frm = new SendOrderForm(OrderID);
                Common.ContainerForm.NextForm(frm);
            }
        }

        //PurchasingOrderDao purchasingOrderDao = new PurchasingOrderDao();
        //PurchasingOrderDetailDao PurchasingOrderDetailDao = new PurchasingOrderDetailDao();
        //OrderDao OrderDao = new OrderDao();
        //DataTable purchasingdatatable;
        //public string PurchasingOrderID { get; set; }
        //public List<string> PurchasingOrderDetailListOID { get; set; }


        //public void showData()
        //{
        //    purchasingdatatable = PurchasingOrderDetailDao.GetPurchasingOrderDetailByPurchasingOrderID(this.PurchasingOrderID);

        //    //if (OrderDao.catchThePurchasingOrderDetailListOIDAndCreateTable(this.PurchasingOrderDetailListOID) != null)
        //    //{
        //    //    this.dataGridView1.DataSource = OrderDao.catchThePurchasingOrderDetailListOIDAndCreateTable(this.PurchasingOrderDetailListOID);
        //    //}
        //    //else
        //    //{
        //    //    MessageBox.Show("沒有資料");
        //    //}
        //}

        //public void showData2()
        //{
        //    string strcmd = @"   select　[PurchasingOrderDetailListOID],sl.[PartNumber],[PartName],[SupplierName],[Batch],[UnitPrice]*[Discount]as　BatchUnitprice,[Qty],([UnitPrice]*[Discount])*Qty　as total
        //                         from [dbo].[PurchasingOrderDetail]pod
        //                         join [dbo].[SourceList]sl
        //                         on pod.SourceListOID=sl.SourceListOID
        //                         join [dbo].[Part]p
        //                         on sl.PartNumber=p.PartNumber 
        //                         join [dbo].[SupplierInfo] si 
        //                         on p.SupplierCode=si.SupplierCode 
        //                         where  PurchasingOrderDetailListOID = @PurchasingOrderDetailListOID";
        //    List<SqlParameter> sqls = new List<SqlParameter>();
        //    sqls.Add(SqlHelper.CreateParameter("@PurchasingOrderDetailListOID", SqlDbType.Int, PurchasingOrderDetailListOID));
        //    DataTable dt = SqlHelper.AdapterFill(strcmd, sqls);
        //    DataRow dr = dt.Rows[0];
        //    ///////////////////////////////  寫到這裡，來去睡了20190920  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //    DataTable dataTable = new DataTable();
        //    if (PurchasingOrderDetailListOID.Count > 0)
        //    {
        //        for (int i = 0; i < PurchasingOrderDetailListOID.Count; i++)
        //        {
        //            dataTable.Rows.Add(dr);
        //        }

        //    }
        //}
        //private void button1_Click(object sender, EventArgs e)
        //{

        //}

        //private void NewOrderCheckForm_Shown(object sender, EventArgs e)
        //{
        //    if (this.PurchasingOrderID != null && this.PurchasingOrderDetailListOID != null)
        //    {
        //        showData();
        //    }
        //}

        //private void NewOrderCheckForm_Paint(object sender, PaintEventArgs e)
        //{
        //    if (this.PurchasingOrderID != null && this.PurchasingOrderDetailListOID != null)
        //    {
        //        showData();
        //    }
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    if (this.PurchasingOrderID != null && this.PurchasingOrderDetailListOID != null)
        //    {
        //        showData();
        //    }
        //}
    }
}

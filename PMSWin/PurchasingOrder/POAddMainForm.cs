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
    public partial class POAddMainForm : BaseForm
    {
        public POAddMainForm()
        {
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            panel1.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
            btnPickupPart.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            btnSendPO.BackColor = Color.FromArgb(242, 213, 143);
            Init();
        }
        BindingSource POD = new BindingSource();
        void Init()
        {
            this.lblPODCount.Text = PurchasingOrderUtil.GetPurchasingOrderDetailStatus();

            decimal total = 0.0M;

            SourceListDao slDao = new SourceListDao();
            List<Model.PurchasingOrderDetail> pods = PurchasingOrderUtil.GetPurchasingOrderDetail();

            var q = from s in pods
                    select s.SourceListOID;

            DataTable dt = new DataTable();
            object resultObj = null;
            if (!(pods == null || pods.Count == 0))
            {
                dt = slDao.FineSourceListForPOAddMain(q.ToList());

                dt.PrimaryKey = new DataColumn[] { dt.Columns["SourceListOID"] };
                var qs = from pod in pods
                         select new
                         {
                             料件編號 = GetDTValue(dt, "料件編號", pod.SourceListOID),
                             料件品名 = GetDTValue(dt, "料件品名", pod.SourceListOID),
                             供應商名稱 = GetDTValue(dt, "供應商名稱", pod.SourceListOID),
                             批量 = GetDTValue(dt, "批量", pod.SourceListOID),
                             批量單價 = $"{Convert.ToDecimal(GetDTValue(dt, "批量單價", pod.SourceListOID)):#.#}",
                             採購數量 = $"{pod.Qty:#.#}",
                             小計 = (Convert.ToDecimal(GetDTValue(dt, "批量單價", pod.SourceListOID)) * pod.Qty).ToString("#.#"),
                             pod.SourceListOID
                         };
                var result = qs.ToList();

                foreach (var item in result)
                {
                    total += Convert.ToDecimal(item.小計);
                }
                resultObj = result;
            }

            this.lblTotal.Text = $"採購單金額總計：{total:0.#}";

            this.dataGridView1.Columns.Clear();
            if (resultObj != null)
            {
                this.DataGridViewAddButton();
            }
            this.POD.DataSource = resultObj;
            this.dataGridView1.DataSource = this.POD;
            if (resultObj != null)
            {
                this.dataGridView1.Columns[this.dataGridView1.GetColumnIndex("SourceListOID")].Visible = false;
            }
            this.btnSendPO.Enabled = !(PurchasingOrderUtil.GetPurchasingOrderDetailCount() == 0);
        }

        void DataGridViewAddButton()
        {
            {
                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
                btnEdit.HeaderText = "動作";
                btnEdit.Text = "編輯";
                btnEdit.Name = "btnEdit";
                btnEdit.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Insert(0, btnEdit);

                DataGridViewButtonColumn btnDel = new DataGridViewButtonColumn();
                btnDel.HeaderText = "動作";
                btnDel.Text = "刪除";
                btnDel.Name = "btnDel";
                btnDel.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Insert(1, btnDel);
            }
        }

        string GetDTValue(DataTable dt, string colName, object key)
        {
            DataRow dr = dt.Rows.Find(key);
            return dr[colName].ToString();
        }

        private void btnPickupPart_Click(object sender, EventArgs e)
        {
            Common.ContainerForm.NextForm(new POPickupPartForm());
        }

        private void btnSendPO_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您確定要新增此筆採購單嗎?", "確認新增", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PurchasingOrderDao dao = new PurchasingOrderDao();
                dao.InsertPurchasingOrderAndDetail(Common.ContainerForm.BuyerLoginAccount.EmployeeID, PurchasingOrderUtil.GetPurchasingOrderDetail());
                MessageBox.Show("新增採購單成功");
                List<Model.PurchasingOrderDetail> details = PurchasingOrderUtil.GetPurchasingOrderDetail();
                details.Clear();
                Common.ContainerForm.NextForm(new PurchasingOrderForm());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                //編輯
                //DataGridViewButtonCell clickedButtonCell = (DataGridViewButtonCell)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                int colIndex = this.dataGridView1.GetColumnIndex("料件編號");
                string pn = dataGridView1.Rows[e.RowIndex].Cells[colIndex].Value.ToString();
                colIndex = this.dataGridView1.GetColumnIndex("採購數量");
                string qty = dataGridView1.Rows[e.RowIndex].Cells[colIndex].Value.ToString();
                colIndex = this.dataGridView1.GetColumnIndex("SourceListOID");
                int sl = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[colIndex].Value);
                POSetQtyForm frm = new POSetQtyForm
                {
                    CmdMode = POSetQtyForm.CommandMode.Edit,
                    PartNumber = pn,
                    Qty = qty,
                    SourceListOID = sl,
                    ListIndex = e.RowIndex
                };
                Common.ContainerForm.NextForm(frm);
            }
            else if (e.ColumnIndex == 1)
            {
                //刪除
                PurchasingOrderUtil.GetPurchasingOrderDetail().RemoveAt(e.RowIndex);
                this.Init();
            }
        }
    }
}

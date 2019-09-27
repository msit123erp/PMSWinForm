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
    public partial class POPickupPartForm : BaseForm
    {
        public POPickupPartForm()
        {
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            panel1.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
            btnSearch.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
          
            this.lblPODCount.Text = PurchasingOrderUtil.GetPurchasingOrderDetailStatus();
        }

        private void POPickupPartForm_Load(object sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Columns.Clear();

            PartDao dao = new PartDao();
            DataTable dt = dao.FindPartForPickup(this.txtPartNumber.Text.Trim(), this.txtPartName.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                DataGridViewButtonColumn btnPickup = new DataGridViewButtonColumn();
                btnPickup.HeaderText = "動作";
                btnPickup.Text = "選取";
                btnPickup.Name = "btnPickup";
                btnPickup.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Insert(0, btnPickup);
            }
            else
            {
                MessageBox.Show("查詢無資料");
            }
            this.dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 || e.RowIndex == -1)
            {
                return;
            }
            int colIndex = this.dataGridView1.GetColumnIndex("料件編號");
            string partNumber = this.dataGridView1.Rows[e.RowIndex].Cells[colIndex].Value.ToString();
            //Util.SetSessionValue("PartNumber", partNumber);
            POSetQtyForm frm = new POSetQtyForm();
            frm.CmdMode = POSetQtyForm.CommandMode.Add;
            frm.PartNumber = partNumber;
            Common.ContainerForm.NextForm(frm);
        }

        private void lblPODCount_Click(object sender, EventArgs e)
        {
            Common.ContainerForm.NextForm(new POAddMainForm());
        }


    }
}

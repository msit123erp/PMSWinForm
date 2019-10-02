using PMSWin.PurchasingOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PMSWin
{
    public partial class PurchasingOrderForm : BaseForm
    {
        public PurchasingOrderForm()
        {
            //2019.10.02 GitHub Testing Commit
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            panel1.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
            btnAdd.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            btnSearch.BackColor = Color.FromArgb(242, 213, 143);
            panel2.BackColor = Color.FromArgb(42, 73, 93);
            panel3.BackColor = Color.FromArgb(42, 73, 93);
        }

        private void PurchasingOrderForm_Load(object sender, EventArgs e)
        {
            DateTime? dt = null;
            SetDataSource("", dt, dt);
            SetDataGridView();
        }

        DataTable dtSource;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetDataSource(this.txtPurchasingOrderID.Text.Trim(), this.dtpBegin.Value, this.dtpEnd.Value);
            SetDataGridView();
        }

        void SetDataSource(string id, DateTime? beginDate, DateTime? endDate)
        {
            PurchasingOrderDao dao = new PurchasingOrderDao();
            dtSource = dao.FindPurchasingOrder(id, beginDate, endDate, Common.ContainerForm.BuyerLoginAccount.EmployeeID);
        }

        void SetDataGridView()
        {
            this.dataGridView1.Columns.Clear();

            if (dtSource == null || dtSource.Rows.Count == 0)
            {
                MessageBox.Show("查詢無資料");
            }
            else
            {
                //DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
                //btnEdit.HeaderText = "動作";
                //btnEdit.Text = "編輯";
                //btnEdit.Name = "btnEdit";
                //btnEdit.UseColumnTextForButtonValue = true;
                //dataGridView1.Columns.Insert(0, btnEdit);

                //DataGridViewButtonColumn btnView = new DataGridViewButtonColumn();
                //btnView.HeaderText = "動作";
                //btnView.Text = "檢視";
                //btnView.Name = "btnView";
                //btnView.UseColumnTextForButtonValue = true;
                //dataGridView1.Columns.Insert(1, btnView);
            }
            this.dataGridView1.DataSource = dtSource;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PurchasingOrderUtil.InitPurchasingOrderDetail();
            Common.ContainerForm.NextForm(new POAddMainForm());
        }


    }
}

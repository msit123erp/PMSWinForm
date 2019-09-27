using PMSWin.Dao;
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
    public partial class NewOrderForm : BaseForm
    {
        /////////////////////////////////////////////////////////////////////////呈穎0
        public NewOrderForm()
        {
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            panel1.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
            btnOrderQuery.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            panel2.BackColor = Color.FromArgb(112, 177, 181); //底部淺綠色
            //判斷操作角色為何
            if (Common.ContainerForm.BuyerLoginAccount != null)
            {
                this.buyerLoginAccount = Common.ContainerForm.BuyerLoginAccount;
                purchasingOrderDatatable = this.po.GetPurchasingOrderByEmployeeID(this.buyerLoginAccount.EmployeeID);
                labelRole.Text = $"採購員：{ this.buyerLoginAccount.GetEmployee().Name}";
            }
            else if (Common.ContainerForm.SupplierLoginAccount != null)
            {
                this.SupplierLoginAccount = Common.ContainerForm.SupplierLoginAccount;
                labelRole.Text = $"供應商：{this.SupplierLoginAccount.ContactName}";
            }
            if (purchasingOrderDatatable == null)
            {
                MessageBox.Show("查無採購單，請新增採購單再新增訂單");
                Common.ContainerForm.NextForm(new OrderForm());
                return;
            }

            for (int i = 0; i < purchasingOrderDatatable.Rows.Count; i++)
            {
                comboBox1.Items.Add(purchasingOrderDatatable.Rows[i][1].ToString());
            }
        }

        DataTable buyerDatatable = new DataTable();
        DataTable purchasingOrderDatatable = new DataTable();
        PurchasingOrderDao po = new PurchasingOrderDao();
        PurchasingOrderDetailDao pod = new PurchasingOrderDetailDao();
        /////////////////////////////////////////////////////////////////////////呈穎1
        public Buyer buyerLoginAccount { get; set; }
        public Model.SupplierAccount SupplierLoginAccount { get; set; }
        /// ///////////////////////////////////////////////////////////////呈穎0
        List<int> PurchasingOrderDetailListOID;
        private void btnOrderQuery_Click(object sender, EventArgs e)
        {
            string PurchasingOrderID = comboBox1.Text;
            List<string> sup = new List<string>();
            this.PurchasingOrderDetailListOID = new List<int>();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value == null || (bool)dataGridView1.Rows[i].Cells[0].Value == false)
                {
                }
                else
                {
                    sup.Add(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    PurchasingOrderDetailListOID.Add(Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value));
                }
            }

            for (int j = 0; j < sup.Count; j++)
            {
                for (int k = 0; k < j; k++)
                {
                    if (sup[k] != sup[j])
                    {
                        MessageBox.Show("請選擇同一個供應商");
                        return;
                    }
                }
            }

            if (this.PurchasingOrderDetailListOID.Count == 0)
            {
                MessageBox.Show("請至少選擇一筆料件");
                return;
            }

            NewOrderCheckForm frm = new NewOrderCheckForm()
            {
                PodOIDList = this.PurchasingOrderDetailListOID,
                PurchasingOrderID = PurchasingOrderID
            };
            Common.ContainerForm.NextForm(frm);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                return;
            }
            buyerDatatable = pod.GetPurchasingOrderDetailByPurchasingOrderID(comboBox1.Text);
            if (buyerDatatable == null)
            {
                MessageBox.Show("您還沒有新增採購明細唷!");
            }
            else
            {
                AddButton();
                dataGridView1.DataSource = buyerDatatable;
            }

        }
        public void AddButton()//新增按鈕欄位
        {

            DataGridViewCheckBoxColumn chb1 = new DataGridViewCheckBoxColumn();
            chb1.Name = "Btn2";
            chb1.HeaderText = "動作";
            dataGridView1.Columns.Add(chb1);

        }

    }
}

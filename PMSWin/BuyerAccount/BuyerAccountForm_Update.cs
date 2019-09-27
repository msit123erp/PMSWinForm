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

namespace PMSWin.BuyerAccount
{
    public partial class BuyerAccountForm_Update : BaseForm
    {
        public BuyerAccountForm_Update()
        {
            InitializeComponent();
            getBuyerData();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);
            panel1.BackColor = Color.FromArgb(250, 236, 209);
            panel2.BackColor = Color.FromArgb(112, 177, 181);
            btnInsert_Confirm.BackColor = Color.FromArgb(242, 213, 143);
        }

        /// <summary>
        /// 在 BuyerAccountForm.cs 按 datagridview1 的 row 就會取得 EmployeeID
        /// </summary>
        public static string CellEmpID;

        private void btnInsert_Confirm_Click(object sender, EventArgs e)
        {
            string myAccountStatus;
            if (this.radioBtn_E.Checked)
            {
                myAccountStatus = "E";
                if(PurchasingOrder.BuyerDao.updateBuyerAccountStatus(myAccountStatus))
                {
                    MessageBox.Show("啟用帳號，修改成功!");
                };
            }
            else if (this.radioBtn_D.Checked)
            {
                myAccountStatus = "D";
                if (PurchasingOrder.BuyerDao.updateBuyerAccountStatus(myAccountStatus))
                {
                    MessageBox.Show("停用帳號，修改成功!");
                };
            }
            Common.ContainerForm.NextForm(new BuyerAccountForm());
        }

        private void getBuyerData()
        {
            PurchasingOrder.BuyerDao.SearchBuyerAccount(CellEmpID, out string AccountStatus, out string Name, out string Email, out string Mobile, out string Tel);
            this.lblEmployeeID_data.Text = CellEmpID;
            this.lblName.Text = Convert.ToString(Name);
            this.lblEmail.Text = Convert.ToString(Email);
            this.lblMobi.Text = Convert.ToString(Mobile);
            this.lblTel.Text = Convert.ToString(Tel);
            if (AccountStatus == "E")
            {
                this.radioBtn_E.Checked = true;
            }
            else if (AccountStatus == "D")
            {
                this.radioBtn_D.Checked = true;
            }
            else
            {
                this.radioBtn_R.Checked = true;
            }
        }
    }
}
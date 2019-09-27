using PMSWin.Login;
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
    public partial class BuyerPersonAccountForm_Insert : BaseForm
    {
        private string accStatus = "E";

        public BuyerPersonAccountForm_Insert()
        {
            InitializeComponent();
            PurchasingOrder.BuyerDao.getAutoCompleteOfEmpIDnotInBuyer(txtEmpID);
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);
            btnInsert_Confirm.BackColor = Color.FromArgb(242, 213, 143);
            panel1.BackColor = Color.FromArgb(250, 236, 209);
            panel2.BackColor = Color.FromArgb(112,177,181);
        }

        //1. 新增到 Buyer 資料表
        async private void btnInsert_Confirm_Click(object sender, EventArgs e)
        {
            //TODO salt和pwd
            //string salt = Convert.ToString(Guid.NewGuid());
            //string password = Util.BuildAuthToken();
            //string hashPassword = Util.GetHash(password + salt.ToString());
            string bSendLetterState = "N";
            string BSendLetterState = "S";
            try
            {
                //Insert
                string typeIntxtEmpID = txtEmpID.Text;
                string modifiedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                //TODO 非同步寄信狀態
                //非同步
                string bSendLetterDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                bSendLetterState = BSendLetterState;
                string password = "";
                PurchasingOrder.BuyerDao.insertEmpToBuyer(typeIntxtEmpID, accStatus, modifiedDate, bSendLetterState, bSendLetterDate, ref password);
                Common.ContainerForm.NextForm(new BuyerAccountForm());
                bool mailResult = false;
                await Task.Run(() =>
                {
                    mailResult = CreateBuyerService.SendEmailToEmp(password, "kiwijang5473@gmail.com", out BSendLetterState);
                    PurchasingOrder.BuyerDao.updateBuyerBsendLetterStatus(typeIntxtEmpID, "Y");
                });
                if (mailResult)
                {
                    MessageBox.Show("發送密碼成功！");
                }
                else {
                    MessageBox.Show("發送密碼失敗！");
                }
            }
            catch (Exception)
            {
                this.txtEmpID.Select();
                this.txtEmpID.Text = "";
                MessageBox.Show("新增失敗!此帳號已存在或有誤!", "失敗", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            MessageBox.Show("新增成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void txtEmpID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PurchasingOrder.BuyerDao.SearchEmployee(txtEmpID.Text, out string DBEmpID, out string DBName, out string DBEmail, out string DBMobile, out string DBTel);
                this.lblEmployeeID_data.Text = Convert.ToString(DBEmpID);
                this.lblName.Text = Convert.ToString(DBName);
                this.lblEmail.Text = Convert.ToString(DBEmail);
                this.lblMobi.Text = Convert.ToString(DBMobile);
                this.lblTel.Text = Convert.ToString(DBTel);
            }
            catch (Exception)
            {
            }
        }

        // 抓 accStatus 啟用狀態的值
        private void radioBtn_D_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioBtn_E.Checked)
            {
                accStatus = "E";
            }
            else
            {
                accStatus = "D";
            }
        }
    }
}
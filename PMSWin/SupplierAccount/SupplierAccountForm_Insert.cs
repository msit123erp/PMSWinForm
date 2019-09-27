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

namespace PMSWin.SupplierAccount
{
    public partial class SupplierAccountForm_Insert : BaseForm
    {
        private string accStatus = "E";
        private string comboboxSupCode;
        private string loginBuyerID = Common.ContainerForm.BuyerLoginAccount.EmployeeID;

        public SupplierAccountForm_Insert()
        {
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            panel1.BackColor = Color.FromArgb(42, 73, 93);
            panel2.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
            btnInsert_Confirm.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            panel3.BackColor = Color.FromArgb(112, 177, 181);  //底部淺綠色
            // 繫結資料到 combobox 上
            this.comboBox1.DataSource = PurchasingOrder.SupplierAccountDao.getSupNameAndSupCode();

            //autocomplete 會有選擇事件觸發的問題所以不採用
            //Dao.SupplierAccountDao.getAutoCompleteSupNameAndSupCode(this.comboBox1);

            //取得 combobox 裡供應商的 comboboxSupCode
            string[] strArr = this.comboBox1.Text.Split('(');
            //TODO
            comboboxSupCode = string.Join(" ", strArr[1].Split(')')).Trim();
        }

        async private void btnInsert_Confirm_Click(object sender, EventArgs e)
        {
            //TODO salt和pwd
            string salt = Convert.ToString(Guid.NewGuid());
            string password = Util.BuildAuthToken();
            string hashPassword = Util.GetHash(password + salt.ToString());
            //新增前，帳號狀態N
            string saSendLetterState = "N";
            //新增後，帳號狀態S
            string SASendLetterState = "S";
            try
            {
                //Insert
                string modifiedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                ////非同步
                string saSendLetterDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                //新增後，帳號狀態S
                saSendLetterState = SASendLetterState;
                string passowrd = "";
                int r = PurchasingOrder.SupplierAccountDao.insertDataToSupAcc(this.txtSupContactName.Text, this.txtSupCEmail.Text, this.txtCMobi.Text, this.txtCTel.Text, accStatus, loginBuyerID, modifiedDate, saSendLetterState, saSendLetterDate, comboboxSupCode, ref passowrd);
                if (r == 1)
                {
                    MessageBox.Show("新增成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                Common.ContainerForm.NextForm(new SupplierAccountForm());

                bool mailResult = false;
                await Task.Run(() =>
                {
                    mailResult =  CreateSupplierService.SendEmailToSup(passowrd, "kiwijang5473@gmail.com", out SASendLetterState);
                    PurchasingOrder.SupplierAccountDao.updateSupSAsendLetterStatus(comboboxSupCode, "Y");
                });
                if (mailResult)
                {
                    MessageBox.Show("郵件寄送成功！");
                }
                else
                {
                    MessageBox.Show("郵件寄送失敗！");
                }

            }
            catch (Exception ex)
            {
                //this.txtEmpID.Select();
                //this.txtEmpID.Text = "";
                MessageBox.Show("新增失敗! "+ ex.ToString(), "失敗", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            //取得供應商的 comboboxSupCode
            string[] strArr = this.comboBox1.Text.Split('(');
            comboboxSupCode = string.Join(" ", strArr[1].Split(')')).Trim();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
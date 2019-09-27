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
    public partial class SupplierAccountForm_Update : BaseForm
    {
        public SupplierAccountForm_Update()
        {
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
        
            panel6.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
            btnUpdate_Confirm.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            panel5.BackColor = Color.FromArgb(112, 177, 181);  //底部淺綠色
            getSupAccData();
            this.pbInfo.Image = Image.FromFile("..\\..\\images\\personIfo.png");
            this.pbSend.Image = Image.FromFile("..\\..\\images\\send.png");
            this.pbSetting.Image = Image.FromFile("..\\..\\images\\setting.png");
        }

        private string SupAccID = SupplierAccountForm.CellSupAccID;
        private string AccountStatus;

        private void btnUpdate_Confirm_Click(object sender, EventArgs e)
        {
            if (this.radioBtn_E.Checked)
            {
                AccountStatus = "E";
                if (PurchasingOrder.SupplierAccountDao.updateSupAccountStatus(AccountStatus))
                {
                    MessageBox.Show("啟用帳號，修改成功!");
                };
            }
            else if (this.radioBtn_D.Checked)
            {
                AccountStatus = "D";
                if (PurchasingOrder.SupplierAccountDao.updateSupAccountStatus(AccountStatus))
                {
                    MessageBox.Show("停用帳號，修改成功!");
                };
            }
            Common.ContainerForm.NextForm(new SupplierAccountForm());
        }

        private void getSupAccData()
        {
            string strCmd = @"select [SupplierName],sa.[SupplierCode],[ContactName],
                                sa.[Mobile], sa.[Tel], sa.[Email],[SASendLetterState],[SASendLetterDate],
                                [Name],[CreateDate],[ModifiedDate],[AccountStatus]
                                from　[dbo].[SupplierAccount] sa
                                join [dbo].[SupplierInfo] si
                                on sa.SupplierCode = si.SupplierCode
                                join [dbo].[Employee] e
                                on e.EmployeeID = sa.CreatorEmployeeID
                                where [SupplierAccountID] = @SupplierAccountID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(SqlHelper.CreateParameter("@SupplierAccountID", SqlDbType.VarChar, 10, SupAccID));
            DataTable dt = SqlHelper.AdapterFill(strCmd, list, CommandType.Text);
            this.lblSupName.Text = Convert.ToString(dt.Rows[0][0]);
            this.lblSupCode.Text = Convert.ToString(dt.Rows[0][1]);
            this.lblContactName.Text = Convert.ToString(dt.Rows[0][2]);
            this.lblMobi.Text = Convert.ToString(dt.Rows[0][3]);
            this.lblTel.Text = Convert.ToString(dt.Rows[0][4]);
            this.lblEmail.Text = Convert.ToString(dt.Rows[0][5]);
            this.lblSendEmaiState.Text = Convert.ToString(dt.Rows[0][6]);
            this.lblsendLetterdate.Text = Convert.ToString(dt.Rows[0][7]).Split(' ')[0];
            this.lblCreateEmpName.Text = Convert.ToString(dt.Rows[0][8]);
            this.lblCreateDate.Text = Convert.ToString(dt.Rows[0][9]).Split(' ')[0];
            this.lblModified.Text = Convert.ToString(dt.Rows[0][10]).Split(' ')[0];
            this.lblAccState.Text = Convert.ToString(dt.Rows[0][11]);

            //帳戶狀態顯示
            AccountStatus = Convert.ToString(dt.Rows[0][11]);
            if (AccountStatus == "E")
            {
                this.radioBtn_E.Checked = true;
                this.lblAccState.Text = "啟用中";
                this.pictureBox1.Image = Image.FromFile("..\\..\\images\\E.png");
            }
            else if (AccountStatus == "D")
            {
                this.radioBtn_D.Checked = true;
                this.lblAccState.Text = "停用中";
                this.pictureBox1.Image = Image.FromFile("..\\..\\images\\D.png");
            }
            else
            {
                this.radioBtn_R.Checked = true;
                this.lblAccState.Text = "重設中";
                this.pictureBox1.Image = Image.FromFile("..\\..\\images\\R.png");
            }

            //寄信狀態顯示
            string SendEmailStatus = Convert.ToString(dt.Rows[0][6]);
            if (SendEmailStatus == "Y")
            {
                this.lblSendEmaiState.Text = "成功";
            }
            else if (SendEmailStatus == "N")
            {
                this.lblSendEmaiState.Text = "失敗";
            }
            else
            {
                this.lblSendEmaiState.Text = "寄送中";
            }
        }
    }
}
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

namespace PMSWin.PersonAccount
{
    public partial class SupplierPersonAccountForm_ChangPwd : BaseForm
    {
        public SupplierPersonAccountForm_ChangPwd()
        {
            InitializeComponent();
            this.lblSupplierAccountID_data.Text = Common.ContainerForm.SupplierLoginAccount.SupplierAccountID;
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);
            pnlpwdData.BackColor = Color.FromArgb(250, 236, 209);
            panel1.BackColor = Color.FromArgb(189, 229, 205);
            button1.BackColor = Color.FromArgb(242, 213, 143);
            button2.BackColor = Color.FromArgb(242, 213, 143);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //舊密碼判斷
            string userInputOldPwdHash = Util.GetHash(this.txtOldPwd.Text + Common.ContainerForm.SupplierLoginAccount.PasswordSalt);
            string userOldPwdHash = Common.ContainerForm.SupplierLoginAccount.PasswordHash;
            if(userInputOldPwdHash == userOldPwdHash)
            {
                if (this.txtNewPwd.Text == this.txtNewPwdAgain.Text && this.txtNewPwd.Text.Trim() != "")
                {
                    //密碼 hash
                    string salt = Convert.ToString(Guid.NewGuid());
                    string hashPassword = Util.GetHash(this.txtNewPwd.Text.Trim() + salt.ToString());
                    string strCmdUpdate = @"update [dbo].[SupplierAccount]
                                    set [PasswordHash] = @PasswordHash, [PasswordSalt] = @PasswordSalt, [ModifiedDate] = GETDATE()
                                    where [SupplierAccountID] = @SupplierAccountID";
                    List<SqlParameter> paraList = new List<SqlParameter>();
                    SqlParameter sSupplierAccountID = SqlHelper.CreateParameter("@SupplierAccountID", SqlDbType.VarChar, 10, Common.ContainerForm.SupplierLoginAccount.SupplierAccountID);
                    SqlParameter sPasswordHash = SqlHelper.CreateParameter("@PasswordHash", SqlDbType.VarChar, 128, hashPassword);
                    SqlParameter PasswordSalt = SqlHelper.CreateParameter("@PasswordSalt", SqlDbType.VarChar, 68, salt);
                    paraList.Add(sSupplierAccountID);
                    paraList.Add(sPasswordHash);
                    paraList.Add(PasswordSalt);
                    int result = SqlHelper.ExecuteNonQuery(strCmdUpdate, paraList, CommandType.Text);
                    if (result == 1)
                    {
                        MessageBox.Show("密碼修改成功!");
                        SupplierPersonAccountForm f = new SupplierPersonAccountForm();
                        Common.ContainerForm.NextForm(f);
                    }
                    else
                    {
                        MessageBox.Show("密碼修改失敗!");
                    }
                }
                else
                {
                    MessageBox.Show("密碼輸入錯誤");
                    this.txtNewPwdAgain.Select();
                    this.txtNewPwdAgain.Text = "";
                }
            }
            else
            {
                MessageBox.Show("舊密碼錯誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //回上一頁
        private void button2_Click(object sender, EventArgs e)
        {
            SupplierPersonAccountForm f = new SupplierPersonAccountForm();
            Common.ContainerForm.NextForm(f);
        }
    }
}

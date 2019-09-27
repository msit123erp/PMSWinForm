using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMSWin.PersonAccount
{
    public partial class BuyerPersonAccountForm_ChangePwd : BaseForm
    {
        public BuyerPersonAccountForm_ChangePwd()
        {
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            pnlpwdData.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
            button2.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            button1.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            panel1.BackColor = Color.FromArgb(112, 177, 181);  //底部淺綠色
            SetMenuButton();
            // EmployeeID
            //MainForm.BuyerLoginAccount.EmployeeID
            this.lblEmployeeID_data.Text = Common.ContainerForm.BuyerLoginAccount.EmployeeID;
        }
        //確認修改密碼
        private void button1_Click(object sender, EventArgs e)
        {
            
            //if (MainForm.BuyerLoginAccount.PasswordHash == this.txtOldPwd.Text + MainForm.BuyerLoginAccount.PasswordSalt)
            //舊密碼判斷
            string userInputOldPwdHash = Util.GetHash(this.txtOldPwd.Text + Common.ContainerForm.BuyerLoginAccount.PasswordSalt);
            string userOldPwdHash = Common.ContainerForm.BuyerLoginAccount.PasswordHash;
            if (userInputOldPwdHash == userOldPwdHash)
            {
                if (this.txtNewPwd.Text == this.txtNewPwdAgain.Text && this.txtNewPwd.Text.Trim() != "")
                {
                    //密碼 hash
                    string salt = Convert.ToString(Guid.NewGuid());
                    string hashPassword = Util.GetHash(this.txtNewPwd.Text.Trim() + salt.ToString());
                    string strCmdUpdate = @"update [dbo].[Buyer]
                                    set [PasswordHash] = @PasswordHash, [PasswordSalt] = @PasswordSalt, [ModifiedDate] = GETDATE()
                                    where [EmployeeID] = @EmployeeID";
                    List<SqlParameter> paraList = new List<SqlParameter>();
                    SqlParameter sEmployeeID = SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, Common.ContainerForm.BuyerLoginAccount.EmployeeID);
                    SqlParameter sPasswordHash = SqlHelper.CreateParameter("@PasswordHash", SqlDbType.VarChar, 128, hashPassword);
                    SqlParameter PasswordSalt = SqlHelper.CreateParameter("@PasswordSalt", SqlDbType.VarChar, 68, salt);
                    paraList.Add(sEmployeeID);
                    paraList.Add(sPasswordHash);
                    paraList.Add(PasswordSalt);
                    int result = SqlHelper.ExecuteNonQuery(strCmdUpdate, paraList, CommandType.Text);
                    if (result == 1)
                    {
                        MessageBox.Show("密碼修改成功!");
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
            Common.ContainerForm.NextForm(new BuyerPersonAccountForm());
        }

        // 美工 ==============================================================

        //按鈕特效
        private void txtOldPwd_MouseEnter(object sender, EventArgs e)
        {
            TextBox btn = sender as TextBox;
            pnltxtboxHighlight.Visible = true;
            if(btn != null)
            {
                this.pnltxtboxHighlight.Top = btn.Bottom;
                this.pnltxtboxHighlight.Height = 5;
            }
        }
        private void txtNewPwd_MouseEnter(object sender, EventArgs e)
        {
            TextBox btn = sender as TextBox;
            pnltxtboxHighlight.Visible = true;
            this.pnltxtboxHighlight.Top = btn.Bottom;
            this.pnltxtboxHighlight.Height = 5;
        }
        private void txtNewPwdAgain_MouseEnter(object sender, EventArgs e)
        {
            TextBox btn = sender as TextBox;
            pnltxtboxHighlight.Visible = true;
            this.pnltxtboxHighlight.Top = btn.Bottom;
            this.pnltxtboxHighlight.Height = 5;
        }
        private void leave(object sender, EventArgs e)
        {
            pnltxtboxHighlight.Visible = false;
        }
        private void txtBgcChange(object sender, EventArgs e)
        {
            TextBox btn = sender as TextBox;
            btn.BackColor = Color.FromArgb(58, 114, 127);
        }
        private void txtBgcChange2(object sender, EventArgs e)
        {
            TextBox btn = sender as TextBox;
            btn.BackColor = Color.FromArgb(42, 73, 93);
        }

        /// <summary>
        /// 設定選單按鈕
        /// </summary>
        void SetMenuButton()
        {
            //先將按鈕隱藏
            foreach (Control ctrl in this.pnlpwdData.Controls)
            {
                ctrl.MouseLeave += leave;
                if(ctrl is TextBox)
                {
                    ctrl.MouseEnter += txtBgcChange;
                    ctrl.MouseLeave += txtBgcChange2;
                }
                if (ctrl is Panel)
                {
                    ctrl.Visible = false;
                    ctrl.MouseEnter += txtOldPwd_MouseEnter;
                }
            }
        }

        private void txtOldPwd_TextChanged(object sender, EventArgs e)
        {
            txtOldPwd.Text = txtOldPwd.Text.Replace(" ", "");
        }

        private void txtNewPwd_TextChanged(object sender, EventArgs e)
        {
            txtNewPwd.Text = txtNewPwd.Text.Replace(" ", "");
        }

        private void txtNewPwdAgain_TextChanged(object sender, EventArgs e)
        {
            txtNewPwdAgain.Text = txtNewPwdAgain.Text.Replace(" ", "");
        }
    }
}

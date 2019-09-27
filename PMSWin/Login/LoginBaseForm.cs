using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMSWin.Login
{
    public partial class LoginBaseForm : Form
    {
        public LoginBaseForm()
        {
            InitializeComponent();
            pnlContainer.BackColor = Color.FromArgb(250, 236, 209);
            txtID.BackColor = Color.FromArgb(42, 73, 93);
            txtPassword.BackColor = Color.FromArgb(42, 73, 93);
            btnLogin.BackColor = Color.FromArgb(112, 177, 181);
        }
        /// <summary>
        /// 表單標題
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 注意事項
        /// </summary>
        public string Tip { get; set; }
        /// <summary>
        /// 其他表單連結顯示文字
        /// </summary>
        public string LinkText { get; set; }

        private void LoginBaseForm_Load(object sender, EventArgs e)
        {
            //設定標題
            this.lblTitle.Text = this.Title;
            this.Text = this.Title;
            //設定注意事項
            this.lblTip.Text = this.Tip;
            //設定連結文字
            this.llFormLink.Text = this.LinkText;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Common.LoginForm.Close();
        }
    }
}

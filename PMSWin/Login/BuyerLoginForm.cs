using PMSWin.Model;
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
    public partial class BuyerLoginForm : LoginBaseForm
    {
        public BuyerLoginForm()
        {
            InitializeComponent();
            this.Init();
            pnlContainer.BackColor = Color.FromArgb(250, 236, 209);
            txtID.BackColor = Color.FromArgb(42, 73, 93);
            txtPassword.BackColor = Color.FromArgb(42, 73, 93);
            btnLogin.BackColor = Color.FromArgb(112, 177, 181);
        }

        void Init() {
            this.Title = "B2B採購系統採購人員入口";
            StringBuilder sb = new StringBuilder();
            sb.Append("歡迎使用採購系統").Append(Environment.NewLine);
            sb.Append("請確認以下注意事項").Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("1.採購人員帳號和密碼，皆由系統管理員建立").Append(Environment.NewLine);
            sb.Append("2.如新進人員需申請帳號和密碼，洽資訊部系統管理員").Append(Environment.NewLine);
            sb.Append("3.如採購人員無法登入，洽資訊部系統管理員").Append(Environment.NewLine);
            this.Tip = sb.ToString();
            this.LinkText = "供應商入口";
            this.llFormLink.Click += LlFormLink_Click;
            //測試資料
            this.txtID.Text = "P000000002";
            this.txtPassword.Text = "P@ssw0rd";
        }

        private void LlFormLink_Click(object sender, EventArgs e)
        {
            Common.LoginForm.NextForm(new SupplierLoginForm());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            BuyerLoginService bls = new BuyerLoginService();
            Buyer buyer = bls.CheckPassword(this.txtID.Text.Trim(), this.txtPassword.Text.Trim());
            if (buyer == null)
            {
                MessageBox.Show("帳號或密碼錯誤，請重新輸入");
                return;
            }
            else {
                Common.ContainerForm.BuyerLoginAccount = buyer;
                Common.ContainerForm.SetLoginRole();
                Common.ContainerForm.SetMenuButton();
                Common.ContainerForm.btnFrontPage_Click_1(null, null);
                Common.ContainerForm.Visible = true;
            }
            Common.LoginForm.Close();
        }
    }
}

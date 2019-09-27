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
    public partial class SupplierLoginForm : LoginBaseForm
    {
        public SupplierLoginForm()
        {
            InitializeComponent();
            this.Init();
        }

        void Init()
        {
            this.Title = "B2B採購系統供應商入口";
            StringBuilder sb = new StringBuilder();
            sb.Append("歡迎使用供應商入口").Append(Environment.NewLine);
            sb.Append("請確認以下注意事項").Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("1.供應商帳號和密碼，皆由採購人員建立").Append(Environment.NewLine);
            sb.Append("2.如需申請帳號和密碼，請洽本公司採購部專線").Append(Environment.NewLine);
            sb.Append("3.如供應商無法登入，請洽本公司採購部專線").Append(Environment.NewLine);
            this.Tip = sb.ToString();
            this.LinkText = "採購人員入口";
            this.llFormLink.Click += LlFormLink_Click;
            //測試資料
            this.txtID.Text = "S000000001";
            this.txtPassword.Text = "P@ssw0rd";
        }

        private void LlFormLink_Click(object sender, EventArgs e)
        {
            Common.LoginForm.NextForm(new BuyerLoginForm());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SupplierLoginService bls = new SupplierLoginService();
            Model.SupplierAccount sa = bls.CheckPassword(this.txtID.Text.Trim(), this.txtPassword.Text.Trim());
            if (sa == null)
            {
                MessageBox.Show("帳號或密碼錯誤，請重新輸入");
                return;
            }
            else
            {
                Common.ContainerForm.SupplierLoginAccount = sa;
                Common.ContainerForm.SetLoginRole();
                Common.ContainerForm.SetMenuButton();
                Common.ContainerForm.btnFrontPage_Click_1(null, null);
                Common.ContainerForm.Visible = true;
            }
            Common.LoginForm.Close();
        }
    }
}

using PMSWin.Login;
using PMSWin.Model;
using PMSWin.PurchasingOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMSWin
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 2019/10/03 呈穎 123456
        /// 2019/09/22 v0.8 add Layout Color
        /// 2019/09/21 v0.7 add Account Func
        /// 2019/09/21 v0.6 add Part Func
        /// 2019/09/21 v0.5 add Report Func
        /// 2019/09/20 v0.4 add NewOrderForm Func by 呈穎
        /// 2019/09/20 v0.3 add Order Qty Edit Func by 亞辰
        /// 2019/09/20 v0.2 merge 呈穎 code
        /// 2019/09/20 v0.1 merge 廷煥 code
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        public enum Role
        {
            Admin, Buyer, Supplier
        }

        private PropertyInfo _PropertyInfo;
        private Form _PrevForm;
        public Role LoginRole { get; set; }
        public Buyer BuyerLoginAccount { get; set; }
        public Model.SupplierAccount SupplierLoginAccount { get; set; }
        /// <summary>
        /// 是否是測試模式
        /// </summary>
        private bool IsTest;

        private void MainForm_Load(object sender, EventArgs e)
        {
            //假如沒有任何登入資料，則關閉視窗
            if (this.BuyerLoginAccount == null && this.SupplierLoginAccount == null)
            {
                this.Close();
                return;
            }
            this.Visible = true;
            //this.NextForm(new OrderForm());
            this.btnFrontPage_Click_1(sender, e);
        }

        private void Init()
        {
            Common.ContainerForm = this;
            this.Visible = false;

            //建立Session存放容器
            Util.CreateSession();

            //設定是否為測試模式
            this.IsTest = false;
            //設定測試帳號，正式使用請註解此行
            if (this.IsTest)
            {
                this.SetTestAccount("P000000002");
            }
            //顯示登入表單
            if (!this.IsTest)
            {
                LoginForm lf = new LoginForm();
                lf.ShowDialog();
                Common.LoginForm = null;
            }

            this.lblSystemName.Text = Properties.Settings.Default.AppName;
            this.Text = Properties.Settings.Default.AppName;

            //登入角色權限按鈕
            this.SetLoginRole();

            //設定選單按鈕
            this.SetMenuButton();

            //使控制項不閃爍
            this.SetControlDoubleBuffered();
        }

        public void NextForm(BaseForm f)
        {
            this.pnlContainer.Controls.Clear();

            //方法一：將其他Panel顯示在主要Panel中
            //f.pnlContent.Dock = DockStyle.None;
            //f.pnlContent.Parent = this.pnlContainer;
            //f.pnlContent.Dock = DockStyle.Fill;

            //方法二：將其他Form顯示在主要Panel中
            f.TopLevel = false;
            f.TopMost = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.WindowState = FormWindowState.Normal;
            f.StartPosition = FormStartPosition.Manual;
            f.Parent = this.pnlContainer;
            f.Location = new Point(0, 0);
            f.Size = this.pnlContainer.Size;
            f.Dock = DockStyle.Fill;
            f.Visible = true;
            f.BringToFront();

            if (this._PrevForm != null)
            {
                this._PrevForm.Close();
                this._PrevForm.Dispose();
            }
            this._PrevForm = f;

            Application.DoEvents();
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            this.pnlMenuHighlight.Top = btn.Top;
            this.pnlMenuHighlight.Height = btn.Height;
        }

        private void btnSupplierInfo_Click(object sender, EventArgs e)
        {
            SupplierInfoForm frm = new SupplierInfoForm();
            this.NextForm(frm);
        }

        private void btnSupplierAccount_Click(object sender, EventArgs e)
        {
            SupplierAccountForm frm = new SupplierAccountForm();
            this.NextForm(frm);
        }

        private void btnPart_Click(object sender, EventArgs e)
        {
            PartForm frm = new PartForm();
            this.NextForm(frm);
        }

        private void btnSourceList_Click(object sender, EventArgs e)
        {
            SourceListForm frm = new SourceListForm();
            this.NextForm(frm);
        }

        private void btnPurchasingOrder_Click(object sender, EventArgs e)
        {
            PurchasingOrderForm frm = new PurchasingOrderForm();
            this.NextForm(frm);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OrderForm frm = new OrderForm();
            this.NextForm(frm);
        }

        private void btnBuyerAccount_Click(object sender, EventArgs e)
        {
            BuyerAccountForm frm = new BuyerAccountForm();
            this.NextForm(frm);
        }

        /// <summary>
        /// 設定測試帳號
        /// </summary>
        /// <param name="ID">員工編號P000000002或供應商帳號S000000001</param>
        void SetTestAccount(string ID)
        {
            ID = ID.Trim().ToUpper();
            if (ID.StartsWith("P"))
            {
                BuyerDao bDao = new BuyerDao();
                this.BuyerLoginAccount = bDao.FindBuyerByEmployeeID(ID);
            }
            else if (ID.StartsWith("S"))
            {
                SupplierAccountDao saDao = new SupplierAccountDao();
                this.SupplierLoginAccount = saDao.FindSupplierAccountBySupplierAccountID(ID);
            }
        }

        /// <summary>
        /// 設定選單按鈕
        /// </summary>
        public void SetMenuButton()
        {
            //先將按鈕隱藏
            foreach (Control ctrl in this.pnlMenu.Controls)
            {
                if (ctrl is Button)
                {
                    ctrl.Visible = false;
                    ctrl.Click += MenuButton_Click;
                }
            }

            switch (this.LoginRole)
            {
                case Role.Admin:
                    this.btnBuyerAccount.Visible = true;
                    this.btnBuyerAccount.Top = 0;
                    break;
                case Role.Buyer:
                    this.btnFrontPage.Visible = true;
                    this.btnSupplierInfo.Visible = true;
                    this.btnSupplierAccount.Visible = true;
                    this.btnPart.Visible = true;
                    this.btnSourceList.Visible = true;
                    this.btnPurchasingOrder.Visible = true;
                    this.btnOrder.Visible = true;
                    this.btnOrder.Top = 360;
                    break;
                case Role.Supplier:
                    this.btnFrontPage.Visible = true;
                    this.btnOrder.Visible = true;
                    this.btnOrder.Top = 60;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 使控制項不閃爍
        /// https://dotblogs.com.tw/yc421206/2010/10/20/18472
        /// </summary>
        void SetControlDoubleBuffered()
        {
            this.DoubleBuffered = true;
            this.SetStyle(
                        ControlStyles.UserPaint |
                        ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.DoubleBuffer, true);

            this._PropertyInfo = this.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (Control rootCtrl in this.Controls)
            {
                this._PropertyInfo.SetValue(rootCtrl, true, null);

                if (rootCtrl.HasChildren)
                    SearchControl(rootCtrl);
            }
        }

        void SearchControl(Control Ctrl)
        {
            foreach (Control rootCtrl in Ctrl.Controls)
            {
                this._PropertyInfo.SetValue(rootCtrl, true, null);
                if (rootCtrl.HasChildren)
                    SearchControl(rootCtrl);
                else
                    break;
            }
        }

        public void btnFrontPage_Click_1(object sender, EventArgs e)
        {
            Form frm = null;
            switch (this.LoginRole)
            {
                case Role.Admin:
                    frm = new BuyerAccountForm();
                    break;
                case Role.Buyer:
                    frm = new Report.BuyerReportForm();
                    break;
                case Role.Supplier:
                    frm = new Report.SupplierReportForm();
                    break;
                default:
                    break;
            }
            this.pnlMenuHighlight.Top = 0;
            this.NextForm((BaseForm)frm);
        }

        private void pbAccount_Click(object sender, EventArgs e)
        {
            Form frm = null;
            switch (this.LoginRole)
            {
                case Role.Admin:
                case Role.Buyer:
                    frm = new PersonAccount.BuyerPersonAccountForm();
                    break;
                case Role.Supplier:
                    frm = new PersonAccount.SupplierPersonAccountForm();
                    break;
                default:
                    break;
            }
            this.NextForm((BaseForm)frm);
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            //清空帳號資料
            this.BuyerLoginAccount = null;
            this.SupplierLoginAccount = null;
            this.Init();
        }

        public void SetLoginRole()
        {
            //登入角色權限按鈕
            if (this.BuyerLoginAccount != null)
            {
                if (this.BuyerLoginAccount.EmployeeID.Equals("P000000001"))
                {
                    this.LoginRole = Role.Admin;
                    this.Text += " - 管理員";
                }
                else
                {
                    this.LoginRole = Role.Buyer;
                }
                this.Text += $" - 採購人員：{this.BuyerLoginAccount.GetEmployee().Name}";
            }
            else if (this.SupplierLoginAccount != null)
            {
                this.LoginRole = Role.Supplier;
                this.Text += $" - 供應商：{this.SupplierLoginAccount.ContactName}";
            }
        }

    }
}

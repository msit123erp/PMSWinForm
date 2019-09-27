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

namespace PMSWin.Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Init();
        }

        private Form _PrevForm;
        private PropertyInfo _PropertyInfo;

        void Init()
        {
            Common.LoginForm = this;
            //預設顯示採購人員入口
            this.NextForm(new BuyerLoginForm());

            //使控制項不閃爍
            this.SetControlDoubleBuffered();
        }

        public void NextForm(Form f)
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
            //禁止表單縮小放大
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(800, 600);

            if (this._PrevForm != null)
            {
                this._PrevForm.Close();
                this._PrevForm.Dispose();
            }
            this._PrevForm = f;

            Application.DoEvents();
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


    }
}

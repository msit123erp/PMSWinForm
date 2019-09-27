using PMSWin.Model;
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
    public partial class BuyerPersonAccountForm : BaseForm
    {
        string loginEmployeeID = Common.ContainerForm.BuyerLoginAccount.EmployeeID;
        public BuyerPersonAccountForm()
        {
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            panel2.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            pnlpwdData.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
            btnCompanyInfo.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            button1.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            button2.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            panel1.BackColor = Color.FromArgb(112, 177, 181);  //底部淺綠色
            
            this.lblEmployeeID_data.Text = Common.ContainerForm.BuyerLoginAccount.EmployeeID;
            setEmpData();
        }

        //檢視公司資料
        private void btnCompanyInfo_Click(object sender, EventArgs e)
        {
            Common.ContainerForm.NextForm(new CompanyInfoForm());
        }
        //修改帳號資料
        //TODO 不能輸入空格 / 限定字數
        private void button1_Click(object sender, EventArgs e)
        {
            string strCmdUpdate = @"update [dbo].[Employee]
                        set [Name] = @Name, [Email] = @Email, [Mobile] = @Mobile, [Tel] = @Tel
                        where [EmployeeID] = @EmployeeID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, Common.ContainerForm.BuyerLoginAccount.EmployeeID));
            parameters.Add(SqlHelper.CreateParameter("@Name", SqlDbType.NVarChar, 30, this.txtName.Text));
            parameters.Add(SqlHelper.CreateParameter("@Email", SqlDbType.VarChar, 64, this.txtEmail.Text));
            parameters.Add(SqlHelper.CreateParameter("@Mobile", SqlDbType.VarChar, 30, this.txtMobile.Text));
            parameters.Add(SqlHelper.CreateParameter("@Tel", SqlDbType.VarChar, 30, this.txtTel.Text));

            int r = SqlHelper.ExecuteNonQuery(strCmdUpdate, parameters, CommandType.Text);
            if(r == 1)
            {
                MessageBox.Show("修改成功!");
            }
            else
            {
                MessageBox.Show("修改失敗!");
            }
        }
        //前往修改密碼
        private void button2_Click(object sender, EventArgs e)
        {
            BuyerPersonAccountForm_ChangePwd frm = new BuyerPersonAccountForm_ChangePwd();
            Common.ContainerForm.NextForm(frm);
        }
        void setEmpData()
        {
            string strCmd = @"select * from [dbo].[Employee]";
            DataTable dt = SqlHelper.AdapterFill(strCmd);
            PurchasingOrder.EmployeeDao d = new PurchasingOrder.EmployeeDao();
            Employee emp = d.FindEmployeeByEmployeeID(loginEmployeeID);

            this.txtName.Text = emp.Name;
            this.txtEmail.Text = emp.Email;
            this.txtMobile.Text = emp.Mobile;
            this.txtTel.Text = emp.Tel;
        }
    }
}

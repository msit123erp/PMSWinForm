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

namespace PMSWin.PersonAccount
{
    public partial class CompanyInfoForm : BaseForm
    {
        public CompanyInfoForm()
        {
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            
            panel4.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
            button1.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            panel3.BackColor = Color.FromArgb(112, 177, 181);  //底部淺綠色
            setCompanyDate();

        }
        void setCompanyDate()
        {
            string strCmd = @"select * from [dbo].[CompanyInfo]";
            DataTable dt = SqlHelper.AdapterFill(strCmd);
            CompanyInfo c = new CompanyInfo()
            {
                CompanyInfoOID = Convert.ToInt32(dt.Rows[0][0]),
                CompanyCode = Convert.ToString(dt.Rows[0][1]),
                CompanyName = Convert.ToString(dt.Rows[0][2]),
                TaxID = Convert.ToString(dt.Rows[0][3]),
                Email = Convert.ToString(dt.Rows[0][4]),
                Tel = Convert.ToString(dt.Rows[0][5]),
                Address = Convert.ToString(dt.Rows[0][6])
            };
            this.lblCompanyCode_data.Text = c.CompanyCode.ToString();
            this.lblCompanyName_data.Text = c.CompanyName;
            this.lblTaxID_data.Text = c.TaxID;
            this.lblTel_data.Text = c.Tel;
            this.lblEmail_data.Text = c.Email;
            this.lblAddress_data.Text = c.Address;
        }
        //回上一頁
        private void button1_Click(object sender, EventArgs e)
        {
            Common.ContainerForm.NextForm(new BuyerPersonAccountForm());
        }
    }
}

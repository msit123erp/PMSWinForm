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
    public partial class SupplierPersonAccountForm : BaseForm
    {
        public SupplierPersonAccountForm()
        {
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93); 
            panel2.BackColor = Color.FromArgb(42, 73, 93);  
            pnlpwdData.BackColor = Color.FromArgb(250, 236,209); //供應商按鈕淺綠色   
            button3.BackColor = Color.FromArgb(242, 213, 143); //供應商按鈕淺綠色
            button1.BackColor = Color.FromArgb(242, 213, 143); //供應商按鈕淺綠色
            button2.BackColor = Color.FromArgb(242, 213, 143); //供應商按鈕淺綠色
            panel1.BackColor = Color.FromArgb(189,229, 205);    //供應商淺綠底 
            this.DataShow();
        }

        Dao.SupplierPersonAccountDao spad = new Dao.SupplierPersonAccountDao();

        void DataShow()
        {
            DataTable dt = spad.FindSupplierPersonAccount();

            this.label8.Text = Convert.ToString(dt.Rows[0][0]);
            this.textBox2.Text = Convert.ToString(dt.Rows[0][1]);
            this.textBox3.Text = Convert.ToString(dt.Rows[0][2]);
            this.textBox4.Text = Convert.ToString(dt.Rows[0][3]);
            this.textBox5.Text = Convert.ToString(dt.Rows[0][4]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SupplierCompanyForm frm = new SupplierCompanyForm();
            Common.ContainerForm.NextForm(frm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SupplierPersonAccountForm_ChangPwd frm = new SupplierPersonAccountForm_ChangPwd();
            Common.ContainerForm.NextForm(frm);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.textBox2.Text != "" && this.textBox3.Text != "" &&
                this.textBox4.Text != "" && this.textBox5.Text != "")
            {
                int result = spad.UpdateSupplierPersonAccount(this.textBox2.Text, this.textBox3.Text, this.textBox4.Text, this.textBox5.Text);

                if (result == 0)
                {
                    MessageBox.Show("修改失敗!!!", "Title");
                }
                else
                {
                    MessageBox.Show("修改成功!!!", "Title");
                }
            }
            else
            {
                MessageBox.Show("欄位不可為空值!");
            }
        }
            }
}

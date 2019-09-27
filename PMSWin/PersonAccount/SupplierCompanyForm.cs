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
    public partial class SupplierCompanyForm : BaseForm
    {
        public SupplierCompanyForm()
        {
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            panel1.BackColor = Color.FromArgb(250, 236, 209);  
            panel2.BackColor = Color.FromArgb(189, 229, 205);
            button1.BackColor = Color.FromArgb(242, 213, 143);
            button3.BackColor = Color.FromArgb(242, 213, 143);
            this.GetData();
        }

        Dao.SupplierPersonAccountDao spad = new Dao.SupplierPersonAccountDao();

        private void GetData()
        {
            DataTable dt = spad.FindSupplierCompany();

            this.label9.Text = Convert.ToString(dt.Rows[0][0]);
            this.textBox1.Text = Convert.ToString(dt.Rows[0][1]);
            this.textBox2.Text = Convert.ToString(dt.Rows[0][2]);
            this.textBox3.Text = Convert.ToString(dt.Rows[0][3]);
            this.textBox4.Text = Convert.ToString(dt.Rows[0][4]);
            this.textBox5.Text = Convert.ToString(dt.Rows[0][5]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text != "" && this.textBox2.Text != "" && this.textBox3.Text != "" &&
                this.textBox4.Text != "" && this.textBox5.Text != "")
            {
                int result = spad.UpdateSupplierCompany(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.textBox4.Text, this.textBox5.Text);

                if (result == 0)
                {
                    MessageBox.Show("修改失敗!!!", "Title");
                }
                else
                {
                    MessageBox.Show("修改成功", "Title");
                    SupplierPersonAccountForm frm = new SupplierPersonAccountForm();
                    Common.ContainerForm.NextForm(frm);
                }
            }
            else
            {
                MessageBox.Show("欄位不可為空值!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SupplierPersonAccountForm f = new SupplierPersonAccountForm();
            Common.ContainerForm.NextForm(f);
        }
    }
}

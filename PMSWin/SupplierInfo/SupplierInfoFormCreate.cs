using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMSWin.SupplierInfo
{
    public partial class SupplierInfoFormCreate : BaseForm
    {
        public SupplierInfoFormCreate()
        {
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            panel1.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
            button3.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            panel2.BackColor = Color.FromArgb(112, 177, 181);  //底部淺綠色
            this.comboBox1.SelectedIndex = 2;
            this.label11.Text = "";
        }

        //判斷信箱格式
        bool IsEmail(string str_Email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_Email, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dao.SupplierInfoDao da = new Dao.SupplierInfoDao();

            if(this.textBox1.Text != "" && this.textBox2.Text != "" && this.textBox3.Text != "" &&
                this.textBox4.Text != "" && this.textBox5.Text != "" && 
                !string.IsNullOrWhiteSpace(this.textBox1.Text) && !string.IsNullOrWhiteSpace(this.textBox2.Text) &&
                !string.IsNullOrWhiteSpace(this.textBox3.Text) && !string.IsNullOrWhiteSpace(this.textBox4.Text) &&
                !string.IsNullOrWhiteSpace(this.textBox5.Text))
            {
                if (IsEmail(this.textBox4.Text))
                {
                    da.SupplierCreate(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.textBox4.Text, this.textBox5.Text, Convert.ToString((this.comboBox1.SelectedIndex) + 1));
                    MessageBox.Show("新增成功!!!", "Title");
                    SupplierInfoForm frm = new SupplierInfoForm();
                    Common.ContainerForm.NextForm(frm);
                }
                else
                {
                    this.label11.Text = "請輸入正確的電子信箱!!!";
                }
            }
            else
            {
                foreach(Control p in this.panel1.Controls)
                {
                    if(p is TextBox)
                    {
                        p.Text = "";
                    }
                }
                MessageBox.Show("欄位不可為空值!!!");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar != '\b' && (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && (e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
    }
}

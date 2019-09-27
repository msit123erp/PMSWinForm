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

namespace PMSWin.SupplierInfo
{
    public partial class SupplierInfoFormUpdate : BaseForm
    {
        public SupplierInfoFormUpdate()
        {
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            panel1.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
            button3.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            panel2.BackColor = Color.FromArgb(112, 177, 181);  //底部淺綠色
            this.GetData();
        }
        
        private void GetData()
        {
            this.label10.Text = SupplierInfoForm.supplierName;
            this.label11.Text = SupplierInfoForm.taxID;
            this.label12.Text = SupplierInfoForm.tel;
            this.label13.Text = SupplierInfoForm.email;
            this.label14.Text = SupplierInfoForm.addr;
            this.comboBox1.Text = SupplierInfoForm.rateingName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dao.SupplierInfoDao da = new Dao.SupplierInfoDao();
            da.SupplierUpdate(Convert.ToString((this.comboBox1.SelectedIndex)+1), SupplierInfoForm.supplierName);
            MessageBox.Show("修改成功!!!", "Title");
            SupplierInfoForm frm = new SupplierInfoForm();
            Common.ContainerForm.NextForm(frm);
        }
    }
}

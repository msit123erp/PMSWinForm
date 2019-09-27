using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PMSWin.Part
{
    public partial class UpDatePartForm : BaseForm
    {
        DataTable DT = new DataTable();
        DataTable DT1 = new DataTable();
        PMSWin.Dao.PartDao P = new PMSWin.Dao.PartDao();
        Bitmap Pt;
        int AddTimes = 0;
        public UpDatePartForm()
        {
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            panel2.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
            button1.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            button2.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            panel3.BackColor = Color.FromArgb(112, 177, 181);  //底部淺綠色
            
            DT = P.FindSupplierName();
            DT1 = P.FindPartUnitName();
            comboBox1.DataSource = DT;
            comboBox1.DisplayMember = "供應商名稱";
            comboBox1.ValueMember = "供應商代碼";
            comboBox2.DataSource = DT1;
            comboBox2.DisplayMember = "物料單位";
            comboBox2.ValueMember = "物料單位編號";

        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdPic = new OpenFileDialog();
            ofdPic.Filter = "JPG(*.JPG;*.JPEG);|*.jpg;*.jpeg;";
            if (ofdPic.ShowDialog() == DialogResult.OK)
            {
                Pt = new Bitmap(ofdPic.FileName);
                this.pictureBox1.Image = Pt;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox6.Text != "" && comboBox2.Text != "")
            {
                int UnitPrice;
                int.TryParse(textBox6.Text, out UnitPrice);
                int partUnitOID;
                int.TryParse(comboBox2.SelectedValue.ToString(), out partUnitOID);
                P.Insert(comboBox1.Text.ToString(), comboBox1.SelectedValue.ToString(), textBox3.Text,
                    textBox2.Text, textBox4.Text,
                    comboBox2.Text, UnitPrice, partUnitOID);
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Save($@"C:\C CLASS\Independent study\Independent study picture\{textBox2.Text}-{textBox3.Text}.jpg");
                }
                AddTimes++;
                label8.Text = $"{AddTimes}";
                MessageBox.Show("資料新增成功");
                comboBox1.Text = "";
                comboBox2.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox6.Text = "";
                pictureBox1.Image = null;
            }
            else
            {
                MessageBox.Show("請輸入完整的資料");
            }
        }
    }
}

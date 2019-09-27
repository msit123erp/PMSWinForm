using PMSWin;
using PMSWin.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMSWin.Part
{

    public partial class ModiflyPartForm : BaseForm
    {
        DataTable DT = new DataTable();
        DataTable DT1 = new DataTable();
        public ModiflyPartForm()
        {
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            panel1.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
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
            comboBox1.Text = UsePartFormMethod.Pf.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.SelectedValue = UsePartFormMethod.Pf.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = UsePartFormMethod.Pf.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox3.Text = UsePartFormMethod.Pf.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = UsePartFormMethod.Pf.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox2.Text = UsePartFormMethod.Pf.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox6.Text = UsePartFormMethod.Pf.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            label8.Text = UsePartFormMethod.Pf.dataGridView1.CurrentRow.Cells[9].Value.ToString();
            PartOID = UsePartFormMethod.Pf.dataGridView1.CurrentRow.Cells[10].Value.ToString();
            PartUnitOID = UsePartFormMethod.Pf.dataGridView1.CurrentRow.Cells[11].Value.ToString();
            FileInfo f = new FileInfo($@"C:\C CLASS\Independent study\Independent study picture\{textBox2.Text}-{textBox3.Text}.jpg");
            if (f.Exists)
            {
                using (FileStream stream = new FileStream($@"C:\C CLASS\Independent study\Independent study picture\{textBox2.Text}-{textBox3.Text}.jpg", FileMode.Open, FileAccess.Read))
                {
                    pictureBox1.Image = Image.FromStream(stream);
                }
            }
            else
            {
                using (FileStream stream = new FileStream($@"C:\C CLASS\Independent study\Independent study picture\NOIMAGE\NoImage.jpg", FileMode.Open, FileAccess.Read))
                {
                    pictureBox1.Image = Image.FromStream(stream);
                }
            }
        }
        string PartOID;
        string PartUnitOID;
        PMSWin.Dao.PartDao P = new PMSWin.Dao.PartDao();
      
       
        private byte[] ImageToBuffer(Image image)
        {
            byte[] buffer = null;
            using (Bitmap oBitmap = new Bitmap(image))
            {
                using (MemoryStream MS = new MemoryStream())
                {
                    oBitmap.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg);
                    MS.Position = 0;
                    buffer = new byte[MS.Length];
                    MS.Read(buffer, 0, Convert.ToInt32(MS.Length));
                    MS.Flush();
                }
            }
            return buffer;
        }
        private Image BufferToImage(byte[] Buffer)
        {
            byte[] data = null;
            Image oImage = null;
            MemoryStream oMemoryStream = null;
            Bitmap oBitmap = null;
            //建立副本
            data = (byte[])Buffer.Clone();
            try
            {
                oMemoryStream = new MemoryStream(data);
                //設定資料流位置
                oMemoryStream.Position = 0;
                oImage = System.Drawing.Image.FromStream(oMemoryStream);
                //建立副本
                oBitmap = new Bitmap(oImage);
            }
            catch
            {
                throw;
            }
            finally
            {
                oMemoryStream.Close();
                oMemoryStream.Dispose();
                oMemoryStream = null;
            }
            return oBitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdPic = new OpenFileDialog();
            ofdPic.Filter = "JPG(*.JPG;*.JPEG);|*.jpg;*.jpeg;";
            if (ofdPic.ShowDialog() == DialogResult.OK)
            {
                FileInfo f = new FileInfo($@"C:\C CLASS\Independent study\Independent study picture\{textBox2.Text}-{textBox3.Text}.jpg");
                f.Delete();

                using (FileStream stream = new FileStream(ofdPic.FileName, FileMode.Open, FileAccess.Read))
                {
                    pictureBox1.Image = Image.FromStream(stream);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox6.Text != "" && comboBox2.Text != "")
            {
                int UnitPrice;
                int.TryParse(textBox6.Text, out UnitPrice);

                int partOID;
                int.TryParse(PartOID, out partOID);

                int partUnitOID;
                int.TryParse(PartUnitOID, out partUnitOID);

                P.Modifly(comboBox1.Text, comboBox1.SelectedValue.ToString(), textBox3.Text, textBox2.Text, textBox4.Text, comboBox2.Text, UnitPrice,
                    partOID, partUnitOID);

                if (pictureBox1.Image != null)
                {
                    //模擬接到 Byte 陣列值 ，轉換為 Image 物件
                    Image image = this.BufferToImage(this.ImageToBuffer(pictureBox1.Image));
                    //將圖片存檔
                    image.Save($@"C:\C CLASS\Independent study\Independent study picture\{textBox2.Text}-{textBox3.Text}.jpg");
                }
                MessageBox.Show("資料修改成功");
            }
            else
            {
                MessageBox.Show("請輸入完整資料");
            }

            UsePartFormMethod.Pf = new PartForm();
            string PartNumber = UsePartFormMethod.Pf.textBox3.Text = textBox2.Text;
            string PartName = UsePartFormMethod.Pf.textBox2.Text = textBox3.Text;
            string SupName = UsePartFormMethod.Pf.comboBox1.Text = "";
            UsePartFormMethod.Pf.comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            UsePartFormMethod.Pf.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            Common.ContainerForm.NextForm(UsePartFormMethod.Pf);
            UsePartFormMethod.Pf.button2_Click(sender, e);
        }
    }
}

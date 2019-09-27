using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PMSWin.Dao;

namespace PMSWin.SourceList
{
    public partial class UpdateSourceListForm : BaseForm
    {
        public UpdateSourceListForm()
        {
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);
            panel1.BackColor = Color.FromArgb(250, 236, 209);
            textBox2.BackColor = Color.FromArgb(42, 73, 93);
            textBox3.BackColor = Color.FromArgb(42, 73, 93);
            
            button1.BackColor = Color.FromArgb(242, 213, 143);
            panel3.BackColor = Color.FromArgb(189, 229, 205);
            label20.Text = UseSourceListForm.SL.dataGridView1.CurrentRow.Cells[5].Value.ToString();//料件名稱
            label13.Text = UseSourceListForm.SL.dataGridView1.CurrentRow.Cells[13].Value.ToString();//料件規格
            label14.Text = UseSourceListForm.SL.dataGridView1.CurrentRow.Cells[3].Value.ToString();//供應商名稱
            label15.Text = UseSourceListForm.SL.dataGridView1.CurrentRow.Cells[6].Value.ToString();//料件編號
            label16.Text = UseSourceListForm.SL.dataGridView1.CurrentRow.Cells[7].Value.ToString();//料件單位
            label17.Text = UseSourceListForm.SL.dataGridView1.CurrentRow.Cells[8].Value.ToString();//單價
            textBox2.Text = UseSourceListForm.SL.dataGridView1.CurrentRow.Cells[9].Value.ToString();//批量
            textBox3.Text = UseSourceListForm.SL.dataGridView1.CurrentRow.Cells[10].Value.ToString();//折扣
            string date1 = UseSourceListForm.SL.dataGridView1.CurrentRow.Cells[11].Value.ToString();//開始時間
            string x1 = Convert.ToDateTime(date1).ToString("yyyy/MM/dd HH:mm:ss");
            dateTimePicker1.Value = DateTime.ParseExact(x1, "yyyy/MM/dd HH:mm:ss", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
            string date2 = UseSourceListForm.SL.dataGridView1.CurrentRow.Cells[12].Value.ToString();//結束時間
            string x2 = Convert.ToDateTime(date2).ToString("yyyy/MM/dd HH:mm:ss");
            dateTimePicker2.Value = DateTime.ParseExact(x2, "yyyy/MM/dd HH:mm:ss", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
            label19.Text= UseSourceListForm.SL.dataGridView1.CurrentRow.Cells[14].Value.ToString();

        }
        PMSWin.Dao.SourceListDao s = new Dao.SourceListDao();
        string SourceListOID = UseSourceListForm.SL.dataGridView1.CurrentRow.Cells[2].Value.ToString();
        
        private void button1_Click(object sender, EventArgs e)
        {
            //資料轉換
            string DiscountBeginDate = dateTimePicker1.Value.ToString(), DiscountEndDate = dateTimePicker2.Value.ToString();
            int Batch = 0,x=0,time; decimal Discount = 0;
            time = DateTime.Compare(dateTimePicker1.Value, dateTimePicker2.Value);
            if (int.TryParse(textBox2.Text, out Batch) == false||Batch <= 0)
            {
                MessageBox.Show("批量資料輸入有誤請重新輸入");
                textBox2.Text = "";
                textBox2.Focus();
            }
            if (int.TryParse(SourceListOID, out x) == false || x <= 0)
            {
                MessageBox.Show("請先查詢料件");
            }
            if (decimal.TryParse(textBox3.Text, out Discount) == false|| (Discount>=1||Discount<=0))
            {
                MessageBox.Show("折扣資料輸入有誤請重新輸入");
                textBox3.Text = "";
                textBox3.Focus();
            }
            if (time >= 0)
            {
                MessageBox.Show("日期資料輸入有誤");
                dateTimePicker1.Focus();
            }
            //if (MessageBox.Show("確定要刪除此筆資料嗎?", "刪除確認!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            //{
            //    if (s.DeleteSourceList(SourceListOID))
            //    {
            //        button2_Click(sender, e);
            //        MessageBox.Show("資料刪除成功");
            //    }
            //    else
            //    {
            //        MessageBox.Show("資料刪除失敗");
            //    }
            //}

            if (Batch > 0 && x > 0 && (Discount > 0&&Discount<1)&&time<0)
            {
                //修改貨源清單
                if (MessageBox.Show("確定要修改此筆資料嗎?", "修改確認!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (s.UpdateSourceList(x, Batch, Discount, DiscountBeginDate, DiscountEndDate))
                    {
                        MessageBox.Show("修改成功資料已儲存!");
                        Common.ContainerForm.NextForm(new SourceListForm());
                        string xxx = UseSourceListForm.SL.comboBox1.Text = "";
                        string yyy = UseSourceListForm.SL.textBox2.Text = label20.Text;
                        string zzz = UseSourceListForm.SL.textBox3.Text = label15.Text;
                        UseSourceListForm.SL.button2_Click(sender, e);
                        for(int i= UseSourceListForm.SL.dataGridView1.Rows.Count-1; i>=0;i--)
                        {
                            if (UseSourceListForm.SL.dataGridView1.Rows[i].Cells[2].Value.ToString() != x.ToString())
                            {
                                //MessageBox.Show(UseSourceListForm.SL.dataGridView1.Rows[i].Cells[2].Value.ToString());
                                UseSourceListForm.SL.dataGridView1.Rows.Remove(UseSourceListForm.SL.dataGridView1.Rows[i]);
                            }
                        }
                       

                    }
                    else
                    {
                        MessageBox.Show("修改失敗");
                    }
                }
                
            }
            
            
           
        }
        

      
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMSWin.SourceList
{
    public partial class AddSourceListForm : BaseForm
    {
        List<Control> ControlList = new List<Control>();
        public AddSourceListForm()
        {
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);
            panel1.BackColor = Color.FromArgb(250, 236, 209);
            //textBox2.BackColor = Color.FromArgb(42, 73, 93);
            //textBox3.BackColor = Color.FromArgb(42, 73, 93);
            button1.BackColor = Color.FromArgb(242, 213, 143);
            panel3.BackColor = Color.FromArgb(189, 229, 205);
            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();//設定自動完成功能
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            n1 =s.GetPartName(); //設定combobox預選料件名稱
            for (int i = 0; i < n1.Rows.Count; i++)
            {
                comboBox1.Items.Add(n1.Rows[i][0].ToString());
                acc.Add(n1.Rows[i][0].ToString());
            }
            comboBox1.SelectedIndex = 0; comboBox1.AutoCompleteCustomSource = acc;
            //label20.Text = UseSourceListForm.SL.dataGridView1.CurrentRow.Cells[5].Value.ToString();//料件名稱
           
            ControlList.Add(textBox2);ControlList.Add(textBox3); ; 



        }
        PMSWin.Dao.SourceListDao s = new Dao.SourceListDao();
        DataTable n = new DataTable(); DataTable n1 = new DataTable();
        int ii = 0;
        private void button1_Click(object sender, EventArgs e)//新增貨源清單
        {
           string CreateDate = DateTime.Now.ToString();
            string PartNumber=label15.Text; int Batch; Decimal Discount; //資料轉換
            int time = DateTime.Compare(dateTimePicker1.Value, dateTimePicker2.Value); 
            string DiscountBeginDate = dateTimePicker1.Value.ToString("yyyy / MM / dd"), DiscountEndDate = dateTimePicker2.Value.ToString("yyyy / MM / dd");
            if (label15.Text == "")
            {
                MessageBox.Show("請先選擇料件");
                comboBox1.Focus();
            }

            if (int.TryParse(textBox2.Text, out Batch) == false||Batch<=0)
            {
                MessageBox.Show("批量資料輸入有誤請重新輸入");
                textBox2.Text = "";
                textBox2.Focus();
            }
            if (Decimal.TryParse(textBox3.Text, out Discount) == false|| (Discount >= 1 || Discount <= 0))
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
            if (Batch > 0 && (Discount > 0 && Discount < 1) && time < 0&&label15.Text!="")
            {                       //檢查資料庫是否有重複貨源清單
                DataTable check = s.AddCheckSourceList(PartNumber, Batch, Discount, DiscountBeginDate, DiscountEndDate);
                if (check == null)
                {                           //新增貨源清單
                    if (s.AddSourceList(PartNumber, Batch, Discount, DiscountBeginDate, DiscountEndDate, CreateDate))
                    {
                        MessageBox.Show("新增成功");
                        ii++;
                        label18.Text = ii.ToString() + "筆";
                        foreach (Control list in ControlList)
                        {
                            list.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("新增失敗");
                    }
                }
                else
                {
                    MessageBox.Show("資料重複寫入");
                }
            }
            

            

        }

        private void button2_Click(object sender, EventArgs e)//抓料件資料
        {
            string PartName = comboBox1.Text;
            if (s.GetPart(PartName)==null)
            {
                MessageBox.Show("查無料件");
            }
            else
            {
                n = s.GetPart(PartName);
                label13.Text = n.Rows[0][1].ToString();
                label14.Text = n.Rows[0][2].ToString();
                label15.Text = n.Rows[0][3].ToString();
                label16.Text = n.Rows[0][4].ToString();
                label17.Text = n.Rows[0][5].ToString();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            textBox2.Text = "500";
            textBox3.Text = "0.9";
            button2_Click(sender, e);
            dateTimePicker2.Value= dateTimePicker2.Value.AddDays(1);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string PartName = comboBox1.Text;
            if (s.GetPart(PartName) == null)
            {
                MessageBox.Show("查無料件");
            }
            else
            {
                n = s.GetPart(PartName);
                label13.Text = n.Rows[0][1].ToString();
                label14.Text = n.Rows[0][2].ToString();
                label15.Text = n.Rows[0][3].ToString();
                label16.Text = n.Rows[0][4].ToString();
                label17.Text = n.Rows[0][5].ToString();
            }
        }
    }
}

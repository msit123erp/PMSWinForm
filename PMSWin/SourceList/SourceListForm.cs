using PMSWin.SourceList;
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


namespace PMSWin
{
    public partial class SourceListForm : BaseForm
    {
        public SourceListForm()
        {
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);
            panel1.BackColor = Color.FromArgb(250, 236, 209);
            panel2.BackColor = Color.FromArgb(42, 73, 93);
            panel3.BackColor = Color.FromArgb(42, 73, 93);
            textBox2.BackColor = Color.FromArgb(42, 73, 93);
            textBox3.BackColor = Color.FromArgb(42, 73, 93);
            button1.BackColor = Color.FromArgb(242, 213, 143);
            button2.BackColor = Color.FromArgb(242, 213, 143);
            button6.BackColor =Color.FromArgb(242, 213, 143);
            UseSourceListForm.SL = this;
            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();//設定自動完成功能
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            n1 = s.GetSupplierInfo(); //設定combobox預選料件名稱
            for (int i = 0; i < n1.Rows.Count; i++)
            {
                comboBox1.Items.Add(n1.Rows[i][0].ToString()+n1.Rows[i][1]);
                acc.Add(n1.Rows[i][0].ToString() + n1.Rows[i][1]);
            }
             comboBox1.AutoCompleteCustomSource = acc;
            //AddButton();
            //n = s.GetAutoSourceList();
            //dataGridView1.DataSource = n;
            //TitleReName(ref dataGridView1);




        }
        DataTable n = new DataTable();
        PMSWin.Dao.SourceListDao s = new Dao.SourceListDao(); DataTable n1 = new DataTable(); 
        private void SourceListForm_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Common.ContainerForm.NextForm(new AddSourceListForm());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Common.ContainerForm.NextForm(new UpdateSourceListForm());
        }

        public void button2_Click(object sender, EventArgs e)//查詢資料
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear(); int combo = 0; string SupplierName;
            if (comboBox1.SelectedIndex == -1 && textBox2.Text == "" && textBox3.Text == "")
            {
                AddButton();
                n = s.GetAutoSourceList();
                dataGridView1.DataSource = n;
                return;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                SupplierName = "";
            }
            else
            {
               combo = comboBox1.SelectedIndex;
                 SupplierName = n1.Rows[combo][0].ToString();
            }
            
            
            string PartNumber = textBox3.Text;
            string PartName = textBox2.Text;
            //List<PMSWin.Model.SourceList> n = new List<PMSWin.Model.SourceList>();
            //MessageBox.Show(SupplierName);//測試

            //PMSWin.Model.SourceList sl = s.FindSourceList(PartNumber);
            //n.Add(sl);
            if (s.GetSourceList(SupplierName, PartName, PartNumber) == null)
            {
                MessageBox.Show("查無資料");
            }
            else
            {
                AddButton();
                n = s.GetSourceList(SupplierName, PartName, PartNumber);
                dataGridView1.DataSource = n;
                TitleReName(ref dataGridView1);
                this.dataGridView1.Columns["PartSpec"].Visible = false;//取出資料給別的from使用但此Form不用列出故隱藏

                //測試鎖定
                //dataGridView1.Rows.Remove(dataGridView1.Rows[0]);
                //MessageBox.Show(dataGridView1.Rows[1].Cells[2].Value.ToString());
            }
            
           
        }
        public void TitleReName(ref DataGridView d)
        {
            for (int i = 0; i < d.Columns.Count; i++)//轉換欄位名稱
            {
                d.Columns[i].Width = 130;
                switch (d.Columns[i].HeaderText)
                {
                    case "SourceListOID":
                        d.Columns[i].HeaderText = "識別碼";
                        break;
                    case "SupplierName":
                        d.Columns[i].HeaderText = "供應商名稱";
                        break;
                    case "SupplierCode":
                        d.Columns[i].HeaderText = "供應商代碼";
                        break;
                    case "PartName":
                        d.Columns[i].HeaderText = "料件品名";
                        break;
                    case "PartNumber":
                        d.Columns[i].HeaderText = "料件編號";
                        break;
                    case "PartUnitName":
                        d.Columns[i].HeaderText = "料件單位";
                        break;
                    case "UnitPrice":
                        d.Columns[i].HeaderText = "單價";
                        break;
                    case "Batch":
                        d.Columns[i].HeaderText = "批量";
                        break;
                    case "Discount":
                        d.Columns[i].HeaderText = "折扣";
                        break;
                    case "DiscountBeginDate":
                        d.Columns[i].HeaderText = "開始時間";
                        break;
                    case "DiscountEndDate":
                        d.Columns[i].HeaderText = "結束時間";
                        break;


                }
            }
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int SourceListOID = 0;
                int.TryParse(dataGridView1.CurrentRow.Cells[2].Value.ToString(),out SourceListOID);
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Btn1")
            {
                Common.ContainerForm.NextForm(new UpdateSourceListForm());
            }
            else if(dataGridView1.Columns[e.ColumnIndex].Name == "Btn2")
            {
                if (MessageBox.Show("確定要刪除此筆資料嗎?", "刪除確認!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (s.DeleteSourceList(SourceListOID))
                    {
                        button2_Click(sender, e);
                        MessageBox.Show("資料刪除成功");
                    }
                    else
                    {
                        MessageBox.Show("資料刪除失敗");
                    }
                }
               
                
            }
                
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox2.Text = "碳纖維座管束 B'TWIN";
            textBox3.Text = "BQZ444";
        }

        public void AddButton()
        {
            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();//新增按鈕欄位
            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            btn1.Name = "Btn1";
            btn1.HeaderText = "動作";
            btn1.DefaultCellStyle.NullValue = "修改";
            btn1.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(btn1);
            btn2.Name = "Btn2";
            btn2.HeaderText = "動作";
            btn2.DefaultCellStyle.NullValue = "刪除";
            btn2.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(btn2);
        }
    }
}

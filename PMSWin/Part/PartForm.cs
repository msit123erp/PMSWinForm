using PMSWin.Part;
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
using System.IO;

namespace PMSWin
{
    public partial class PartForm : BaseForm
    {
        public PartForm()
        {
            InitializeComponent();
            UsePartFormMethod.Pf = this;
            //dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(42, 73, 93);
            //dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            //splitContainer1.BackColor = Color.FromArgb(42, 73, 93);
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            panel3.BackColor = Color.FromArgb(42, 73, 93);
            panel2.BackColor = Color.FromArgb(42, 73, 93);
            panel1.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
            button1.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            button2.BackColor = Color.FromArgb(242, 213, 143);
            textBox2.BackColor = Color.FromArgb(42, 73, 93);
            textBox3.BackColor = Color.FromArgb(42, 73, 93);
            //DT = P.FindSupplierName();
            //comboBox1.DataSource = DT;
            //comboBox1.DisplayMember = "供應商名稱";
            //comboBox1.ValueMember = "供應商代碼";

        }
        PMSWin.Dao.PartDao P = new PMSWin.Dao.PartDao();
        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
        DataTable DT = new DataTable();
        string PartNumber;
        string PartName;
        string SupName;
        
       
        

        private void button3_Click(object sender, EventArgs e)
        {
            Common.ContainerForm.NextForm(new ModiflyPartForm());
        }

        

        private void comboBox1_Click(object sender, EventArgs e)
        {
            
                DT = P.FindSupplierName();
                comboBox1.DataSource = DT;
                comboBox1.DisplayMember = "供應商名稱";
                comboBox1.ValueMember = "供應商代碼";
            
        }

        public void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();


            PartNumber = textBox3.Text;
            PartName = textBox2.Text;
            SupName = comboBox1.Text;
            if (textBox3.Text == "" && textBox2.Text == "" && comboBox1.Text == "")
            {
                MessageBox.Show("請選擇供應商或輸入料件名稱和編號查詢");
            }
            else
            {
                btn.Name = "btnModify";
                btn.HeaderText = "動作";
                btn.DefaultCellStyle.NullValue = "修改";
                btn.FlatStyle = FlatStyle.Flat;
                dataGridView1.Columns.Add(btn);
                btn2.Name = "btnModify2";
                btn2.HeaderText = "動作";
                btn2.DefaultCellStyle.NullValue = "刪除";
                btn2.FlatStyle = FlatStyle.Flat;
                dataGridView1.Columns.Add(btn2);


                DT = P.FindPartByPartNumberAndPartNameOrSupplierName(PartNumber, PartName, SupName);
                dataGridView1.DataSource = DT;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {

                    if (i % 2 == 0)
                    {

                        //dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(189, 229, 205);




                    }
                    else
                    {


                        //dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(250, 236, 209);

                    }

                }

                this.dataGridView1.Columns["建檔日期"].Visible = false;
                this.dataGridView1.Columns["PartOID"].Visible = false;
                this.dataGridView1.Columns["PartUnitOID"].Visible = false;
            }
            this.Validate();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnModify")
            {
                Common.ContainerForm.NextForm(new ModiflyPartForm());
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "btnModify2")
            {
                if (MessageBox.Show("確定要刪除此筆資料嗎?", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    PartNumber = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    PartName = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    SupName = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    FileInfo f = new FileInfo($@"C:\C CLASS\Independent study\Independent study picture\{dataGridView1.CurrentRow.Cells[5].Value.ToString()}-{dataGridView1.CurrentRow.Cells[4].Value.ToString()}.jpg");
                    if (P.Delete(PartName))
                    {
                        if (comboBox1.Text == "")
                        {
                            DT = P.FindPartByPartNumberAndPartNameOrSupplierName(PartNumber, PartName, comboBox1.Text);
                            dataGridView1.DataSource = DT;
                            if (f.Exists)
                            {
                                f.Delete();

                            }

                            MessageBox.Show($"已刪除整筆資料");
                        }
                        else
                        {
                            DT = P.FindPartByPartNumberAndPartNameOrSupplierName(PartNumber, PartName, SupName);
                            dataGridView1.DataSource = DT;
                            if (f.Exists)
                            {
                                f.Delete();

                            }
                            MessageBox.Show($"已刪除整筆資料");
                        }

                    }
                    else
                    {
                        MessageBox.Show($"刪除資料失敗");
                    }


                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Common.ContainerForm.NextForm(new UpDatePartForm());
        }
    }
}

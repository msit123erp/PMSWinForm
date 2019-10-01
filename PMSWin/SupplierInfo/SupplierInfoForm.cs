using PMSWin.Dao;
using PMSWin.SupplierInfo;
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


namespace PMSWin
{
    public partial class SupplierInfoForm : BaseForm
    {
        //註解
        public SupplierInfoForm()
        {
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            panel2.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
            textBox2.BackColor = Color.FromArgb(42, 73, 93);
            textBox1.BackColor = Color.FromArgb(42, 73, 93);
            button2.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            button3.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            button4.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            panel1.BackColor = Color.FromArgb(42, 73, 93);
            panel3.BackColor = Color.FromArgb(42, 73, 93);
            this.SetData();
            this.updateButton();
            this.supplierInfoDao.getSupplierCode(this.textBox2);
            this.supplierInfoDao.getSupplierName(this.textBox1);
          
        }

        SupplierInfoDao supplierInfoDao = new SupplierInfoDao();

        private void SetData()
        {
            string cmd = "select [SupplierCode] as '公司代碼',[SupplierName] as '公司名稱',[TaxID] as '統編',[Email] as '電子信箱',[Tel] as '市話',[RatingName] as '供應商等級', [Address] as '地址'" +
                        " from SupplierInfo as i" +
                        " join SupplierRating as r" +
                        " on i.SupplierRatingOID = r.SupplierRatingOID";
            SqlHelper.ExecuteNonQuery(cmd, CommandType.Text);
            this.dataGridView1.DataSource = SqlHelper.AdapterFill(cmd, CommandType.Text);
            this.dataGridView1.Columns["地址"].Visible = false;
        }

        private void updateButton()
        {
            //建立編輯按鈕
            DataGridViewButtonColumn strcon = new DataGridViewButtonColumn();
            this.dataGridView1.Columns.Add(strcon);
            strcon.HeaderText = "編輯";
            strcon.Text = "修改";
            strcon.FlatStyle = FlatStyle.Flat;
            strcon.UseColumnTextForButtonValue = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SupplierInfoFormCreate frm = new SupplierInfoFormCreate();
            Common.ContainerForm.NextForm(frm);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text != "" || this.textBox2.Text != "")
            {
                if(!string.IsNullOrWhiteSpace(this.textBox1.Text) || !string.IsNullOrWhiteSpace(this.textBox2.Text))
                {
                    this.dataGridView1.Columns.Clear();
                    this.dataGridView1.Controls.Clear();
                    DataTable dt = supplierInfoDao.FindSupplierBySupplierCode(this.textBox1.Text, this.textBox2.Text);
                    this.dataGridView1.DataSource = dt;
                    this.updateButton();
                }
            }
            else
            {
                this.SetData();
            }
        }

        public static string supplierName;
        public static string taxID;
        public static string email;
        public static string tel;
        public static string rateingName;
        public static string addr;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                
                switch (e.ColumnIndex)
                {
                    case 0:
                        supplierName = (string)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                        taxID = (string)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
                        email = (string)dataGridView1.Rows[e.RowIndex].Cells[4].Value;
                        tel = (string)dataGridView1.Rows[e.RowIndex].Cells[5].Value;
                        rateingName = (string)dataGridView1.Rows[e.RowIndex].Cells[6].Value;
                        addr = (string)dataGridView1.Rows[e.RowIndex].Cells[7].Value;
                        SupplierInfoFormUpdate frm = new SupplierInfoFormUpdate();
                        Common.ContainerForm.NextForm(frm);
                        break;
                    case 6:
                        supplierName = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                        taxID = (string)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                        email = (string)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
                        tel = (string)dataGridView1.Rows[e.RowIndex].Cells[4].Value;
                        rateingName = (string)dataGridView1.Rows[e.RowIndex].Cells[5].Value;
                        addr = (string)dataGridView1.Rows[e.RowIndex].Cells[6].Value;
                        SupplierInfoFormUpdate frm1 = new SupplierInfoFormUpdate();
                        Common.ContainerForm.NextForm(frm1);
                        break;
                }
            }
            
        }

        private void bindingSource1_PositionChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "誌慶股份有限公司";
            this.textBox2.Text = "S00001";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMSWin
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)this.pnlContent.Controls.Find("dataGridView1", true).FirstOrDefault();
            if (dgv == null)
            {
                return;
            }
            System.Windows.Forms.DataGridViewCellStyle cs = new System.Windows.Forms.DataGridViewCellStyle();
            cs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(236)))), ((int)(((byte)(209)))));
            System.Windows.Forms.DataGridViewCellStyle cs1 = new System.Windows.Forms.DataGridViewCellStyle();
            cs1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(229)))), ((int)(((byte)(205)))));
            dgv.AlternatingRowsDefaultCellStyle = cs;
            //dgv.RowHeadersDefaultCellStyle = cs1; 112 177 181  189 229 205  250 236 209
            //dgv.ColumnHeadersDefaultCellStyle = cs1;
            dgv.RowsDefaultCellStyle.BackColor = Color.FromArgb(189,229,205);
            dgv.BackgroundColor = Color.FromArgb(250, 236, 209);
        }

    }
}

using PMSWin.BuyerAccount;
using PMSWin.Login;
using PMSWin.PersonAccount;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMSWin
{
    public partial class BuyerAccountForm : PMSWin.BaseForm
    {
        public BuyerAccountForm()
        {
            InitializeComponent();
            setDatagridView();
            addUpdateSendmailBtnColumn();
            this.dataGridView1.RowsAdded += dataGridView1_RowsAdded;
            panel1.BackColor = Color.FromArgb(42, 73, 93);
            panel2.BackColor = Color.FromArgb(42, 73, 93);
            panel3.BackColor = Color.FromArgb(250, 236, 209);
            btnBuyerPersonAccountForm_Insert.BackColor = Color.FromArgb(242, 213, 143);
            btnSearch.BackColor = Color.FromArgb(242, 213, 143);
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //轉換成中文
            DataGridView dgv = sender as DataGridView;
            foreach (DataGridViewRow r in dgv.Rows)
            {
                if ((string)r.Cells["啟用狀態"].Value == "E")
                {
                    r.Cells["啟用狀態"].Style.BackColor = Color.LightGreen;
                    r.Cells["啟用狀態"].Value = "啟用";
                }
                else if ((string)r.Cells["啟用狀態"].Value == "D")
                {
                    r.Cells["啟用狀態"].Style.BackColor = Color.LightPink;
                    r.Cells["啟用狀態"].Value = "停用";
                }
                else if ((string)r.Cells["啟用狀態"].Value == "R")
                {
                    r.Cells["啟用狀態"].Style.BackColor = Color.Yellow;
                    r.Cells["啟用狀態"].Value = "重設";
                }
            }
        }

        //新增
        private void btnBuyerPersonAccountForm_Insert_Click(object sender, EventArgs e)
        {
            Common.ContainerForm.NextForm(new BuyerPersonAccountForm_Insert());
        }

        //編輯(修改): 1.修改AccountStatus 2.重設密碼
        async private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //e.ColumnIndex 選在 '編輯' 欄位，e.RowIndex 不等於 header 裡的 '編輯'(不然按到 header 會出錯)
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                BuyerAccountForm_Update.CellEmpID = (string)this.dataGridView1.Rows[e.RowIndex].Cells["員工帳號"].Value;
                Common.ContainerForm.NextForm(new BuyerAccountForm_Update());
            }
            //e.ColumnIndex 選在 '重設密碼' 欄位
            if (e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                string myEmpID = (string)this.dataGridView1.Rows[e.RowIndex].Cells["員工帳號"].Value;
                string myEmpEmail = (string)this.dataGridView1.Rows[e.RowIndex].Cells["電子信箱"].Value;
                string accountStates = (string)this.dataGridView1.Rows[e.RowIndex].Cells["啟用狀態"].Value;
                Guid salt = Guid.NewGuid();
                string password = Util.BuildAuthToken();
                string hashPassword = Util.GetHash(password + salt.ToString());

                //int buyerOID = dao.CreateBuyer(id, hashPassword, salt.ToString(), accountStatus, createDate);
                //TODO 非同步
                await Task.Run(() =>
                {
                    //TODO ***信箱寫死 要用可換成變數 myEmpEmail
                    CreateBuyerService.SendEmailToEmp(password, "kiwijang5473@gmail.com", out string BSendLetterState);
                    //重設密碼 更新寄信時間
                    string bSendLetterDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    PurchasingOrder.BuyerDao.updateBuyerbSendLetterDate(bSendLetterDate, myEmpID);
                });
                MessageBox.Show("郵件寄送成功！");
            }
        }

        //查詢
        private string radiobtnAccountStatus;

        private DataTable dt;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (radioCtn_E.Checked)
            {
                radiobtnAccountStatus = "E";
                dt = PurchasingOrder.BuyerDao.SearchBuyerAccount(txtEmpID.Text, txtEmpName.Text, radiobtnAccountStatus);
                this.dataGridView1.DataSource = dt;
            }
            else if (radioCtn_D.Checked)
            {
                radiobtnAccountStatus = "D";
                dt = PurchasingOrder.BuyerDao.SearchBuyerAccount(txtEmpID.Text, txtEmpName.Text, radiobtnAccountStatus);
                this.dataGridView1.DataSource = dt;
            }
            else
            {
                setDatagridView();
            }
        }

        // 方法 ============================================================================
        private void setDatagridView()
        {
            DataTable dt = PurchasingOrder.BuyerDao.getAllBuyerAccount();
            this.dataGridView1.DataSource = dt;
        }

        private void addUpdateSendmailBtnColumn()
        {
            DataGridViewButtonColumn UpdatebuttonColumn = new DataGridViewButtonColumn();
            UpdatebuttonColumn.HeaderText = "編輯";
            UpdatebuttonColumn.Text = "編輯";
            UpdatebuttonColumn.FlatStyle = FlatStyle.Flat;
            UpdatebuttonColumn.UseColumnTextForButtonValue = true;
            this.dataGridView1.Columns.Add(UpdatebuttonColumn);

            DataGridViewButtonColumn SendmailbuttonColumn = new DataGridViewButtonColumn();
            SendmailbuttonColumn.HeaderText = "重設密碼";
            SendmailbuttonColumn.Text = "發送密碼";
            SendmailbuttonColumn.FlatStyle = FlatStyle.Flat;
            SendmailbuttonColumn.UseColumnTextForButtonValue = true;
            this.dataGridView1.Columns.Add(SendmailbuttonColumn);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
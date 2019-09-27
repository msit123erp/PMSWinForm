using PMSWin.Dao;
using PMSWin.Model;
using PMSWin.PurchasingOrder;
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
using static System.Windows.Forms.DataFormats;
namespace PMSWin
{
    public partial class CheckOrderForm : BaseForm
    {
        public CheckOrderForm()
        {
            InitializeComponent();
         
        }

        int colIndex;

        // FOR ONLY BUYER
        public CheckOrderForm(Buyer buyerLoginAccount, DataGridViewRow dataGridViewRow, string orderID, string checkEditOrView)
        {
            InitializeComponent();
            this.buttonAgreeOrder.Visible = false;
            //==================================================
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            panel1.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
         
            panel2.BackColor = Color.FromArgb(42, 73, 93);
            //========================================
            //=========================================
            //==============設定datagridview
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AllowUserToAddRows = false;
            //========================================
            //判斷操作角色為何，如為採購人員需要多一個新增訂單按鈕

            if (Common.ContainerForm.BuyerLoginAccount != null)
            {
                this.buyerLoginAccount = Common.ContainerForm.BuyerLoginAccount;
                labelRole.Text += " : " + this.buyerLoginAccount.GetEmployee().Name;
                this.Text += $" - 採購人員：{this.buyerLoginAccount.GetEmployee().Name}";
                pnlContent.BackColor = Color.FromArgb(42, 73, 93);
                panel1.BackColor = Color.FromArgb(250, 236, 209);
                buttonEdit.BackColor = Color.FromArgb(242, 213, 143);
                buttonCancel.BackColor = Color.FromArgb(242, 213, 143);
                buttonC.BackColor = Color.FromArgb(242, 213, 143);
                buttonSend.BackColor = Color.FromArgb(242, 213, 143);
                panel2.BackColor = Color.FromArgb(112, 177, 181);
            }
            else if (Common.ContainerForm.SupplierLoginAccount != null)
            {
                this.SupplierLoginAccount = Common.ContainerForm.SupplierLoginAccount;
                labelRole.Text += " : " + this.SupplierLoginAccount.ContactName;
                this.Text += $" - 供應商 : {this.SupplierLoginAccount.ContactName}";
                pnlContent.BackColor = Color.FromArgb(42, 73, 93);
                panel1.BackColor = Color.FromArgb(250, 236, 209);
                buttonEdit.BackColor = Color.FromArgb(242, 213, 143);
                buttonCancel.BackColor = Color.FromArgb(242, 213, 143);
                buttonC.BackColor = Color.FromArgb(242, 213, 143);
                buttonSend.BackColor = Color.FromArgb(242, 213, 143);
                panel2.BackColor = Color.FromArgb(112, 177, 181);
            }
            //========================================
            //==============設定datagridviewRow
            this.dr = dataGridViewRow;
            //=====接住訂單ID
            this.orderID = orderID;
            //=====把該訂單編號資料塞進DATAGRIDVIEW
            OrderDao orderUtility = new OrderDao();
            this.dataGridView1 = orderUtility.checkOrderFormForPublicUse(this.dataGridView1, this.orderID);
            this.colIndex = this.dataGridView1.GetColumnIndex("SourceOrderListOID");
            this.dataGridView1.Columns[colIndex].Visible = false;
            //==============確認此頁面為編輯或檢視
            if (checkEditOrView == "edit")
            {
                this.groupBoxReceiver.Enabled = false;
                this.groupBoxReceiver.Visible = false;
            }
            else if (checkEditOrView == "view")
            {
                this.groupBoxReceiver.Enabled = true;
                this.groupBoxReceiver.Visible = true;
                this.tbxName.ReadOnly = true;
                this.tbxPhone.ReadOnly = true;
                this.tbxTel.ReadOnly = true;
                this.tbxAddress.ReadOnly = true;
                this.buttonC.Enabled = false;
                this.buttonC.Visible = false;
                this.buttonCancel.Enabled = false;
                this.buttonCancel.Visible = false;
                this.buttonEdit.Enabled = false;
                this.buttonEdit.Visible = false;
                this.buttonSend.Enabled = false;
                this.buttonSend.Visible = false;
                this.tbxName.ReadOnly = true;
                this.tbxPhone.ReadOnly = true;
                this.tbxTel.ReadOnly = true;
                this.tbxAddress.ReadOnly = true;
                this.receiverData();
            }
            //============計算總計
            // this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[6].Value = "總計"; 
            for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
            {
                totalNumber += Convert.ToDecimal(this.dataGridView1.Rows[i].Cells[7].Value);
            }
            this.labelTotalShow.Text = " " + totalNumber.ToString();
        }
        /// <summary>
        /// FOR 供應商 
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="checkEditOrView">edit view</param>
        public CheckOrderForm(string orderID, string checkEditOrView)
        {
            InitializeComponent();
            this.buttonSend.Visible = false;
            //==================================================
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            panel1.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
           
            panel2.BackColor = Color.FromArgb(42, 73, 93);
            //========================================
            //=========================================
            //==============設定datagridview
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AllowUserToAddRows = false;
            //========================================
            //=====接住訂單ID
            this.orderID = orderID;
            //=======================
            //判斷操作角色為何，如為採購人員需要多一個新增訂單按鈕
            if (Common.ContainerForm.BuyerLoginAccount != null)
            {
                this.buyerLoginAccount = Common.ContainerForm.BuyerLoginAccount;
                labelRole.Text += " : " + this.buyerLoginAccount.GetEmployee().Name;
                this.Text += $" - 採購人員：{this.buyerLoginAccount.GetEmployee().Name}";
                //==============確認此頁面為編輯或檢視
                if (checkEditOrView == "edit")
                {
                    this.groupBoxReceiver.Enabled = false;
                    this.groupBoxReceiver.Visible = false;
                    this.buttonAgreeOrder.Visible = false;
                    this.buttonSend.Visible = true;
                }
                else if (checkEditOrView == "view")
                {
                    this.groupBoxReceiver.Enabled = true;
                    this.groupBoxReceiver.Visible = true;
                    this.tbxName.ReadOnly = true;
                    this.tbxPhone.ReadOnly = true;
                    this.tbxTel.ReadOnly = true;
                    this.tbxAddress.ReadOnly = true;
                    this.buttonC.Enabled = false;
                    this.buttonC.Visible = false;
                    this.buttonCancel.Enabled = false;
                    this.buttonCancel.Visible = false;
                    this.buttonEdit.Enabled = false;
                    this.buttonEdit.Visible = false;
                    this.buttonSend.Enabled = false;
                    this.buttonSend.Visible = false;
                    this.tbxName.ReadOnly = true;
                    this.tbxPhone.ReadOnly = true;
                    this.tbxTel.ReadOnly = true;
                    this.tbxAddress.ReadOnly = true;
                    this.receiverData();
                }
            }
            else if (Common.ContainerForm.SupplierLoginAccount != null)
            {
                this.SupplierLoginAccount = Common.ContainerForm.SupplierLoginAccount;
                labelRole.Text += " : " + this.SupplierLoginAccount.ContactName;
                this.Text += $" - 供應商 : {this.SupplierLoginAccount.ContactName}";
                //==============確認此頁面為編輯或檢視
                if (checkEditOrView == "edit")
                {
                    this.groupBoxReceiver.Enabled = false;
                    this.groupBoxReceiver.Visible = false;
                    this.buttonC.Enabled = false;
                    this.buttonC.Visible = false;
                    this.buttonCancel.Enabled = false;
                    this.buttonCancel.Visible = false;
                    this.buttonEdit.Enabled = false;
                    this.buttonEdit.Visible = false;
                    this.buttonSend.Enabled = false;
                    this.buttonSend.Visible = false;
                }
                else if (checkEditOrView == "view")
                {
                    this.groupBoxReceiver.Enabled = true;
                    this.groupBoxReceiver.Visible = true;
                    this.tbxName.ReadOnly = true;
                    this.tbxPhone.ReadOnly = true;
                    this.tbxTel.ReadOnly = true;
                    this.tbxAddress.ReadOnly = true;
                    this.buttonC.Enabled = false;
                    this.buttonC.Visible = false;
                    this.buttonCancel.Enabled = false;
                    this.buttonCancel.Visible = false;
                    this.buttonEdit.Enabled = false;
                    this.buttonEdit.Visible = false;
                    this.buttonSend.Enabled = false;
                    this.buttonSend.Visible = false;
                    this.tbxName.ReadOnly = true;
                    this.tbxPhone.ReadOnly = true;
                    this.tbxTel.ReadOnly = true;
                    this.tbxAddress.ReadOnly = true;
                    this.buttonAgreeOrder.Enabled = true;
                    this.buttonAgreeOrder.Visible = true;
                    this.receiverData();
                }
            }
            //========================================
            //==============設定datagridviewRow
            //this.dr = dataGridViewRow;

            //=====把該訂單編號資料塞進DATAGRIDVIEW
            OrderDao orderUtility = new OrderDao();
            this.dataGridView1 = orderUtility.checkOrderFormForPublicUse(this.dataGridView1, this.orderID);
            this.colIndex = this.dataGridView1.GetColumnIndex("SourceOrderListOID");
            this.dataGridView1.Columns[colIndex].Visible = false;
            //============計算總計
            // this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[6].Value = "總計"; 
            for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
            {
                totalNumber += Convert.ToDecimal(this.dataGridView1.Rows[i].Cells[7].Value);
            }
            this.labelTotalShow.Text = " " + totalNumber.ToString();
        }
        DataGridViewRow dr;
        string orderID;
        decimal totalNumber;
        public Buyer buyerLoginAccount { get; set; }
        public Model.SupplierAccount SupplierLoginAccount { get; set; }
        //===========抓取收貨人資料進TEXTBOX的方法，檢視頁面用
        public void receiverData()
        {
            string strcmd = @"SELECT ReceiverName,ReceiverMobile,ReceiverTel,ReceiptAddress
                              FROM [order]
                              WHERE [order].orderid = @orderid";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(SqlHelper.CreateParameter("@orderID", SqlDbType.VarChar, this.orderID));
            DataTable a = SqlHelper.AdapterFill(strcmd, sqlParameters);
            //===========檢查是否有收貨人資料
            if (a.Rows[0]["ReceiverName"].ToString() != "")
            {
                this.tbxName.Text = a.Rows[0]["ReceiverName"].ToString();
                this.tbxPhone.Text = a.Rows[0]["ReceiverMobile"].ToString();
                this.tbxTel.Text = a.Rows[0]["ReceiverTel"].ToString();
                this.tbxAddress.Text = a.Rows[0]["ReceiptAddress"].ToString();
            }

        }
        private void EditOrderForm_Load(object sender, EventArgs e)
        {
            //string strcmd = @"
            //                SELECT  
            //                [OrderPart].PartNumber,
            //                [OrderPart].PartName,
            //                [SupplierInfo].SupplierName,
            //                [Order].DateRequired,
            //                [SourceOrderList].Batch, 
            //                [OrderPart].UnitPrice * (1-[SourceOrderList].Discount) as 'BatchUnitPrice',
            //                [SourceOrderList].Qty,
            //                sum([SourceOrderList].Batch*[OrderPart].UnitPrice * (1-[SourceOrderList].Discount)*[SourceOrderList].Qty) AS total
            //                FROM [order]
            //                    JOIN　[OrderPart]
            //                    ON　[OrderPart].OrderID = [Order].OrderID
            //                join [SourceOrderList]
            //                on [SourceOrderList].OrderPartOID = [OrderPart].OrderPartOID
            //                JOIN [SupplierInfo]
            //                ON [SupplierInfo].SupplierCode = [Order].SupplierCode
            //                group by [Order].OrderID, 
            //                [OrderPart].PartNumber,
            //                [SupplierInfo].SupplierName,
            //                [Order].DateRequired,
            //                [SourceOrderList].Batch, 
            //                [OrderPart].UnitPrice * (1-[SourceOrderList].Discount) ,
            //                [OrderPart].PartName,
            //                [SourceOrderList].Qty  with rollup
            //                HAVING [order].OrderID = @orderID and 
            //                (
            //                 (
            //                [SourceOrderList].Batch is null 
            //                and
            //                ([OrderPart].UnitPrice * (1-[SourceOrderList].Discount)) is null
            //                and 
            //                [OrderPart].PartName is null
            //                and 
            //                [SourceOrderList].Qty is null
            //                 and 
            //                [OrderPart].PartNumber is null
            //                 )

            //                or
            //                 (
            //                [SourceOrderList].Batch is not null 
            //                and
            //                ([OrderPart].UnitPrice * (1-[SourceOrderList].Discount)) is not null
            //                and 
            //                [OrderPart].PartName is not null
            //                and 
            //                [SourceOrderList].Qty is not null
            //                and 
            //                [OrderPart].PartNumber is not null
            //                 )
            //                )
            //                ";
            //orderID = "20190912000001";
            //List<SqlParameter> sqlParameters = new List<SqlParameter>();
            //sqlParameters.Add(SqlHelper.CreateParameter("@orderID", SqlDbType.VarChar, 14,orderID));
            //DataTable a = SqlHelper.AdapterFill(strcmd, sqlParameters);
            //this.dataGridView1.DataSource = a;
        }


        /// <summary>
        /// 送出訂單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //=========判斷帳號是否為採購人員帳號======================================
            if (this.buyerLoginAccount != null)
            {
                //==================================================

                ////暫時先自己設定帳號所需要的變數
                //DateTime RequestDate;
                //string RequesterRole;
                //string RequesterID;
                //string OrderChangedCategoryCode;

                //RequesterRole = "P";
                //RequestDate = DateTime.Now;
                //RequesterID = this.buyerLoginAccount.EmployeeID.ToString();
                //OrderChangedCategoryCode = "P";
                ////===================================================
                //// 把異動資料UPDATE至資料庫
                //string strcmdUpdate = @"UPDATE [OrderChanged]
                //                    SET OrderChangedCategoryCode = @OrderChangedCategoryCode
                //                    WHERE OrderID = @orderID

                //                    UPDATE [OrderChanged]
                //                    SET RequestDate = @RequestDate
                //                    WHERE OrderID = @orderID

                //                    UPDATE [OrderChanged]
                //                    SET RequesterRole = @RequesterRole
                //                    WHERE OrderID = @orderID

                //                    UPDATE [OrderChanged]
                //                    SET RequesterID = @RequesterID
                //                    WHERE OrderID = @orderID
                                   
                //                    UPDATE [OrderChanged]
                //                    SET OrderChangedCategoryCode = @OrderChangedCategoryCode
                //                    WHERE OrderID = @orderID";
                //List<SqlParameter> sqlParameters = new List<SqlParameter>();
                //sqlParameters.Add(SqlHelper.CreateParameter("@orderID", SqlDbType.VarChar, 14, this.orderID));
                //sqlParameters.Add(SqlHelper.CreateParameter("@RequestDate", SqlDbType.DateTime, RequestDate));
                //sqlParameters.Add(SqlHelper.CreateParameter("@RequesterRole", SqlDbType.VarChar, 1, RequesterRole));
                //sqlParameters.Add(SqlHelper.CreateParameter("@RequesterID", SqlDbType.VarChar, 10, RequesterID));
                //sqlParameters.Add(SqlHelper.CreateParameter("@OrderChangedCategoryCode", SqlDbType.VarChar, 1, OrderChangedCategoryCode));
                //SqlHelper.ExecuteNonQuery(strcmdUpdate, sqlParameters);

                //=============================new form
                SendOrderForm frm = new SendOrderForm(this.orderID);
                Common.ContainerForm.NextForm(frm);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //改用按鈕式
            //這裡是刪除以及編輯(S3)
            //if (this.dataGridView1.Columns[e.ColumnIndex].Name == "delete")
            //{
            //    if (MessageBox.Show("確定刪除嗎?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //    {
            //        string deleteStatus = "D";
            //        string deletestring = String.Format(@"UPDATE [OrderChanged] 
            //                             set[OrderChangedCategoryCode] = '{0}'
            //                             WHERE[OrderChanged].OrderID = (SELECT o.OrderID FROM[Order] o
            //                             JOIN[orderchanged] oc on o.OrderID = oc.OrderID
            //                             WHERE o.OrderID = @orderID)", deleteStatus);
            //        //string deletestr = @"UPDATE [OrderChanged] 
            //        //                     set [OrderChangedCategoryCode] = 'D'
            //        //                     WHERE [OrderChanged].OrderID = (SELECT o.OrderID FROM [Order] o 
            //        //                     JOIN [orderchanged] oc on o.OrderID = oc.OrderID
            //        //                  WHERE o.OrderID = @orderID ) ";
            //        List<SqlParameter> sqlParameters = new List<SqlParameter>();
            //        sqlParameters.Add(SqlHelper.CreateParameter("@orderID", SqlDbType.VarChar, 14, this.orderID));
            //        SqlHelper.ExecuteNonQuery(deletestring, sqlParameters);
            //    }

            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //測試
            OrderDao a = new OrderDao();
            a.updateData("Order", "SupplierCode", "OrderID", "S00009", "20190912000001");
        }
        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click_1(object sender, EventArgs e)
        {

            if (MessageBox.Show("確定取消嗎?", "取消確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string deleteStatus = "D";
                string deletestring = String.Format(@"UPDATE [OrderChanged] 
                                         set[OrderChangedCategoryCode] = '{0}'
                                         WHERE[OrderChanged].OrderID = (SELECT o.OrderID FROM[Order] o
                                         JOIN[orderchanged] oc on o.OrderID = oc.OrderID
                                         WHERE o.OrderID = @orderID)", deleteStatus);
                //string deletestr = @"UPDATE [OrderChanged] 
                //                     set [OrderChangedCategoryCode] = 'D'
                //                     WHERE [OrderChanged].OrderID = (SELECT o.OrderID FROM [Order] o 
                //                     JOIN [orderchanged] oc on o.OrderID = oc.OrderID
                //                  WHERE o.OrderID = @orderID ) ";
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(SqlHelper.CreateParameter("@orderID", SqlDbType.VarChar, 14, this.orderID));
                SqlHelper.ExecuteNonQuery(deletestring, sqlParameters);
            }

            OrderForm frm = new OrderForm();
            Common.ContainerForm.NextForm(frm);
        }
        /// <summary>
        /// 編輯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strcmd = @"update [dbo].[orderchanged]
                                set  [orderchanged].OrderChangedCategoryCode ='E'
                                where [orderchanged].OrderID = @OrderID";
            List<SqlParameter> sqls = new List<SqlParameter>();
            sqls.Add(SqlHelper.CreateParameter("@OrderID", SqlDbType.VarChar, 14, this.orderID));
            if (SqlHelper.ExecuteNonQuery(strcmd, sqls) == 1)
            {
                MessageBox.Show("訂單已答交");
                CheckOrderForm frm = new CheckOrderForm(this.orderID, "view");
                Common.ContainerForm.NextForm(frm);
            }
            else
            {
                MessageBox.Show("訂單同意失敗");
            }

        }
        /// <summary>
        /// 掏選其他料件 不WORK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonC_Click(object sender, EventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            POSetQtyForm frm = new POSetQtyForm();
            string solOid = this.dataGridView1.CurrentRow.Cells[this.colIndex].Value.ToString();
            frm.SourceOrderListOID = Convert.ToInt32(solOid);
            frm.CmdMode = POSetQtyForm.CommandMode.OrderEdit;
            Common.ContainerForm.NextForm(frm);
        }
    }
}

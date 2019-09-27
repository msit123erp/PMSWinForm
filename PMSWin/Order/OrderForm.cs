using PMSWin.Dao;
using PMSWin.Model;
using PMSWin.PurchasingOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PMSWin
{
    public partial class OrderForm : BaseForm
    {
        public OrderForm()
        {
            InitializeComponent();
            //==================================================
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            panel1.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
            btnNew.BackColor = Color.FromArgb(242, 213, 143);
            button1.BackColor = Color.FromArgb(242, 213, 143);
            btnOrderQuery.BackColor = Color.FromArgb(242, 213, 143);
            panel2.BackColor = Color.FromArgb(42, 73, 93);
            //========================================
            this.buyerLoginAccount = Common.ContainerForm.BuyerLoginAccount;
            //========================================
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ReadOnly = true;
            //========================================
            //判斷操作角色為何，如為採購人員需要多一個新增訂單按鈕

            if (Common.ContainerForm.BuyerLoginAccount != null)
            {
                this.buyerLoginAccount = Common.ContainerForm.BuyerLoginAccount;
                btnNew.Enabled = true;
                btnNew.Visible = true;
                //labelRole.Text += " : " + this.buyerLoginAccount.GetEmployee().Name;
                this.Text += $" - 採購人員：{this.buyerLoginAccount.GetEmployee().Name}";
            }
            else if (Common.ContainerForm.SupplierLoginAccount != null)
            {
                this.SupplierLoginAccount = Common.ContainerForm.SupplierLoginAccount;
                btnNew.Enabled = false;
                btnNew.Visible = false;
                //labelRole.Text += " : " + this.SupplierLoginAccount.ContactName;
                this.Text += $" - 供應商 : {this.SupplierLoginAccount.ContactName}";
            }
            //========================================
            //=========把訂單編號資料放進TEXTBOX===============================
            string sqlCommand = " SELECT OrderID FROM [order]";
            //comboBoxOrderID.DataSource = a;
            //comboBoxOrderID.DisplayMember = "OrderID";
            //comboBoxOrderID.ValueMember = "OrderID";
            DataTable a = SqlHelper.AdapterFill(sqlCommand);
            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
            this.comboBoxOrderID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            for (int i = 0; i < a.Rows.Count; i++)
            {
                acc.Add(a.Rows[i]["OrderID"].ToString());
            }
            comboBoxOrderID.AutoCompleteCustomSource = acc;
        }
        public OrderForm(Model.SupplierAccount supplierLoginAccount)
        {
            InitializeComponent();
            //==================================================
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            panel1.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
            btnNew.BackColor = Color.FromArgb(242, 213, 143);
            button1.BackColor = Color.FromArgb(242, 213, 143);
            btnOrderQuery.BackColor = Color.FromArgb(242, 213, 143);
            panel2.BackColor = Color.FromArgb(42, 73, 93);
            //========================================
            //========================================
            this.buyerLoginAccount = buyerLoginAccount;
            this.SupplierLoginAccount = supplierLoginAccount;
            //========================================
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ReadOnly = true;
            //========================================
            //判斷操作角色為何，如為採購人員需要多一個新增訂單按鈕

            if (this.buyerLoginAccount != null)
            {
                btnNew.Enabled = true;
                btnNew.Visible = true;

                this.Text += $" - 採購人員：{this.buyerLoginAccount.GetEmployee().Name}";
            }
            else if (this.SupplierLoginAccount != null)
            {
                btnNew.Enabled = false;
                btnNew.Visible = false;

                this.Text += $" - 供應商 : {this.SupplierLoginAccount.ContactName}";
            }
            //========================================
            //=========把訂單編號資料放進TEXTBOX===============================
            string sqlCommand = " SELECT OrderID FROM [order]";
            //comboBoxOrderID.DataSource = a;
            //comboBoxOrderID.DisplayMember = "OrderID";
            //comboBoxOrderID.ValueMember = "OrderID";
            DataTable a = SqlHelper.AdapterFill(sqlCommand);
            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
            this.comboBoxOrderID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            for (int i = 0; i < a.Rows.Count; i++)
            {
                acc.Add(a.Rows[i]["OrderID"].ToString());
            }
            comboBoxOrderID.AutoCompleteCustomSource = acc;
        }
        public Buyer buyerLoginAccount { get; set; }
        public Model.SupplierAccount SupplierLoginAccount { get; set; }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnOrderQuery_Click(object sender, EventArgs e)
        {
            //clear datagridview
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            //get parameter the Sqlcommand needed
            string OrderIDString = this.comboBoxOrderID.Text;
            DateTime datetimeStart = this.datetimepickerStart.Value;
            DateTime datetimeEnd = this.dateTimePickerEnd.Value;
            // create two buttonColumns
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.Name = "edit";
            btnEdit.HeaderText = "編輯";
            btnEdit.DefaultCellStyle.NullValue = "編輯";
            DataGridViewButtonColumn btnView = new DataGridViewButtonColumn();
            btnView.Name = "view";
            btnView.HeaderText = "檢視";
            btnView.DefaultCellStyle.NullValue = "檢視";
            //=====================================================
            DataGridViewButtonCell cellEdit = new DataGridViewButtonCell();
            cellEdit.Value = "編輯";
            DataGridViewButtonCell cellView = new DataGridViewButtonCell();
            cellView.Value = "檢視";
            //SQL Command 
            if (this.buyerLoginAccount != null)
            {
                string strcmd = @"SELECT distinct [Order].OrderID AS '訂單編號',[CompanyInfo].CompanyName AS '公司名',[Employee].Name AS '員工名',[supplierInfo].SupplierName AS '供應商',
                             FORMAT( [PurchasingOrder].POBeginDate, 'yyyy/MM/dd', 'en-US' ) as '採購日期' ,occ.ChangeReson AS '訂單狀態'
							 FROM [order]
                             　JOIN　[OrderPart]
                             　ON　[OrderPart].OrderID = [Order].OrderID
                               JOIN　[SupplierInfo]
                             　ON　[SupplierInfo].SupplierCode = [Order].SupplierCode
                             　JOIN　[Employee]
                            　ON　[Employee].EmployeeID = [Order].EmployeeID
                            　JOIN　[CompanyInfo]
                            　ON　[Employee].CompanyCode = [CompanyInfo].CompanyCode                             
                             join [PurchasingOrder] 
                             on [PurchasingOrder].PurchasingOrderID = [order].PurchasingOrderID 
							 JOIN [SupplierAccount]
							 ON [SupplierAccount].SupplierCode = [SupplierAccount].SupplierCode 
							 join 
							 (
								select ocs.OrderID, OrderChangedCategoryCode
								from OrderChanged ocs
								join 
								(select OrderID, Max(OrderChangedOID) as MaxOrderChangedOID
									from OrderChanged ocs
									group by OrderID
								) as maxocOid
							  on ocs.OrderID = maxocOid.OrderID and ocs.OrderChangedOID = maxocOid.MaxOrderChangedOID
							  ) oc
							  on oc.OrderID = [order].OrderID
							  join OrderChangedCategory occ
							  on oc.OrderChangedCategoryCode = occ.OrderChangedCategoryCode
                            　WHERE [order].OrderID = @orderid OR [PurchasingOrder].POBeginDate BETWEEN @datetimeStart AND @datetimeEnd 
                              AND [order].EmployeeID = @EmployeeID ";
                List<SqlParameter> query = new List<SqlParameter>();
                query.Add(SqlHelper.CreateParameter("@orderID", SqlDbType.VarChar, 14, OrderIDString, ParameterDirection.Input));
                query.Add(SqlHelper.CreateParameter("@datetimeStart", SqlDbType.DateTime, datetimeStart, ParameterDirection.Input));
                query.Add(SqlHelper.CreateParameter("@datetimeEnd", SqlDbType.DateTime, datetimeEnd, ParameterDirection.Input));
                query.Add(SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, this.buyerLoginAccount.EmployeeID));
                DataTable a = SqlHelper.AdapterFill(strcmd, query);
                //let the table input datagridvuewOrder 
                dataGridView1.DataSource = a;
                dataGridView1.Columns.Add(btnEdit);
                dataGridView1.Columns.Add(btnView);
            }
            else if (this.SupplierLoginAccount != null)
            {
                string strcmd = @"SELECT distinct [Order].OrderID AS '訂單編號',[CompanyInfo].CompanyName AS '公司名',[Employee].Name AS '員工名',[supplierInfo].SupplierName AS '供應商',
                                 FORMAT( [PurchasingOrder].POBeginDate, 'yyyy/MM/dd', 'en-US' ) as '採購日期' ,occ.ChangeReson AS '訂單狀態'
						    	 FROM [order]
                             　JOIN　[OrderPart]
                             　ON　[OrderPart].OrderID = [Order].OrderID
                               JOIN　[SupplierInfo]
                             　ON　[SupplierInfo].SupplierCode = [Order].SupplierCode
                             　JOIN　[Employee]
                            　ON　[Employee].EmployeeID = [Order].EmployeeID
                            　JOIN　[CompanyInfo]
                            　ON　[Employee].CompanyCode = [CompanyInfo].CompanyCode                             
                             join [PurchasingOrder] 
                             on [PurchasingOrder].PurchasingOrderID = [order].PurchasingOrderID 
							 JOIN [SupplierAccount]
							 ON [SupplierAccount].SupplierCode = [SupplierAccount].SupplierCode 
							 join 
							 (
								select ocs.OrderID, OrderChangedCategoryCode
								from OrderChanged ocs
								join 
								(select OrderID, Max(OrderChangedOID) as MaxOrderChangedOID
									from OrderChanged ocs
									group by OrderID
								) as maxocOid
							  on ocs.OrderID = maxocOid.OrderID and ocs.OrderChangedOID = maxocOid.MaxOrderChangedOID
							  ) oc
							  on oc.OrderID = [order].OrderID
							  join OrderChangedCategory occ
							  on oc.OrderChangedCategoryCode = occ.OrderChangedCategoryCode
                            　WHERE ([order].OrderID = @orderID OR ([PurchasingOrder].POBeginDate BETWEEN @datetimeStart AND @datetimeEnd)) 
									AND [Order].SupplierCode = @SupplierCode AND oc.OrderChangedCategoryCode  != 'N'";
                List<SqlParameter> query = new List<SqlParameter>();
                query.Add(SqlHelper.CreateParameter("@orderID", SqlDbType.VarChar, 14, OrderIDString, ParameterDirection.Input));
                query.Add(SqlHelper.CreateParameter("@datetimeStart", SqlDbType.DateTime, datetimeStart, ParameterDirection.Input));
                query.Add(SqlHelper.CreateParameter("@datetimeEnd", SqlDbType.DateTime, datetimeEnd, ParameterDirection.Input));
                query.Add(SqlHelper.CreateParameter("@SupplierCode", SqlDbType.NVarChar, 6, this.SupplierLoginAccount.SupplierCode));
                DataTable a = SqlHelper.AdapterFill(strcmd, query);
                //let the table input datagridvuewOrder 
                dataGridView1.DataSource = a;
                dataGridView1.Columns.Add(btnEdit);
                dataGridView1.Columns.Add(btnView);
            }
            /////////////////////////////////////////////////
            //想在DATAGRIDVIEW裡面根據訂單狀態加上按鈕，失敗QQ
            ////////////////////////////////////////////////////
            //this.datagridviewOrder.Columns.Add(new DataGridViewButtonColumn());
            //this.datagridviewOrder.Columns.Add(new DataGridViewButtonColumn());
            //if ()
            //{
            //    DataGridViewButtonCell btncell = new DataGridViewButtonCell();

            //}
            ////////////////////////////////////////////////////////
            ///
            //this.datagridviewOrder.Columns.Add(new DataGridViewButtonColumn());
            //this.datagridviewOrder.Columns.Add(new DataGridViewButtonColumn());
            //for (int i = 0; i < this.datagridviewOrder.Rows.Count; i++)
            //{
            //    if (this.datagridviewOrder.Rows[i].Cells[5].Value.ToString() == "訂單取消"
            //          || this.datagridviewOrder.Rows[i].Cells[5].Value.ToString() == "訂單已答交"
            //          || this.datagridviewOrder.Rows[i].Cells[5].Value.ToString() == "訂單已出貨"
            //          || this.datagridviewOrder.Rows[i].Cells[5].Value.ToString() == "貨品已點交"
            //          || this.datagridviewOrder.Rows[i].Cells[5].Value.ToString() == "訂單已逾期"
            //          )
            //    {
            //        DataGridViewButtonCell btncell = new DataGridViewButtonCell();
            //        this.datagridviewOrder.Rows[].Cells.Add
            //    }
            //}
            /////////////////////////////////////////////////////////

        }

        BuyerDao GetBuyer = new BuyerDao();///////////////////////////////////////////////呈穎
        /// <summary>
        /// 新增訂單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            //string orderID = "";
            //if (this.datagridviewOrder.DataSource != null)
            //{
            //    orderID = this.datagridviewOrder.CurrentRow.Cells[0].Value.ToString();
            //}

            //NewOrderForm frm = new NewOrderForm(this.buyerLoginAccount, orderID);
            //Common.ContainerForm.NextForm(frm);

            Common.ContainerForm.NextForm(new NewOrderForm());

            //string BuyerName = "";
            //Buyer b = new Buyer();
            //b=GetBuyer.FindBuyerByEmployeeID("P000000005");
            //MessageBox.Show(b.BuyerOID + ""+b.CreateDate);
            //DataTable dt = new DataTable();
            //dt=GetBuyer.GetBuyerName("P000000005");
            //datagridviewOrder.DataSource = dt;
            //MessageBox.Show(dt.Rows[0][2].ToString());
        }

        /// ///////////////////////////////////////////////////////////////////呈穎

        private void tbxOrderID_TextChanged(object sender, EventArgs e)
        {

        }

        private void OrderQueryForm_Load(object sender, EventArgs e)
        {
            //btnOrderQuery_Click(sender, e);
        }

        private void datagridviewOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.buyerLoginAccount != null)
            {
                // 如果按下編輯 進入編輯頁面
                //FOR 採購人員
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "edit")
                {
                    //label5.Text = this.datagridviewOrder.Rows[e.RowIndex].Cells[5].Value.ToString();
                    if (this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "訂單取消"
                        || this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "訂單已答交"
                        || this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "訂單已出貨"
                        || this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "貨品已點交"
                        || this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "訂單已逾期"
                         || this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "訂單已送出"
                        )
                    {
                        MessageBox.Show(this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                    }
                    else
                    {
                        string editstr = this.dataGridView1.Columns[e.ColumnIndex].Name;
                        string s = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        DataGridViewRow DataGridViewRow = this.dataGridView1.CurrentRow;
                        CheckOrderForm frm = new CheckOrderForm(this.buyerLoginAccount, DataGridViewRow, s, editstr);
                        Common.ContainerForm.NextForm(frm);
                    }
                }
                // 如果按下檢視進入檢視頁面
                else if (this.dataGridView1.Columns[e.ColumnIndex].Name == "view")
                {
                    //===============
                    if (this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "訂單取消"
                          || this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "訂單已答交"
                          || this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "訂單已出貨"
                          || this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "貨品已點交"
                          || this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "訂單已逾期"
                          || this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "訂單已送出"
                          )
                    {
                        string viewstr = this.dataGridView1.Columns[e.ColumnIndex].Name;
                        string orderID = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        DataGridViewRow dataGridViewRow = this.dataGridView1.CurrentRow;
                        CheckOrderForm frm = new CheckOrderForm(this.buyerLoginAccount, dataGridViewRow, orderID, viewstr);
                        Common.ContainerForm.NextForm(frm);
                    }
                    else
                    {
                        MessageBox.Show(this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                    }
                }

            }
            //FOR 供應商
            else if (this.SupplierLoginAccount != null)
            {
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "edit")
                {
                    if (
                         this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "訂單已送出"
                       )
                    {
                        string orderID = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        CheckOrderForm frm = new CheckOrderForm(orderID, "edit");
                        Common.ContainerForm.NextForm(frm);
                    }
                    else
                    {
                        MessageBox.Show(this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                    }
                }
                else if (this.dataGridView1.Columns[e.ColumnIndex].Name == "view")
                {
                    if (
                        this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "訂單取消"
                     || this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "訂單已答交"
                     || this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "訂單已出貨"
                     || this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "貨品已點交"
                     || this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "訂單已逾期"
                       //|| this.datagridviewOrder.Rows[e.RowIndex].Cells[5].Value.ToString() == "訂單已送出"
                       )
                    {
                        string orderID = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        CheckOrderForm frm = new CheckOrderForm(orderID, "view");
                        Common.ContainerForm.NextForm(frm);
                    }
                    else
                    {
                        MessageBox.Show(this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                    }
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //測試用
            //string s = this.datagridviewOrder.CurrentRow.Cells[0].Value.ToString();
            //this.button1.Text = s;
            OrderDao orderDao = new OrderDao();
            orderDao.updateData("Order", "SupplierCode", "OrderID", "S00009", "20190912000001");
        }
    }
}

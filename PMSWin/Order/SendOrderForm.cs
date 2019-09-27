using PMSWin.Dao;
using PMSWin.Model;
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
    public partial class SendOrderForm : BaseForm
    {
        public SendOrderForm(string NewOrderID)
        {
            InitializeComponent();
            pnlContent.BackColor = Color.FromArgb(42, 73, 93);  //深藍底
            panel1.BackColor = Color.FromArgb(250, 236, 209);    //淺黃底
            btnSend.BackColor = Color.FromArgb(242, 213, 143); // 按鈕深黃色
            panel2.BackColor = Color.FromArgb(112, 177, 181);  //底部淺綠色
            //=========================================
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ReadOnly = true;
            //========================================
            //========================================
            //判斷操作角色為何，如為採購人員需要多一個新增訂單按鈕

            if (Common.ContainerForm.BuyerLoginAccount != null)
            {
                this.buyerLoginAccount = Common.ContainerForm.BuyerLoginAccount;
                labelRole.Text = $"採購員：{ this.buyerLoginAccount.GetEmployee().Name}";
            }
            else if (Common.ContainerForm.SupplierLoginAccount != null)
            {
                this.SupplierLoginAccount = Common.ContainerForm.SupplierLoginAccount;
                labelRole.Text = $"供應商：{this.SupplierLoginAccount.ContactName}";
            }
            //========================================
            //========================================
            this.orderID = NewOrderID;
            OrderDao o = new OrderDao();
            this.dataGridView1 = o.sendOrderFormForPblicUse(this.dataGridView1, NewOrderID);
            int colIndex = this.dataGridView1.GetColumnIndex("SourceOrderListOID");
            this.dataGridView1.Columns[colIndex].Visible = false;
            //============計算總計
            // this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[6].Value = "總計"; 
            for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
            {
                totalNumber += Convert.ToDecimal(this.dataGridView1.Rows[i].Cells[8].Value);
            }
            this.labelTotalShow.Text = " " + totalNumber.ToString();
        }
        decimal totalNumber;
        
        string orderID;
        public Buyer buyerLoginAccount { get; set; }
        public Model.SupplierAccount SupplierLoginAccount { get; set; }
        public void sendOrderFormForPblicUse()
        {
            string strcmd = @"
                            SELECT o.OrderID, op.PartNumber, op.PartName, supin.SupplierName,
                                   FORMAT( o.DateRequired, 'yyyy/MM/dd', 'en-US' ) as 'DateRequired', sol.Batch, (p.UnitPrice*sol.Discount) AS 'batchquantity',
	                               sol.Qty, SUM(sol.Batch*sol.Qty*(p.UnitPrice*sol.Discount)) AS '小計'
                            From [order] o
                            JOIN [OrderPart] op
                            on o.OrderID= op.OrderID
                            JOIN [SupplierInfo] supin
                            on o.SupplierCode = supin.SupplierCode
                            JOIN [SourceOrderList] sol
                            ON op.OrderPartOID = sol.OrderPartOID
                            JOIN [Part] p
                            ON op.PartNumber = p.PartNumber
                            GROUP BY o.OrderID,op.PartNumber,op.PartName,supin.SupplierName,
                           o.DateRequired,sol.Batch,(p.UnitPrice*sol.Discount) ,
	                       sol.Qty
	                       WITH ROLLUP
	                       HAVING o.OrderID = @orderID
	                       AND
	                       (
	                       op.PartName is null and
	                       supin.SupplierName is null and
	                       op.PartNumber is null
	                       )
	                       or
	                       (
	                       op.PartName is not null and
	                       supin.SupplierName is not null and
	                       op.PartNumber is not null and 
	                       o.DateRequired is not null and 
	                       sol.Batch is not null and 
	                       (p.UnitPrice*sol.Discount) is not null and
	                       sol.Qty is not null and 
	                       sol.Batch*sol.Qty*(p.UnitPrice*sol.Discount) is not null 
	                       )";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(SqlHelper.CreateParameter("@orderID", SqlDbType.VarChar, 14, orderID));
            DataTable dataTable = SqlHelper.AdapterFill(strcmd, sqlParameters);
            this.dataGridView1.DataSource = dataTable;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string strcmd = @"  UPDATE [Order]
                                SET ReceiverName = @ReceiverName
                                WHERE OrderID = @orderID 

                                UPDATE [Order]
                                SET ReceiverMobile = @ReceiverMobile 
                                WHERE OrderID = @orderID

                                UPDATE [Order]
                                SET ReceiverTel =@ReceiverTel 
                                WHERE OrderID = @orderID

                                UPDATE [Order]
                                SET ReceiptAddress =  @ReceiptAddress
                                WHERE OrderID = @orderID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(SqlHelper.CreateParameter("@orderID", SqlDbType.VarChar, 14, orderID));
            sqlParameters.Add(SqlHelper.CreateParameter("@ReceiverName", SqlDbType.NVarChar, 30, this.tbxName.Text));
            sqlParameters.Add(SqlHelper.CreateParameter("@ReceiverMobile", SqlDbType.VarChar, 30, this.tbxPhone.Text));
            sqlParameters.Add(SqlHelper.CreateParameter("@ReceiverTel", SqlDbType.VarChar, 30, this.tbxTel.Text));
            sqlParameters.Add(SqlHelper.CreateParameter("@ReceiptAddress", SqlDbType.NVarChar, 256, this.tbxAddress.Text));
            SqlHelper.ExecuteNonQuery(strcmd, sqlParameters);

            OrderChangedDao ocDao = new OrderChangedDao();
            OrderChanged oc = new OrderChanged();
            oc.OrderID = orderID;
            oc.OrderChangedCategoryCode = "P";
            oc.RequestDate = DateTime.Now;
            oc.RequesterRole = "P";
            oc.RequesterID = Common.ContainerForm.BuyerLoginAccount.EmployeeID;
            ocDao.UpdateOrderChanged(oc);

            OrderForm frm = new OrderForm();
            Common.ContainerForm.NextForm(frm);
        }

    }
}

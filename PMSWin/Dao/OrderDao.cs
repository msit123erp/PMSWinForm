using PMSWin.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMSWin.Dao
{
    class OrderDao
    {
        public Model.Order OrderID(string orderID)
        {
            string strcmd = @"SELECT orderid,PurchasingOrderID,SupplierCode,SupplierAccountID,
                              EmployeeID,DateRequired,DateReleased,ReceiverName,ReceiverTel,
                              ReceiverMobile,ReceiptAddress
                              FROM [order]
                              WHERE [Order].OrderID = @orderID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(SqlHelper.CreateParameter("@orderID", SqlDbType.VarChar, 14, orderID));
            DataTable a = SqlHelper.AdapterFill(strcmd, sqlParameters);
            if (a.Rows.Count == 0)
            {
                return null;
            }
            Model.Order order = this.GetOrder(a.Rows[0]);
            return order;
        }

        public DataTable FindPurchasingOrderDetail(string PurchasingOrderID, List<int> PodOIDs)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select　[PurchasingOrderDetailListOID] as '採購單明細識別碼', sl.[PartNumber] as '料件編號',[PartName] as '料件品名',[SupplierName] as '供應商名稱',[Batch] as '批量',[UnitPrice] AS '批量單價',[Qty] as '採購數量',([UnitPrice]*[Discount])*Qty AS '小計',
si.SupplierCode, PartSpec, PartUnitName, Discount
 from [dbo].[PurchasingOrderDetail]pod
 join [dbo].[SourceList]sl
 on pod.SourceListOID=sl.SourceListOID
 join [dbo].[Part]p
 on sl.PartNumber=p.PartNumber
 join [dbo].[SupplierInfo]si
 on p.SupplierCode=si.SupplierCode
 join PartUnit pu
 on pu.PartUnitOID = p.PartUnitOID

 where PurchasingOrderID=@PurchasingOrderID and PurchasingOrderDetailListOID in (");
            parameters.Add(SqlHelper.CreateParameter($"@PurchasingOrderID", SqlDbType.VarChar, 14, PurchasingOrderID));
            for (int i = 0; i < PodOIDs.Count; i++)
            {
                if (i < PodOIDs.Count - 1)
                {
                    sb.Append($"@PurchasingOrderDetailListOID{i}, ");
                }
                else
                {
                    sb.Append($"@PurchasingOrderDetailListOID{i}");
                }
                parameters.Add(SqlHelper.CreateParameter($"@PurchasingOrderDetailListOID{i}", SqlDbType.Int, PodOIDs[i]));
            }
            sb.Append(")");
            DataTable dt = SqlHelper.AdapterFill(sb.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            return dt;
        }

        internal string InsertNewOrder(Order order, OrderChanged orderChanged, List<OrderPart> opList, List<SourceOrderList> soList)
        {
            string OrderID = "";
            using (Transactions tx = new Transactions(600))
            {
                string strCmd = @"declare @OrderID varchar(14)
                                                    set @OrderID = (select convert(varchar, getdate(), 112) + right(format((select MAX(OrderOID)+1 from [Order] with (TABLOCKX)), '00000#'),6))
                                                    INSERT INTO [dbo].[Order]([OrderID], [PurchasingOrderID], [SupplierCode], [SupplierAccountID], [EmployeeID], [DateRequired])
                                                    VALUES(@OrderID, @PurchasingOrderID, @SupplierCode, @SupplierAccountID, @EmployeeID, @DateRequired)
                                                    select @OrderID";
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(SqlHelper.CreateParameter("@PurchasingOrderID", SqlDbType.VarChar, 14, order.PurchasingOrderID));
                parameters.Add(SqlHelper.CreateParameter("@SupplierCode", SqlDbType.NVarChar, 6, order.SupplierCode));
                parameters.Add(SqlHelper.CreateParameter("@SupplierAccountID", SqlDbType.VarChar, 10, order.SupplierAccountID));
                parameters.Add(SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, order.EmployeeID));
                parameters.Add(SqlHelper.CreateParameter("@DateRequired", SqlDbType.DateTime, order.DateRequired));

                try
                {
                    OrderID = Convert.ToString(tx.ExecuteScalar(strCmd, parameters));
                    strCmd = @"INSERT INTO [dbo].[OrderChanged]([OrderID], [OrderChangedCategoryCode], [RequestDate], [RequesterRole], [RequesterID])
                                            VALUES(@OrderID, @OrderChangedCategoryCode, @RequestDate, @RequesterRole, @RequesterID)";
                    parameters.Clear();
                    parameters.Add(SqlHelper.CreateParameter("@OrderID", SqlDbType.VarChar, 14, OrderID));
                    parameters.Add(SqlHelper.CreateParameter("@OrderChangedCategoryCode", SqlDbType.VarChar, 1, orderChanged.OrderChangedCategoryCode));
                    parameters.Add(SqlHelper.CreateParameter("@RequestDate", SqlDbType.DateTime, orderChanged.RequestDate));
                    parameters.Add(SqlHelper.CreateParameter("@RequesterRole", SqlDbType.VarChar, 1, orderChanged.RequesterRole));
                    parameters.Add(SqlHelper.CreateParameter("@RequesterID", SqlDbType.VarChar, 10, orderChanged.RequesterID));
                    tx.ExecuteNonQuery(strCmd, parameters);

                    int OrderPartOID = -1;
                    for (int i = 0; i < opList.Count; i++)
                    {
                        strCmd = @"INSERT INTO [dbo].[OrderPart]([OrderID], [PartNumber], [PartName], [PartSpec], [PartUnitName], [UnitPrice])
                                                VALUES(@OrderID, @PartNumber, @PartName, @PartSpec, @PartUnitName, @UnitPrice)
                                                SELECT IDENT_CURRENT ('OrderPart')";
                        parameters.Clear();
                        parameters.Add(SqlHelper.CreateParameter("@OrderID", SqlDbType.VarChar, 14, OrderID));
                        parameters.Add(SqlHelper.CreateParameter("@PartNumber", SqlDbType.NVarChar, 10, opList[i].PartNumber));
                        parameters.Add(SqlHelper.CreateParameter("@PartName", SqlDbType.NVarChar, 30, opList[i].PartName));
                        if (!string.IsNullOrEmpty(opList[i].PartSpec))
                        {
                            parameters.Add(SqlHelper.CreateParameter("@PartSpec", SqlDbType.NVarChar, 128, opList[i].PartSpec));
                        }
                        parameters.Add(SqlHelper.CreateParameter("@PartUnitName", SqlDbType.NVarChar, 6, opList[i].PartUnitName));
                        parameters.Add(SqlHelper.CreateParameter("@UnitPrice", SqlDbType.Int, opList[i].UnitPrice));
                        OrderPartOID = Convert.ToInt32(tx.ExecuteScalar(strCmd, parameters));

                        strCmd = @"INSERT INTO [dbo].[SourceOrderList]([OrderPartOID], [Batch], [Discount], [Qty], [PurchasingOrderDetailListOID])
                                                VALUES(@OrderPartOID, @Batch, @Discount, @Qty, @PurchasingOrderDetailListOID)";
                        parameters.Clear();
                        parameters.Add(SqlHelper.CreateParameter("@OrderPartOID", SqlDbType.Int, OrderPartOID));
                        parameters.Add(SqlHelper.CreateParameter("@Batch", SqlDbType.Int, soList[i].Batch));
                        parameters.Add(SqlHelper.CreateParameter("@Discount", SqlDbType.Decimal, soList[i].Discount));
                        parameters.Add(SqlHelper.CreateParameter("@Qty", SqlDbType.Int, soList[i].Qty));
                        parameters.Add(SqlHelper.CreateParameter("@PurchasingOrderDetailListOID", SqlDbType.Int, soList[i].PurchasingOrderDetailListOID));
                        tx.ExecuteNonQuery(strCmd, parameters);
                    }
                }
                catch (SqlException ex)
                {
                    tx.RollbackTransactions();
                    throw ex;
                }
                catch (Exception ex)
                {
                    tx.RollbackTransactions();
                    throw ex;
                }
                tx.commitTransaction();
            }
            return OrderID;
        }

        private Model.Order GetOrder(DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }
            Model.Order order = new Model.Order();
            order.OrderOID = Convert.ToInt32(dr["OrderOID"]);
            order.OrderID = Convert.ToString(dr["OrderID"]);
            order.PurchasingOrderID = Convert.ToString(dr["PurchasingOrderID"]);
            order.SupplierCode = Convert.ToString(dr["SupplierCode"]);
            order.SupplierAccountID = Convert.ToString(dr["SupplierAccountID"]);
            order.EmployeeID = Convert.ToString(dr["EmployeeID"]);
            if (!SqlHelper.IsNull(dr["DateRequired"]))
            {
                order.DateRequired = Convert.ToDateTime(dr["DateRequired"]);
            }
            if (!SqlHelper.IsNull(dr["DateReleased"]))
            {
                order.DateReleased = Convert.ToDateTime(dr["DateReleased"]);
            }
            if (!SqlHelper.IsNull(dr["ReceiverName"]))
            {
                order.ReceiverName = Convert.ToString(dr["ReceiverName"]);
            }
            if (!SqlHelper.IsNull(dr["ReceiverTel"]))
            {
                order.ReceiverTel = Convert.ToString(dr["ReceiverTel"]);
            }
            if (!SqlHelper.IsNull(dr["ReceiverMobile"]))
            {
                order.ReceiverMobile = Convert.ToString(dr["ReceiverMobile"]);
            }
            if (!SqlHelper.IsNull(dr["ReceiptAddress"]))
            {
                order.ReceiptAddress = Convert.ToString(dr["ReceiptAddress"]);
            }
            return order;
        }
        public int updateData(string tablename, string tableDataUpdated, string whereIsIt, string update, string where)
        {
            //寫到一半
            int t1 = tableDataUpdated.Length + 1;
            string tableDataNew = "@" + tableDataUpdated;
            int t2 = whereIsIt.Length + 1;
            string tableWhereNew = "@" + whereIsIt;
            string strcmd = $" UPDATE [{tablename}]" +
                            $"SET {tableDataUpdated} = {update}" +
                            $"WHERE {whereIsIt} = '{where}'";
            //List<SqlParameter> sqlParameters = new List<SqlParameter>();
            //sqlParameters.Add(SqlHelper.CreateParameter(tableDataNew, SqlDbType.VarChar, t1, update));
            //sqlParameters.Add(SqlHelper.CreateParameter(tableWhereNew, SqlDbType.VarChar, t2, where));
            return SqlHelper.ExecuteNonQuery(strcmd);
        }
        public void receiver(string orderID, string name, string phone, string tel, string address)
        {
            //string strcmd = @"";
        }
        public DataGridView checkOrderFormForPublicUse(DataGridView dataGridView1, string orderID)
        {
            //轉換FORM 需要 秀出 訂單資料
            //======================================================
            // 新增 兩個按鈕COLUMN
            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //btn.Name = "edit";
            //btn.HeaderText = "編輯";
            //btn.DefaultCellStyle.NullValue = "編輯";
            //DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            //btn2.Name = "delete";
            //btn2.HeaderText = "刪除";
            //btn2.DefaultCellStyle.NullValue = "刪除";
            //dataGridView1.Columns.Add(btn);
            //dataGridView1.Columns.Add(btn2);
            //===========================================================
            string strcmd = @"SELECT  
                            [OrderPart].PartNumber as '料件編號',
                            [OrderPart].PartName as '料件品名',
                            [SupplierInfo].SupplierName as '供應商名稱',
                            [Order].DateRequired as '需求日期',
                            [SourceOrderList].Batch as '批量', 
                            [OrderPart].UnitPrice * ([SourceOrderList].Discount) as '批量單價',
                            [SourceOrderList].Qty as '採購數量',
                            sum([SourceOrderList].Batch*[OrderPart].UnitPrice * ([SourceOrderList].Discount)*[SourceOrderList].Qty) AS '小計',
                            SourceOrderListOID
                            FROM [order]
　                               JOIN　[OrderPart]
　                               ON　[OrderPart].OrderID = [Order].OrderID
                            join [SourceOrderList]
                            on [SourceOrderList].OrderPartOID = [OrderPart].OrderPartOID
                            JOIN [SupplierInfo]
                            ON [SupplierInfo].SupplierCode = [Order].SupplierCode
							group by [Order].OrderID, 
                            [OrderPart].PartNumber,
                            [SupplierInfo].SupplierName,
                            [Order].DateRequired,
                            [SourceOrderList].Batch, 
                            [OrderPart].UnitPrice * ([SourceOrderList].Discount) ,
                            [OrderPart].PartName,
                            [SourceOrderList].Qty,
							SourceOrderListOID
							HAVING [order].OrderID = @orderID";
            //orderID = "20190912000001";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(SqlHelper.CreateParameter("@orderID", SqlDbType.VarChar, 14, orderID));
            DataTable a = SqlHelper.AdapterFill(strcmd, sqlParameters);
            dataGridView1.DataSource = a;
            dataGridView1.Columns[8].Visible = false;
            return dataGridView1;
        }
        public DataGridView sendOrderFormForPblicUse(DataGridView dataGridView, string orderID)
        {
            string strcmd = @"SELECT  
                            [OrderPart].PartNumber as '料件編號',
                            [OrderPart].PartName as '料件品名',
                            [SupplierInfo].SupplierName as '供應商名稱',
                            [Order].DateRequired as '需求日期',
                            [SourceOrderList].Batch as '批量', 
                            [OrderPart].UnitPrice * ([SourceOrderList].Discount) as '批量單價',
                            [SourceOrderList].Qty as '採購數量',
                            sum([SourceOrderList].Batch*[OrderPart].UnitPrice * ([SourceOrderList].Discount)*[SourceOrderList].Qty) AS '小計',
                            SourceOrderListOID
                            FROM [order]
　                               JOIN　[OrderPart]
　                               ON　[OrderPart].OrderID = [Order].OrderID
                            join [SourceOrderList]
                            on [SourceOrderList].OrderPartOID = [OrderPart].OrderPartOID
                            JOIN [SupplierInfo]
                            ON [SupplierInfo].SupplierCode = [Order].SupplierCode
							group by [Order].OrderID, 
                            [OrderPart].PartNumber,
                            [SupplierInfo].SupplierName,
                            [Order].DateRequired,
                            [SourceOrderList].Batch, 
                            [OrderPart].UnitPrice * ([SourceOrderList].Discount) ,
                            [OrderPart].PartName,
                            [SourceOrderList].Qty,
							SourceOrderListOID
							HAVING [order].OrderID = @orderID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(SqlHelper.CreateParameter("@orderID", SqlDbType.VarChar, 14, orderID));
            DataTable dataTable = SqlHelper.AdapterFill(strcmd, sqlParameters);
            dataGridView.DataSource = dataTable;
            return dataGridView;
        }
        public DataRow newOrderCheckForm(int PurchasingOrderDetailListOID)
        {
            string strcmd = @" select　[PurchasingOrderDetailListOID],sl.[PartNumber],[PartName],[SupplierName],[Batch],[UnitPrice]*[Discount]as　BatchUnitprice,[Qty],([UnitPrice]*[Discount])*Qty　as total
                                 from [dbo].[PurchasingOrderDetail]pod
                                 join [dbo].[SourceList]sl
                                 on pod.SourceListOID=sl.SourceListOID
                                 join [dbo].[Part]p
                                 on sl.PartNumber=p.PartNumber
                                 join [dbo].[SupplierInfo]si
                                 on p.SupplierCode=si.SupplierCode
                                 where  PurchasingOrderDetailListOID = @PurchasingOrderDetailListOID";
            List<SqlParameter> sqls = new List<SqlParameter>();
            sqls.Add(SqlHelper.CreateParameter("@PurchasingOrderDetailListOID", SqlDbType.Int, PurchasingOrderDetailListOID));
            DataTable dt = SqlHelper.AdapterFill(strcmd, sqls);
            DataRow dr = dt.Rows[0];
            return dr;
        }
        public DataTable catchThePurchasingOrderDetailListOIDAndCreateTable(List<int> PurchasingOrderDetailListOID)
        {
            ///////////////////////////////  寫到這裡，來去睡了20190920  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            DataTable dataTable = new DataTable();
            if (PurchasingOrderDetailListOID.Count > 0)
            {
                for (int i = 0; i < PurchasingOrderDetailListOID.Count; i++)
                {
                    DataRow dr = this.newOrderCheckForm(PurchasingOrderDetailListOID[i]);
                    dr = dataTable.NewRow();
                    dataTable.Rows.Add(dr);
                }
                return dataTable;
            }
            return null;
        }

        //因為沒帳號，先假裝一個來用
        public static class buyer
        {
            public static int BuyerOID = 1;
            public static string EmployeeID = "P000000002";
            public static string PasswordHash { get; set; }
            public static string PasswordSalt { get; set; }
            public static string AccountStatus = "E";
            public static System.DateTime CreateDate { get; set; }
            public static Nullable<System.DateTime> ModifiedDate { get; set; }
            public static string BSendLetterState = "Y";
            public static Nullable<System.DateTime> BSendLetterDate { get; set; }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMSWin
{
    class OrderUtility
    {
        public void orderChangedCategoryCheck(string orderChangedCategory)
        {
            //switch (orderChangedCategory)
            //{
           　//陽菜ちゃん可愛い
            //カノジョ欲しい
            ///////////
            //}
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
            string strcmd = @"
                            SELECT  
                            [OrderPart].PartNumber,
                            [OrderPart].PartName,
                            [SupplierInfo].SupplierName,
                            [Order].DateRequired,
                            [SourceOrderList].Batch, 
                            [OrderPart].UnitPrice * ([SourceOrderList].Discount) as 'BatchUnitPrice',
                            [SourceOrderList].Qty,
                            sum([SourceOrderList].Batch*[OrderPart].UnitPrice * ([SourceOrderList].Discount)*[SourceOrderList].Qty) AS total
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
                            [SourceOrderList].Qty  with rollup
                            HAVING [order].OrderID = @orderID and 
                            (
	                            (
                            [SourceOrderList].Batch is null 
                            and
                            ([OrderPart].UnitPrice * ([SourceOrderList].Discount)) is null
                            and 
                            [OrderPart].PartName is null
                            and 
                            [SourceOrderList].Qty is null
	                            and 
                            [OrderPart].PartNumber is null
	                            )

                            or
	                            (
                            [SourceOrderList].Batch is not null 
                            and
                            ([OrderPart].UnitPrice * ([SourceOrderList].Discount)) is not null
                            and 
                            [OrderPart].PartName is not null
                            and 
                            [SourceOrderList].Qty is not null
                            and 
                            [OrderPart].PartNumber is not null
	                            )
                            )
                            ";
            //orderID = "20190912000001";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(SqlHelper.CreateParameter("@orderID", SqlDbType.VarChar, 14, orderID));
            DataTable a = SqlHelper.AdapterFill(strcmd, sqlParameters);
            dataGridView1.DataSource = a;
            return dataGridView1;
        }
        public DataGridView sendOrderFormForPblicUse(DataGridView dataGridView, string orderID)
        {
            string strcmd = @"
                            SELECT o.OrderID,op.PartNumber,op.PartName,supin.SupplierName,
                                   o.DateRequired,sol.Batch,(p.UnitPrice*(1-sol.Discount)) AS 'batchquantity',
	                               sol.Qty,SUM(sol.Batch*sol.Qty*(p.UnitPrice*(1-sol.Discount))) AS '小計'
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
                           o.DateRequired,sol.Batch,(p.UnitPrice*(1-sol.Discount)) ,
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
	                       (p.UnitPrice*(1-sol.Discount)) is not null and
	                       sol.Qty is not null and 
	                       sol.Batch*sol.Qty*(p.UnitPrice*(1-sol.Discount)) is not null 
	                       )";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(SqlHelper.CreateParameter("@orderID", SqlDbType.VarChar, 14, orderID));
            DataTable dataTable = SqlHelper.AdapterFill(strcmd, sqlParameters);
            dataGridView.DataSource = dataTable;
            return dataGridView;
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

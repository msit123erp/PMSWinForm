using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PMSWin.Dao
{
    public class SupplierReportDao
    {
        public DataTable ThreeMonBuyerUnit(string supplierAccountID)
        {
            string strcmd = @"select top(5) e.Name as '客戶姓名', sum(op.UnitPrice) as '銷售總金額' 
                                from [dbo].[Order] o
                                join [dbo].[OrderPart] op
                                on o.OrderID = op.OrderID
                                join [dbo].[Employee] e
                                on o.EmployeeID = e.EmployeeID
                                join [dbo].[Part] p
                                on op.[PartNumber] = p.[PartNumber]
                                join [dbo].[SupplierAccount] sa
                                on p.[SupplierCode] = sa.[SupplierCode]
                                where sa.[SupplierAccountID] = @SupplierAccountID
                                group by e.Name
                                order by sum(op.UnitPrice) desc";
            List<SqlParameter> lis = new List<SqlParameter>();
            lis.Add(SqlHelper.CreateParameter("@SupplierAccountID", SqlDbType.VarChar, 10, supplierAccountID));
            DataTable dt = SqlHelper.AdapterFill(strcmd, lis, CommandType.Text);

            return dt;
        }

        public DataTable ThreeMonPartUnit(string supplierAccountID)
        {
            string strcmd = @"select top(5) op.PartName as '商品名稱', sum(op.UnitPrice) as '銷售總金額'
                                from [dbo].[OrderPart] op
                                join [dbo].[Order] o
                                on op.OrderID = o.OrderID
                                join [dbo].[Part] p
                                on op.[PartNumber] = p.[PartNumber]
                                join [dbo].[SupplierAccount] sa
                                on p.[SupplierCode] = sa.[SupplierCode]
                                where sa.[SupplierAccountID] = @SupplierAccountID
                                group by op.PartName
                                order by sum(op.UnitPrice) desc";
            List<SqlParameter> lis = new List<SqlParameter>();
            lis.Add(SqlHelper.CreateParameter("@SupplierAccountID", SqlDbType.VarChar, 10, supplierAccountID));
            DataTable dt = SqlHelper.AdapterFill(strcmd, lis, CommandType.Text);

            return dt;
        }
    }
}

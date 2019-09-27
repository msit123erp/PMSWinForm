using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Dao
{
    public class BuyerReportDao
    {
        public DataTable EveryMonthSum(string employeeID)
        {
            string strcmd = @"select SUM([UnitPrice]) as '當月銷售總金額', cast(DATENAME(year,DateReleased) as nvarchar) +'/'+ right('00'+ cast(DATEPART(month,DateReleased) as nvarchar),2) as '年/月'
                                from [dbo].[OrderPart] op
                                join [dbo].[Order] p
                                on op.OrderID = p.OrderID
                                where p.[EmployeeID] = @EmployeeID
                                group by cast(DATENAME(year,DateReleased) as nvarchar) +'/'+ right('00'+ cast(DATEPART(month,DateReleased) as nvarchar),2)
                                order by cast(DATENAME(year,DateReleased) as nvarchar) +'/'+ right('00'+ cast(DATEPART(month,DateReleased) as nvarchar),2)";
            List<SqlParameter> lis = new List<SqlParameter>();
            lis.Add(SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, employeeID));
            DataTable dt = (SqlHelper.AdapterFill(strcmd, lis, CommandType.Text));

            return dt;
        }

        public DataTable PurchasingPCAV(string employeeID)
        {
            string strcmd = @"select cast(DATEPART(YEAR,[RequestDate]) as nvarchar) +'/'+ right('00'+ cast(datepart(month,[RequestDate]) as nvarchar),2) as '年/月', count(cast(DATEPART(YEAR,[RequestDate]) as nvarchar) +'/'+ right('00'+ cast(datepart(month,[RequestDate]) as nvarchar),2)) as '數量'
                                from [dbo].[OrderChanged] oc
                                join [dbo].[Order] o
                                on oc.[OrderID] = o.[OrderID]
                                where [OrderChangedCategoryCode] in ('P','C','A','V') and o.[EmployeeID] = @EmployeeID
                                group by cast(DATEPART(YEAR,[RequestDate]) as nvarchar) +'/'+ right('00'+ cast(datepart(month,[RequestDate]) as nvarchar),2)";
            List<SqlParameter> lis = new List<SqlParameter>();
            lis.Add(SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, employeeID));
            DataTable dt = (SqlHelper.AdapterFill(strcmd, lis, CommandType.Text));

            return dt;
        }

        public DataTable PurchasingECount(string employeeID)
        {
            string strcmd = @"select cast(DATEPART(YEAR,[RequestDate]) as nvarchar) +'/'+ right('00'+ cast(datepart(month,[RequestDate]) as nvarchar),2) as '年/月', count(cast(DATEPART(YEAR,[RequestDate]) as nvarchar) +'/'+ right('00'+ cast(datepart(month,[RequestDate]) as nvarchar),2)) as '數量'
                                from [dbo].[OrderChanged] oc
                                join [dbo].[Order] o
                                on oc.[OrderID] = o.[OrderID]
                                where [OrderChangedCategoryCode] = 'E' and o.[EmployeeID] = @EmployeeID
                                group by cast(DATEPART(YEAR,[RequestDate]) as nvarchar) +'/'+ right('00'+ cast(datepart(month,[RequestDate]) as nvarchar),2)";
            List<SqlParameter> lis = new List<SqlParameter>();
            lis.Add(SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, employeeID));
            DataTable dt = (SqlHelper.AdapterFill(strcmd, lis, CommandType.Text));

            return dt;
        }

        public DataTable TopTenSourceList()
        {
            string strcmd = @"select Top(9) s.[PartNumber]+'_'+cast([Batch] as nvarchar) as '項目', [Discount]*p.UnitPrice as '價格'
                                from [dbo].[SourceList] s
                                join Part p
                                on p.PartNumber = s.PartNumber
                                order by [DiscountBeginDate] desc";
            DataTable dt = SqlHelper.AdapterFill(strcmd);

            return dt;
        }
    }
}

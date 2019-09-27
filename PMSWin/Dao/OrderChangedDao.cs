using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Dao
{
    public class OrderChangedDao
    {
        public void UpdateOrderChanged(Model.OrderChanged oc)
        {
            string strCmd = @"INSERT INTO [dbo].[OrderChanged]([OrderID], [OrderChangedCategoryCode], [RequestDate], [RequesterRole], [RequesterID])
                                            VALUES(@OrderID, @OrderChangedCategoryCode, @RequestDate, @RequesterRole, @RequesterID)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@OrderID", SqlDbType.VarChar, 14, oc.OrderID));
            parameters.Add(SqlHelper.CreateParameter("@OrderChangedCategoryCode", SqlDbType.VarChar, 1, oc.OrderChangedCategoryCode));
            parameters.Add(SqlHelper.CreateParameter("@RequestDate", SqlDbType.DateTime, oc.RequestDate));
            parameters.Add(SqlHelper.CreateParameter("@RequesterRole", SqlDbType.VarChar, 1, oc.RequesterRole));
            parameters.Add(SqlHelper.CreateParameter("@RequesterID", SqlDbType.VarChar, 10, oc.RequesterID));
            SqlHelper.ExecuteNonQuery(strCmd, parameters);
        }
    }
}

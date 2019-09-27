using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Dao
{
    public class SourceOrderListDao
    {
        public Model.SourceOrderList FindSourceOrderListBySourceOrderListOID(int SourceOrderListOID)
        {
            string strCmd = @"SELECT [SourceOrderListOID], [OrderPartOID], [Batch], [Discount], [Qty], [PurchasingOrderDetailListOID]
                                                FROM [dbo].[SourceOrderList]
                                                where [SourceOrderListOID] = @SourceOrderListOID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@SourceOrderListOID", SqlDbType.Int, SourceOrderListOID));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            Model.SourceOrderList sol = this.GetSourceOrderList(dt.Rows[0]);
            return sol;
        }

        public List<Model.SourceOrderList> FindAll()
        {
            string strCmd = @"SELECT [SourceOrderListOID], [OrderPartOID], [Batch], [Discount], [Qty], [PurchasingOrderDetailListOID]
                                                FROM [dbo].[SourceOrderList]";
            DataTable dt = SqlHelper.AdapterFill(strCmd);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Model.SourceOrderList> sols = new List<Model.SourceOrderList>();
            foreach (DataRow dr in dt.Rows)
            {
                sols.Add(this.GetSourceOrderList(dr));
            }
            return sols;
        }

        public void Update(Model.SourceOrderList sol)
        {
            string strCmd = @"UPDATE [dbo].[SourceOrderList]
                                                SET [OrderPartOID] = @OrderPartOID, [Batch] = @Batch, [Discount] = @Discount,
                                                [Qty] = @Qty, [PurchasingOrderDetailListOID] = @PurchasingOrderDetailListOID
                                                WHERE SourceOrderListOID = @SourceOrderListOID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@OrderPartOID", SqlDbType.Int, sol.OrderPartOID));
            parameters.Add(SqlHelper.CreateParameter("@Batch", SqlDbType.Int, sol.Batch));
            SqlParameter sp = SqlHelper.CreateParameter("@Discount", SqlDbType.Decimal, sol.Discount);
            sp.Precision = 3;
            sp.Scale = 2;
            parameters.Add(sp);
            parameters.Add(SqlHelper.CreateParameter("@Qty", SqlDbType.Int, sol.Qty));
            if (sol.PurchasingOrderDetailListOID.HasValue)
            {
                parameters.Add(SqlHelper.CreateParameter("@PurchasingOrderDetailListOID", SqlDbType.Int, sol.PurchasingOrderDetailListOID));
            }
            else
            {
                parameters.Add(SqlHelper.CreateParameter("@PurchasingOrderDetailListOID", SqlDbType.Int, DBNull.Value));
            }
            parameters.Add(SqlHelper.CreateParameter("@SourceOrderListOID", SqlDbType.Int, sol.SourceOrderListOID));

            SqlHelper.ExecuteNonQuery(strCmd, parameters);
        }

        private Model.SourceOrderList GetSourceOrderList(DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }
            Model.SourceOrderList sol = new Model.SourceOrderList();
            sol.SourceOrderListOID = Convert.ToInt32(dr["SourceOrderListOID"]);
            sol.OrderPartOID = Convert.ToInt32(dr["OrderPartOID"]);
            sol.Batch = Convert.ToInt32(dr["Batch"]);
            sol.Discount = Convert.ToDecimal(dr["Discount"]);
            sol.Qty = Convert.ToInt32(dr["Qty"]);
            if (!SqlHelper.IsNull(dr["PurchasingOrderDetailListOID"]))
            {
                sol.PurchasingOrderDetailListOID = Convert.ToInt32(dr["PurchasingOrderDetailListOID"]);
            }
            return sol;
        }

    }
}

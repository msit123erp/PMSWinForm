using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Dao
{
    public class OrderPartDao
    {
        public Model.OrderPart FindOrderPartByOrderPartOID(int OrderPartOID)
        {
            string strCmd = @"SELECT [OrderPartOID], [OrderID], [PartNumber], [PartName], [PartSpec], [PartUnitName], [UnitPrice]
                                                FROM [dbo].[OrderPart]
                                                where [OrderPartOID] = @OrderPartOID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@OrderPartOID", SqlDbType.Int, OrderPartOID));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            Model.OrderPart op = this.GetOrderPart(dt.Rows[0]);
            return op;
        }

        public List<Model.OrderPart> FindAll()
        {
            string strCmd = @"SELECT [OrderPartOID], [OrderID], [PartNumber], [PartName], [PartSpec], [PartUnitName], [UnitPrice]
                                                FROM [dbo].[OrderPart]";
            DataTable dt = SqlHelper.AdapterFill(strCmd);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Model.OrderPart> ops = new List<Model.OrderPart>();
            foreach (DataRow dr in dt.Rows)
            {
                ops.Add(this.GetOrderPart(dr));
            }
            return ops;
        }

        private Model.OrderPart GetOrderPart(DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }
            Model.OrderPart op = new Model.OrderPart();
            op.OrderPartOID = Convert.ToInt32(dr["OrderPartOID"]);
            op.OrderID = Convert.ToString(dr["OrderID"]);
            op.PartNumber = Convert.ToString(dr["PartNumber"]);
            op.PartName = Convert.ToString(dr["PartName"]);
            op.PartSpec = Convert.ToString(dr["PartSpec"]);
            op.PartUnitName = Convert.ToString(dr["PartUnitName"]);
            if (!SqlHelper.IsNull(dr["UnitPrice"]))
            {
                op.UnitPrice = Convert.ToInt32(dr["UnitPrice"]);
            }
            return op;
        }
    }
}

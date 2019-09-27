using PMSWin.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin
{
    public class PurchasingOrderDao
    {
        /// //////////////////////////////////////////////////呈穎
        public DataTable GetPurchasingOrderByEmployeeID(string EmployeeID)
        {
            string strCmd = @"select po.PurchasingOrderOID, po.PurchasingOrderID, po.EmployeeID, po.POBeginDate
                                                 from PurchasingOrder po
												 join PurchasingOrderDetail pod
												 on po.PurchasingOrderID = pod.PurchasingOrderID
												 where not exists(
													select *
													from SourceOrderList sol
													where sol.PurchasingOrderDetailListOID = pod.PurchasingOrderDetailListOID
												 )												 
												 group by po.PurchasingOrderOID, po.PurchasingOrderID, po.EmployeeID, po.POBeginDate
												 having po.EmployeeID = @EmployeeID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, EmployeeID));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }


            return dt;
        }
        //////////////////////////////////////////////////呈穎
        public void InsertPurchasingOrderAndDetail(string EmployeeID, List<PurchasingOrderDetail> pods)
        {
            using (Transactions tx = new Transactions(600))
            {
                string strCmd = @"declare @PurchasingOrderID varchar(14)
                                                    set @PurchasingOrderID = (select convert(varchar, getdate(), 112) + right(format((select MAX(PurchasingOrderOID)+1 from PurchasingOrder with (TABLOCKX)), '00000#'),6))
                                                    insert into PurchasingOrder(PurchasingOrderID, EmployeeID, POBeginDate)
                                                    values(@PurchasingOrderID, @EmployeeID, GETDATE())
                                                    select @PurchasingOrderID";
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, EmployeeID));

                try
                {
                    string PurchasingOrderID = Convert.ToString(tx.ExecuteScalar(strCmd, parameters));
                    foreach (PurchasingOrderDetail pod in pods)
                    {
                        strCmd = @"insert into PurchasingOrderDetail(PurchasingOrderID, SourceListOID, Qty)
                                                values(@PurchasingOrderID, @SourceListOID, @Qty)";
                        parameters.Clear();
                        parameters.Add(SqlHelper.CreateParameter("@PurchasingOrderID", SqlDbType.VarChar, 14, PurchasingOrderID));
                        parameters.Add(SqlHelper.CreateParameter("@SourceListOID", SqlDbType.Int, pod.SourceListOID));
                        parameters.Add(SqlHelper.CreateParameter("@Qty", SqlDbType.Int, pod.Qty));
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
        }

        public DataTable FindPurchasingOrder(string PurchasingOrderID, DateTime? BeginDate, DateTime? EndDate, string EmployeeID = "")
        {
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();
            sb.Append(@"select po.PurchasingOrderID as '採購單編號', emp.Name as '採購員', convert(varchar, po.POBeginDate, 111) as '採購日期'
                                        from PurchasingOrder po
                                        Join Employee emp
                                        on po.EmployeeID = emp.EmployeeID where 1=1 ");
            if (!string.IsNullOrEmpty(PurchasingOrderID))
            {
                sb.Append(" and po.PurchasingOrderID = @PurchasingOrderID ");
                parameters.Add(SqlHelper.CreateParameter("@PurchasingOrderID", SqlDbType.VarChar, 14, PurchasingOrderID));
            }
            if (BeginDate != null || BeginDate.HasValue)
            {
                sb.Append(" and po.POBeginDate >= @BeginDate ");
                parameters.Add(SqlHelper.CreateParameter("@BeginDate", SqlDbType.DateTime, BeginDate.Value.ToShortDateString()));
            }
            if (EndDate != null || EndDate.HasValue)
            {
                sb.Append(" and po.POBeginDate <= @EndDate ");
                parameters.Add(SqlHelper.CreateParameter("@EndDate", SqlDbType.DateTime, EndDate.Value.AddDays(1).ToShortDateString()));
            }
            if (!string.IsNullOrEmpty(EmployeeID))
            {
                sb.Append(" and po.EmployeeID = @EmployeeID ");
                parameters.Add(SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, EmployeeID));
            }
            DataTable dt = SqlHelper.AdapterFill(sb.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            return dt;
        }

        public Model.PurchasingOrder FindPurchasingOrderByPurchasingOrderID(string PurchasingOrderID)
        {
            string strCmd = @"SELECT PurchasingOrderOID, PurchasingOrderID, EmployeeID, POBeginDate
                                        FROM PurchasingOrder
                                        where PurchasingOrderID = @PurchasingOrderID ";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@PurchasingOrderID", SqlDbType.VarChar, 14, PurchasingOrderID));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            Model.PurchasingOrder po = this.GetPurchasingOrder(dt.Rows[0]);
            return po;
        }

        private Model.PurchasingOrder GetPurchasingOrder(DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }
            Model.PurchasingOrder po = new Model.PurchasingOrder();
            po.PurchasingOrderOID = Convert.ToInt32(dr["PurchasingOrderOID"]);
            po.PurchasingOrderID = Convert.ToString(dr["PurchasingOrderID"]);
            po.EmployeeID = Convert.ToString(dr["EmployeeID"]);
            po.POBeginDate = Convert.ToDateTime(dr["POBeginDate"]);
            return po;
        }

    }
}

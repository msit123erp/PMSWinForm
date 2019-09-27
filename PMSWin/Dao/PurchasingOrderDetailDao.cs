using PMSWin.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Dao
{
    public class PurchasingOrderDetailDao
    {
        /// ///////////////////////////////////////////////////////////////呈穎

        public DataTable GetPurchasingOrderDetailByPurchasingOrderID(string PurchasingOrderID)
        {
            string strCmd = @"select pod.PurchasingOrderDetailListOID as '採購單明細識別碼',p.PartNumber as '料件編號', p.PartName as '料件品名', 
                                si.SupplierName as '供應商名稱', sl.Batch as '批量', p.UnitPrice AS '批量單價', 
                                pod.Qty as '採購數量', sl.Discount*sl.Batch*p.UnitPrice*pod.Qty AS '小計'
                                from PurchasingOrderDetail pod
                                JOIN [SourceList] sl
                                ON pod.SourceListOID = sl.SourceListOID and pod.PurchasingOrderID = @PurchasingOrderID
                                JOIN [Part] p
                                ON sl.PartNumber = p.PartNumber
                                JOIN [SupplierInfo] si
                                ON si.SupplierCode = p.SupplierCode 
                                where not EXISTS (
                                select *
                                from SourceOrderList sol
                                where sol.PurchasingOrderDetailListOID = pod.PurchasingOrderDetailListOID )";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@PurchasingOrderID", SqlDbType.VarChar,14, PurchasingOrderID));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            
            return dt;
        }
        /// ///////////////////////////////////////////////////////////////呈穎
        public PurchasingOrderDetail FindPurchasingOrderDetailBySourceListOID(int PurchasingOrderDetailListOID)
        {
            string strCmd = @"SELECT PurchasingOrderDetailListOID, PurchasingOrderID, SourceListOID, Qty
                                                FROM PurchasingOrderDetail
                                                where PurchasingOrderDetailListOID = @PurchasingOrderDetailListOID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@PurchasingOrderDetailListOID", SqlDbType.Int, PurchasingOrderDetailListOID));

            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            PurchasingOrderDetail pod = this.GetPurchasingOrderDetail(dt.Rows[0]);
            return pod;
        }

        public List<PurchasingOrderDetail> FindAll()
        {
            string strCmd = @"SELECT PurchasingOrderDetailListOID, PurchasingOrderID, SourceListOID, Qty
                                                FROM PurchasingOrderDetail";
            DataTable dt = SqlHelper.AdapterFill(strCmd);
            List<PurchasingOrderDetail> pods = new List<PurchasingOrderDetail>();
            foreach (DataRow dr in dt.Rows)
            {
                pods.Add(this.GetPurchasingOrderDetail(dr));
            }
            return pods;
        }

        private PurchasingOrderDetail GetPurchasingOrderDetail(DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }
            PurchasingOrderDetail pod = new PurchasingOrderDetail();
            pod.SourceListOID = Convert.ToInt32(dr["PurchasingOrderDetailListOID"]);
            pod.PurchasingOrderID = Convert.ToString(dr["PurchasingOrderID"]);
            pod.SourceListOID = Convert.ToInt32(dr["SourceListOID"]);
            pod.Qty = Convert.ToInt32(dr["Qty"]);
            return pod;
        }
    }
}

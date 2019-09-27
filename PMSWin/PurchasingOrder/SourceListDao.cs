using PMSWin.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.PurchasingOrder
{
    public class SourceListDao
    {
        public Model.SourceList FindSourceListBySourceListOID(int SourceListOID)
        {
            string strCmd = @"SELECT SourceListOID, PartNumber, Batch, Discount, 
                                                DiscountBeginDate, DiscountEndDate, CreateDate
                                                FROM SourceList
                                                where SourceListOID = @SourceListOID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@SourceListOID", SqlDbType.Int, SourceListOID));

            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            Model.SourceList sl = this.GetSourceList(dt.Rows[0]);
            return sl;
        }

        public DataTable FineSourceListForPOAddMain(List<int> sourceListOid)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select sl.SourceListOID, sl.PartNumber as '料件編號', p.PartName as '料件品名', si.SupplierName as '供應商名稱',  Batch as '批量', 
(p.UnitPrice * sl.Discount * Batch) as '批量單價'
from SourceList sl
join Part p
on sl.PartNumber = p.PartNumber
join SupplierInfo si
on si.SupplierCode = p.SupplierCode
where SourceListOID in (");
            for (int i = 0; i < sourceListOid.Count; i++)
            {
                if (i < sourceListOid.Count - 1)
                {
                    sb.Append($"@SourceListOID{i}, ");
                }
                else
                {
                    sb.Append($"@SourceListOID{i}");
                }
                parameters.Add(SqlHelper.CreateParameter($"@SourceListOID{i}", SqlDbType.Int, sourceListOid[i]));
            }
            sb.Append(")");
            DataTable dt = SqlHelper.AdapterFill(sb.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            return dt;
        }

        public List<Model.SourceList> FindSourceListByPartNumber(string PartNumber)
        {
            string strCmd = @"SELECT SourceListOID, PartNumber, Batch, Discount, 
                                                DiscountBeginDate, DiscountEndDate, CreateDate
                                                FROM SourceList
                                                where PartNumber = @PartNumber";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@PartNumber", SqlDbType.NVarChar, 10, PartNumber));

            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Model.SourceList> sourceLists = new List<Model.SourceList>();
            foreach (DataRow dr in dt.Rows)
            {
                sourceLists.Add(this.GetSourceList(dr));
            }
            return sourceLists;
        }

        public List<Model.SourceList> FindAll()
        {
            string strCmd = @"SELECT SourceListOID, PartNumber, Batch, Discount, 
                                                DiscountBeginDate, DiscountEndDate, CreateDate
                                                FROM SourceList";
            DataTable dt = SqlHelper.AdapterFill(strCmd);
            List<Model.SourceList> sls = new List<Model.SourceList>();
            foreach (DataRow dr in dt.Rows)
            {
                sls.Add(this.GetSourceList(dr));
            }
            return sls;
        }

        private Model.SourceList GetSourceList(DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }
            Model.SourceList sl = new Model.SourceList();
            sl.SourceListOID = Convert.ToInt32(dr["SourceListOID"]);
            sl.PartNumber = Convert.ToString(dr["PartNumber"]);
            sl.Batch = Convert.ToInt32(dr["Batch"]);
            sl.Discount = Convert.ToDecimal(dr["Discount"]);
            if (!SqlHelper.IsNull(dr["DiscountBeginDate"]))
            {
                sl.DiscountBeginDate = Convert.ToDateTime(dr["DiscountBeginDate"]);
            }
            if (!SqlHelper.IsNull(dr["DiscountEndDate"]))
            {
                sl.DiscountEndDate = Convert.ToDateTime(dr["DiscountEndDate"]);
            }
            if (!SqlHelper.IsNull(dr["CreateDate"]))
            {
                sl.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
            }
            return sl;
        }
    }
}

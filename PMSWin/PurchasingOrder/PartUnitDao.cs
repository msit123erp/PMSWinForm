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
    public class PartUnitDao
    {
        public PartUnit FindPartUnitByPartUnitOID(int PartUnitOID)
        {
            string strCmd = @"SELECT PartUnitOID, PartUnitName
                                                FROM dbo.PartUnit
                                                where PartUnitOID = @PartUnitOID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@PartUnitOID", SqlDbType.Int, PartUnitOID));

            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            PartUnit pu = this.GetPartUnit(dt.Rows[0]);
            return pu;
        }

        public List<PartUnit> FindAll()
        {
            string strCmd = @"SELECT PartUnitOID, PartUnitName
                                                FROM dbo.PartUnit";
            DataTable dt = SqlHelper.AdapterFill(strCmd);
            List<PartUnit> pus = new List<PartUnit>();
            foreach (DataRow dr in dt.Rows)
            {
                pus.Add(this.GetPartUnit(dr));
            }
            return pus;
        }

        private PartUnit GetPartUnit(DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }
            PartUnit pu = new PartUnit();
            pu.PartUnitOID = Convert.ToInt32(dr["PartUnitOID"]);
            pu.PartUnitName = Convert.ToString(dr["PartUnitName"]);
            return pu;
        }
    }
}

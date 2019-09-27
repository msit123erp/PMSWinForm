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
    public class CompanyInfoDao
    {
        public CompanyInfo FindCompanyInfoByCompanyCode(string CompanyCode)
        {
            string strCmd = @"select CompanyInfoOID, CompanyCode, CompanyName, TaxID, Email, Tel, [Address]
                                                from dbo.CompanyInfo
                                                where CompanyCode = @CompanyCode";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@CompanyCode", SqlDbType.NVarChar, 6, CompanyCode));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            CompanyInfo ci = this.GetCompanyInfo(dt.Rows[0]);
            return ci;
        }

        public List<CompanyInfo> FindAll()
        {
            string strCmd = @"select CompanyInfoOID, CompanyCode, CompanyName, TaxID, Email, Tel, [Address]
                                                from dbo.CompanyInfo";
            DataTable dt = SqlHelper.AdapterFill(strCmd);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<CompanyInfo> cis = new List<CompanyInfo>();
            foreach (DataRow dr in dt.Rows)
            {
                cis.Add(this.GetCompanyInfo(dr));
            }
            return cis;
        }

        private CompanyInfo GetCompanyInfo(DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }
            CompanyInfo ci = new CompanyInfo();
            ci.CompanyInfoOID = Convert.ToInt32(dr["CompanyInfoOID"]);
            ci.CompanyCode = Convert.ToString(dr["CompanyCode"]);
            ci.CompanyName = Convert.ToString(dr["CompanyName"]);
            ci.TaxID = Convert.ToString(dr["TaxID"]);
            ci.Email = Convert.ToString(dr["Email"]);
            ci.Tel = Convert.ToString(dr["Tel"]);
            ci.Address = Convert.ToString(dr["Address"]);
            return ci;
        }
    }
}

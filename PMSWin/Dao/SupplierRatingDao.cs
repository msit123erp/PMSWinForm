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
    public class SupplierRatingDao
    {
        public SupplierRating FindSupplierRatingBySupplierRatingOID(Nullable<int> SupplierRatingOID)
        {
            if (!SupplierRatingOID.HasValue)
            {
                return null;
            }
            string strCmd = @"select SupplierRatingOID, RatingName
                                                from dbo.SupplierRating
                                                where SupplierRatingOID = @SupplierRatingOID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@SupplierRatingOID", SqlDbType.Int, SupplierRatingOID));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            SupplierRating sr = this.GetSupplierRating(dt.Rows[0]);
            return sr;
        }

        public List<SupplierRating> FindAll()
        {
            string strCmd = @"select SupplierRatingOID, RatingName
                                                from dbo.SupplierRating";
            DataTable dt = SqlHelper.AdapterFill(strCmd);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<SupplierRating> srs = new List<SupplierRating>();
            foreach (DataRow dr in dt.Rows)
            {
                srs.Add(this.GetSupplierRating(dr));
            }
            return srs;
        }

        private SupplierRating GetSupplierRating(DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }
            SupplierRating sr = new SupplierRating();
            sr.SupplierRatingOID = Convert.ToInt32(dr["SupplierRatingOID"]);
            sr.RatingName = Convert.ToString(dr["RatingName"]);
            return sr;
        }
    }
}

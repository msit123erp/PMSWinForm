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
    public class PartDao
    {
        /// <summary>
        /// 挑選料件
        /// </summary>
        /// <param name="PartNumber">料件編號</param>
        /// <returns></returns>
        public Model.Part FindPartByPartNumber(string PartNumber)
        {
            string strCmd = @"SELECT PartOID, PartNumber, PartName, PartSpec, SupplierCode, PartUnitOID, 
                                        UnitPrice, CreatedDate, PictureAdress, PictureDescription
                                        FROM Part
                                        where PartNumber = @PartNumber";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@PartNumber", SqlDbType.NVarChar, 10, PartNumber));

            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            Model.Part pt = this.GetPart(dt.Rows[0]);
            return pt;
        }

        public List<Model.Part> FindAll()
        {
            string strCmd = @"SELECT PartOID, PartNumber, PartName, PartSpec, SupplierCode, PartUnitOID, 
                                        UnitPrice, CreatedDate, PictureAdress, PictureDescription
                                        FROM Part";
            DataTable dt = SqlHelper.AdapterFill(strCmd);
            List<Model.Part> parts = new List<Model.Part>();
            foreach (DataRow dr in dt.Rows)
            {
                parts.Add(this.GetPart(dr));
            }
            return parts;
        }

        /// <summary>
        /// 挑選料件
        /// </summary>
        /// <param name="PartNumber">料件編號</param>
        /// <param name="PartName">料件品名</param>
        /// <returns></returns>
        public DataTable FindPartForPickup(string PartNumber, string PartName)
        {
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();
            sb.Append(@"select PartNumber '料件編號', PartName '料件品名', PartSpec '料件規格', UnitPrice '單價', si.SupplierName '供應商名稱'
                                       from Part p
                                       join SupplierInfo si
                                      on p.SupplierCode = si.SupplierCode
                                      where 1=1 ");
            if (!string.IsNullOrEmpty(PartNumber))
            {
                sb.Append(" and PartNumber like @PartNumber ");
                parameters.Add(SqlHelper.CreateParameter("@PartNumber", SqlDbType.NVarChar, 10, $"%{PartNumber}%"));
            }
            if (!string.IsNullOrEmpty(PartName))
            {
                sb.Append(" and PartName like @PartName ");
                parameters.Add(SqlHelper.CreateParameter("@PartName", SqlDbType.NVarChar, 30, $"%{PartName}%"));
            }
            DataTable dt = SqlHelper.AdapterFill(sb.ToString(), parameters);
            return dt;
        }

        private Model.Part GetPart(DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }
            Model.Part pt = new Model.Part();
            pt.PartOID = Convert.ToInt32(dr["PartOID"]);
            pt.PartNumber = Convert.ToString(dr["PartNumber"]);
            pt.PartName = Convert.ToString(dr["PartName"]);
            pt.PartSpec = Convert.ToString(dr["PartSpec"]);
            pt.SupplierCode = Convert.ToString(dr["SupplierCode"]);
            pt.PartUnitOID = Convert.ToInt32(dr["PartUnitOID"]);
            if (!SqlHelper.IsNull(dr["UnitPrice"]))
            {
                pt.UnitPrice = Convert.ToInt32(dr["UnitPrice"]);
            }
            pt.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
            pt.PictureAdress = Convert.ToString(dr["PictureAdress"]);
            pt.PictureDescription = Convert.ToString(dr["PictureDescription"]);
            return pt;
        }
    }
}

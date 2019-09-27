using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMSWin.Model;
using System.Data;
using System.Data.SqlClient;
using PMSWin.Part;
using System.Configuration;

namespace PMSWin.Dao
{
    public static class UsePartFormMethod
    {
        internal static PartForm Pf;
    }

    public class PartDao
    {
        public DataTable FindPartByPartNumberAndPartNameOrSupplierName(string PartNumber, string PartName, string SupplierName)
        {
            string strCmd = @"Select SupplierInfo.SupplierName as'供應商名稱', Part.[SupplierCode] as'供應商代碼',
                              [PartName] as'料件名稱',[PartNumber] as'料件編號',[PartSpec] as '料件規格',
                              PartUnit.PartUnitName as'料件單位',[UnitPrice] as'料件單價',
                              [CreatedDate] as'建檔日期',PartOID,PartUnit.PartUnitOID
                              from Part
                              join SupplierInfo on Part.[SupplierCode]=SupplierInfo.SupplierCode
                              join PartUnit on Part.PartUnitOID = PartUnit.PartUnitOID
                              where PartNumber=@PartNumber
                              and PartName=@PartName 
                              or SupplierInfo.SupplierName =@SupplierName";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@PartNumber", SqlDbType.NVarChar, 10, PartNumber));
            parameters.Add(SqlHelper.CreateParameter("@PartName", SqlDbType.NVarChar, 30, PartName));
            parameters.Add(SqlHelper.CreateParameter("@SupplierName", SqlDbType.NVarChar, 30, SupplierName));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            return dt;

        }

        //public PMSWin.Model.Part GetPart(DataRow dr)
        //{
        //    if (dr == null)
        //    {
        //        return null;
        //    }
        //    PMSWin.Model.Part part = new PMSWin.Model.Part();

        //    part.PartNumber = Convert.ToString(dr["PartNumber"]);
        //    part.PartName = Convert.ToString(dr["PartName"]);
        //    part.PartSpec = Convert.ToString(dr["PartSpec"]);
        //    part.SupplierCode = Convert.ToString(dr["SupplierCode"]);
        //    part.UnitPrice = Convert.ToInt32(dr["UnitPrice"]);

        //    return part;
        //}
        public DataTable FindSupplierName()
        {
            string strCmd = @"Select SupplierInfo.SupplierName as'供應商名稱',
                              [SupplierCode] as'供應商代碼'
                              from SupplierInfo";


            List<SqlParameter> parameters = new List<SqlParameter>();
            //parameters.Add(SqlHelper.CreateParameter("@SupplierName", SqlDbType.NVarChar, 30, SupplierName));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            return dt;
        }
        public DataTable FindSupplierCodeBySupplierName(string SupplierName)
        {
            string strCmd = @"Select [SupplierCode] as'供應商代碼'
                              from SupplierInfo
                              where SupplierName=@SupplierName";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@SupplierName", SqlDbType.NVarChar, 30, SupplierName));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            return dt;
        }
        public DataTable FindPartUnitName()
        {
            string strCmd = @"Select PartUnitName as'物料單位',
                              PartUnitOID as'物料單位編號'
                              from PartUnit";
            List<SqlParameter> parameters = new List<SqlParameter>();
            //parameters.Add(SqlHelper.CreateParameter("@PartUnitName", SqlDbType.NVarChar, 6, PartUnitName));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            return dt;
        }

        public bool Modifly(string SupplierName, string SupplierCode, string PartName, string PartNumber, string PartSpec, string PartUnitName, int UnitPrice, int PartOID, int PartUnitOID)
        {
            using (Transactions st = new Transactions(600))
            {
                string strCmd = @" Update Part 
                                   Set SupplierCode = @SupplierCode ,
                                   PartName = @PartName,PartNumber=@PartNumber,
                                   PartSpec = @PartSpec , UnitPrice = @UnitPrice,
                                   PartUnitOID = @PartUnitOID
                                   where PartOID = @PartOID";
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(SqlHelper.CreateParameter("@PartNumber", SqlDbType.NVarChar, 10, PartNumber));
                parameters.Add(SqlHelper.CreateParameter("@SupplierCode", SqlDbType.NVarChar, 6, SupplierCode));
                parameters.Add(SqlHelper.CreateParameter("@PartName", SqlDbType.NVarChar, 30, PartName));
                parameters.Add(SqlHelper.CreateParameter("@PartSpec", SqlDbType.NVarChar, 30, PartSpec));
                parameters.Add(SqlHelper.CreateParameter("@UnitPrice", SqlDbType.Int, UnitPrice));
                parameters.Add(SqlHelper.CreateParameter("@PartUnitOID", SqlDbType.Int, PartUnitOID));
                parameters.Add(SqlHelper.CreateParameter("@PartOID", SqlDbType.Int, PartOID));
                int x = SqlHelper.ExecuteNonQuery(strCmd, parameters);
                if (x == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }



        }
        public bool Insert(string SupplierName, string SupplierCode, string PartName, string PartNumber, string PartSpec, string PartUnitName, int UnitPrice, int PartUnitOID)
        {
            using (Transactions st = new Transactions(600))
            {
                string strCmd = @" insert into[dbo].[Part]
                                ([PartNumber],[PartName],[PartSpec],[SupplierCode],
                                [PartUnitOID],[UnitPrice],[CreatedDate])
                                values(@PartNumber,@PartName,@PartSpec,@SupplierCode,
                                @PartUnitOID,@UnitPrice,getdate())";
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(SqlHelper.CreateParameter("@PartNumber", SqlDbType.NVarChar, 10, PartNumber));
                parameters.Add(SqlHelper.CreateParameter("@SupplierCode", SqlDbType.NVarChar, 6, SupplierCode));
                parameters.Add(SqlHelper.CreateParameter("@PartName", SqlDbType.NVarChar, 30, PartName));
                parameters.Add(SqlHelper.CreateParameter("@PartSpec", SqlDbType.NVarChar, 30, PartSpec));
                parameters.Add(SqlHelper.CreateParameter("@UnitPrice", SqlDbType.Int, UnitPrice));
                parameters.Add(SqlHelper.CreateParameter("@PartUnitOID", SqlDbType.Int, PartUnitOID));
                int x = SqlHelper.ExecuteNonQuery(strCmd, parameters);
                if (x == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public bool Delete(string PartName)
        {
            string strCmd = @"select part.PartName
                              from Part
                              delete 
                              from Part
                              where PartName= @PartName ";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@PartName", SqlDbType.NVarChar, 30, PartName));
            int x = SqlHelper.ExecuteNonQuery(strCmd, parameters);
            if (x == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
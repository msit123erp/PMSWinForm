using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMSWin.SourceList;

namespace PMSWin.Dao
{
    public static class UseSourceListForm
    {
        internal static SourceListForm SL;
    }
    public class SourceListDao
    {
        public DataTable GetSourceList(string SupplierName,string PartName, string PartNumber)//設定條件
        { //條件敘述
            string strCmd = @"select SourceListOID,SupplierName,sup.SupplierCode,PartName,s.PartNumber,PartUnitName,UnitPrice,Batch,Discount,DiscountBeginDate,DiscountEndDate,PartSpec,CreateDate
                                                from Part p
                                                join SourceList s
                                                on s.PartNumber=p.PartNumber
                                                join [dbo].[SupplierInfo]sup
                                                on p.SupplierCode = sup.SupplierCode
                                                join [dbo].[PartUnit]px
                                                on p.PartUnitOID=px.PartUnitOID
                                                where (s.PartNumber = @PartNumber and PartName=@PartName)or SupplierName = @SupplierName";
            //設定參數
            List<SqlParameter> parameters = new List<SqlParameter>(); /*or SupplierName = @SupplierName*/
            parameters.Add(SqlHelper.CreateParameter("@PartNumber", SqlDbType.NVarChar, 10, PartNumber));
            parameters.Add(SqlHelper.CreateParameter("@PartName", SqlDbType.NVarChar, 30, PartName));
            parameters.Add(SqlHelper.CreateParameter("@SupplierName", SqlDbType.NVarChar, 30, SupplierName));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0) //如果沒有傳筆數 return null
            {
                return null;
            }
            return dt;
        }

        public DataTable GetAutoSourceList()//設定條件
        { //條件敘述
            string strCmd = @"select SourceListOID,SupplierName,sup.SupplierCode,PartName,s.PartNumber,PartUnitName,UnitPrice,Batch,Discount,DiscountBeginDate,DiscountEndDate,PartSpec,CreateDate
                                                from Part p
                                                join SourceList s
                                                on s.PartNumber=p.PartNumber
                                                join [dbo].[SupplierInfo]sup
                                                on p.SupplierCode = sup.SupplierCode
                                                join [dbo].[PartUnit]px
                                                on p.PartUnitOID=px.PartUnitOID
                                               ";
            //設定參數
            List<SqlParameter> parameters = new List<SqlParameter>(); /*or SupplierName = @SupplierName*/
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0) //如果沒有傳筆數 return null
            {
                return null;
            }
            return dt;
        }

        public bool UpdateSourceList(int SourceListOID,int Batch, Decimal Discount,string DiscountBeginDate,string DiscountEndDate)//設定條件
        { //條件敘述
            string strCmd = @"update [dbo].[SourceList]
                              set Batch=@Batch,[Discount]=@Discount,DiscountBeginDate = @DiscountBeginDate,DiscountEndDate = @DiscountEndDate
                               where SourceListOID=@SourceListOID";
            //設定參數
            List<SqlParameter> parameters = new List<SqlParameter>(); /*,DiscountBeginDate = @DiscountBeginDate,DiscountEndDate = @DiscountEndDate*/
            parameters.Add(SqlHelper.CreateParameter("@SourceListOID", SqlDbType.Int, SourceListOID));
            parameters.Add(SqlHelper.CreateParameter("@Batch", SqlDbType.Int, Batch));
            parameters.Add(SqlHelper.CreateParameter("@Discount", SqlDbType.Decimal, Discount));
            parameters.Add(SqlHelper.CreateParameter("@DiscountBeginDate", SqlDbType.DateTime, DiscountBeginDate));
            parameters.Add(SqlHelper.CreateParameter("@DiscountEndDate", SqlDbType.DateTime, DiscountEndDate));
            int x= SqlHelper.ExecuteNonQuery(strCmd, parameters); //
            if (x == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
        public DataTable GetPart(string PartName)
        {
            //條件敘述
            string strCmd = @"select PartName,PartSpec,SupplierName,p.PartNumber,PartUnitName,UnitPrice
                                                from Part p
                                                join SourceList s
                                                on s.PartNumber=p.PartNumber
                                                join [dbo].[SupplierInfo]sup
                                                on p.SupplierCode = sup.SupplierCode
                                                join [dbo].[PartUnit]px
                                                on p.PartUnitOID=px.PartUnitOID
                                                where PartName=@PartName";
            //設定參數
            List<SqlParameter> parameters = new List<SqlParameter>(); /*or SupplierName = @SupplierName*/
            parameters.Add(SqlHelper.CreateParameter("@PartName", SqlDbType.NVarChar, 30, PartName));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0) //如果沒有傳筆數 return null
            {
                return null;
            }
            return dt;
        }
        //新增貨源清單
        public bool AddSourceList(string PartNumber, int Batch, Decimal Discount, string DiscountBeginDate, string DiscountEndDate, string CreateDate)//設定條件
        { //條件敘述
            string strCmd = @"insert SourceList(PartNumber,Batch,Discount,DiscountBeginDate,DiscountEndDate,CreateDate)
                            values(@PartNumber,@Batch,@Discount,@DiscountBeginDate,@DiscountEndDate,@CreateDate)";
            //設定參數
            List<SqlParameter> parameters = new List<SqlParameter>(); /*,DiscountBeginDate = @DiscountBeginDate,DiscountEndDate = @DiscountEndDate*/
            parameters.Add(SqlHelper.CreateParameter("@PartNumber", SqlDbType.NVarChar,10, PartNumber));
            parameters.Add(SqlHelper.CreateParameter("@Batch", SqlDbType.Int, Batch));
            parameters.Add(SqlHelper.CreateParameter("@Discount", SqlDbType.Decimal, Discount));
            parameters.Add(SqlHelper.CreateParameter("@DiscountBeginDate", SqlDbType.DateTime, DiscountBeginDate));
            parameters.Add(SqlHelper.CreateParameter("@DiscountEndDate", SqlDbType.DateTime, DiscountEndDate));
            parameters.Add(SqlHelper.CreateParameter("@CreateDate", SqlDbType.DateTime, CreateDate));
            int x = SqlHelper.ExecuteNonQuery(strCmd, parameters); //
            if (x == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool DeleteSourceList(int SourceListOID1)//刪除貨源清單
        {
            //條件敘述
            string strCmd = @"delete from SourceList
                              where SourceListOID=@SourceListOID1";
            //設定參數
            List<SqlParameter> parameters = new List<SqlParameter>(); /*or SupplierName = @SupplierName*/
            parameters.Add(SqlHelper.CreateParameter("@SourceListOID1", SqlDbType.Int, SourceListOID1));
            //DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            int x = SqlHelper.ExecuteNonQuery(strCmd, parameters); //
            if (x == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public DataTable GetPartName()//抓料件名稱
        {
            //條件敘述
            string strCmd = @"select PartName from Part ";                       
            //設定參數
            List<SqlParameter> parameters = new List<SqlParameter>(); /*or SupplierName = @SupplierName*/
            
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0) //如果沒有傳筆數 return null
            {
                return null;
            }
            return dt;
        }
        public DataTable GetSupplierInfo()
        {
            string strCmd = @"select SupplierName,SupplierCode from SupplierInfo ";
            //設定參數
            List<SqlParameter> parameters = new List<SqlParameter>(); /*or SupplierName = @SupplierName*/

            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0) //如果沒有傳筆數 return null
            {
                return null;
            }
            return dt;

        }
        public DataTable AddCheckSourceList(string PartNumber,int Batch, Decimal Discount, string DiscountBeginDate, string DiscountEndDate)//設定條件
        { //條件敘述
            string strCmd = @"select * from[dbo].[SourceList]
                            where[PartNumber]=@PartNumber and[Batch]=@Batch and[Discount]=@Discount and[DiscountBeginDate]=@DiscountBeginDate and[DiscountEndDate]=@DiscountEndDate";
            //設定參數
            List<SqlParameter> parameters = new List<SqlParameter>(); /*or SupplierName = @SupplierName*/
            parameters.Add(SqlHelper.CreateParameter("@PartNumber", SqlDbType.NVarChar, 10, PartNumber));
            parameters.Add(SqlHelper.CreateParameter("@Batch", SqlDbType.Int, Batch));
            parameters.Add(SqlHelper.CreateParameter("@Discount", SqlDbType.Decimal, Discount));
            parameters.Add(SqlHelper.CreateParameter("@DiscountBeginDate", SqlDbType.DateTime, DiscountBeginDate));
            parameters.Add(SqlHelper.CreateParameter("@DiscountEndDate", SqlDbType.DateTime, DiscountEndDate));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0) //如果沒有傳筆數 return null
            {
                return null;
            }
            return dt;
        }


    }
}

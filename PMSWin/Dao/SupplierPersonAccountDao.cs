using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Dao
{
    public class SupplierPersonAccountDao
    {
        //查詢原始資料
        public DataTable FindSupplierPersonAccount()
        {
            string strcmd = @"select si.SupplierName, sa.ContactName, sa.Email, sa.Mobile, sa.Tel
                                from [dbo].[SupplierAccount] sa
                                join [dbo].[SupplierInfo] si
                                on sa.SupplierCode = si.SupplierCode
                                where sa.SupplierAccountID = 'S000000001'";
            DataTable dt = SqlHelper.AdapterFill(strcmd);

            return dt;
        }

        //更新個人資料
        public int UpdateSupplierPersonAccount(string contactName, string email, string mobile, string tel)
        {
            string strcmd = @"update [dbo].[SupplierAccount]
                                set [ContactName] = @ContactName, [Email] = @Email, [Mobile] = @Mobile, [Tel] = @Tel, [ModifiedDate] = GETDATE()
                                where [SupplierAccountID] = 'S000000001'";
            List<SqlParameter> lis = new List<SqlParameter>();
            lis.Add(SqlHelper.CreateParameter("@ContactName", SqlDbType.NVarChar, 30, contactName));
            lis.Add(SqlHelper.CreateParameter("@Email", SqlDbType.NVarChar, 64, email));
            lis.Add(SqlHelper.CreateParameter("@Mobile", SqlDbType.VarChar, 30, mobile));
            lis.Add(SqlHelper.CreateParameter("@Tel", SqlDbType.VarChar, 30, tel));

            int result = SqlHelper.ExecuteNonQuery(strcmd,lis, CommandType.Text);
            return result;
        }

        //============================================================================
        //公司基本資料查詢
        public DataTable FindSupplierCompany()
        {
            string strcmd = @"select sa.[SupplierAccountID],[SupplierName],[TaxID],si.[Tel],si.[Email],si.[Address]
                                from [dbo].[SupplierInfo] si
                                join [dbo].[SupplierAccount] sa
                                on si.SupplierCode = sa.SupplierCode
                                where sa.SupplierAccountID = 'S000000001'";
            DataTable dt = SqlHelper.AdapterFill(strcmd);
            return dt;
        }

        //修改公司基本資料
        public int UpdateSupplierCompany(string supplierName, string taxID, string tel, string email, string address)
        {
            string strcmd = @"update [dbo].[SupplierInfo]
                                set [SupplierName] = @SupplierName, [TaxID] = @TaxID, [Tel] = @Tel, [Email] = @Email, [Address] = @Address
                                where [SupplierCode] = (select sa.[SupplierCode]
                                from [dbo].[SupplierInfo] si
                                join [dbo].[SupplierAccount] sa
                                on si.SupplierCode = sa.SupplierCode
                                where sa.SupplierAccountID = 'S000000001')";
            List<SqlParameter> lis = new List<SqlParameter>();
            lis.Add(SqlHelper.CreateParameter("@SupplierName", SqlDbType.NVarChar, 30, supplierName));
            lis.Add(SqlHelper.CreateParameter("@TaxID", SqlDbType.VarChar, 10, taxID));
            lis.Add(SqlHelper.CreateParameter("@Tel", SqlDbType.VarChar, 30, tel));
            lis.Add(SqlHelper.CreateParameter("@Email", SqlDbType.VarChar, 64, email));
            lis.Add(SqlHelper.CreateParameter("@Address", SqlDbType.NVarChar, 256, address));

            int result = SqlHelper.ExecuteNonQuery(strcmd, lis, CommandType.Text);
            return result;
        }
    }
}

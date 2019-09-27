using PMSWin.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMSWin.PurchasingOrder
{
    public class SupplierAccountDao
    {
        public Model.SupplierAccount FindSupplierAccountBySupplierAccountID(string SupplierAccountID)
        {
            string strCmd = @"select SupplierAccountOID, SupplierAccountID, PasswordHash, PasswordSalt, 
                                                              ContactName, Email, Address, Mobile, Tel, SupplierCode, 
                                                              AccountStatus, CreateDate, CreatorEmployeeID, ModifiedDate, 
                                                              SASendLetterState, SASendLetterDate
                                               from SupplierAccount
                                               where SupplierAccountID = @SupplierAccountID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@SupplierAccountID", SqlDbType.VarChar, 10, SupplierAccountID));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            Model.SupplierAccount supplier = this.GetSupplierAccount(dt.Rows[0]);
            return supplier;
        }

        public Model.SupplierAccount FindSupplierAccountBySupplierAccountOID(int SupplierAccountOID)
        {
            string strCmd = @"select SupplierAccountOID, SupplierAccountID, PasswordHash, PasswordSalt, 
                                                              ContactName, Email, Address, Mobile, Tel, SupplierCode, 
                                                              AccountStatus, CreateDate, CreatorEmployeeID, ModifiedDate, 
                                                              SASendLetterState, SASendLetterDate
                                               from SupplierAccount
                                               where SupplierAccountOID = @SupplierAccountOID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@SupplierAccountOID", SqlDbType.Int, SupplierAccountOID));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            Model.SupplierAccount supplier = this.GetSupplierAccount(dt.Rows[0]);
            return supplier;
        }

        public Model.SupplierAccount FindSupplierAccountBySupplierCode(string SupplierCode)
        {
            string strCmd = @"select SupplierAccountOID, SupplierAccountID, PasswordHash, PasswordSalt, 
                                                              ContactName, Email, Address, Mobile, Tel, SupplierCode, 
                                                              AccountStatus, CreateDate, CreatorEmployeeID, ModifiedDate, 
                                                              SASendLetterState, SASendLetterDate
                                               from SupplierAccount
                                               where SupplierCode = @SupplierCode";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@SupplierCode", SqlDbType.NVarChar, 6, SupplierCode));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            Model.SupplierAccount supplier = this.GetSupplierAccount(dt.Rows[0]);
            return supplier;
        }

        public int CreateSupplierAccount(string passwordHash, string passwordSalt, string contactName, string email, string address, string mobile, string tel, string supplierCode, string accountStatus, DateTime createDate, string creatorEmployeeID)
        {
            int SupplierAccountOID = -1;
            using (Transactions ts = new Transactions(600))
            {
                string strCmd = @"INSERT INTO SupplierAccount(SupplierAccountID, PasswordHash, PasswordSalt, 
                                                                                                              ContactName, Email, Address, Mobile, Tel, SupplierCode, 
                                                                                                              AccountStatus, CreateDate, CreatorEmployeeID)
                                                    VALUES((select 'S' + right(format((select MAX(SupplierAccountOID)+1 from SupplierAccount with (TABLOCKX)), '00000000#'), 9)), 
                                                                     @PasswordHash, @PasswordSalt, @ContactName, @Email, @Address, @Mobile, 
                                                                     @Tel, @SupplierCode, @AccountStatus, @CreateDate, @CreatorEmployeeID)";
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(SqlHelper.CreateParameter("@PasswordHash", SqlDbType.VarChar, 128, passwordHash));
                parameters.Add(SqlHelper.CreateParameter("@PasswordSalt", SqlDbType.VarChar, 68, passwordSalt));
                parameters.Add(SqlHelper.CreateParameter("@ContactName", SqlDbType.NVarChar, 30, contactName));
                parameters.Add(SqlHelper.CreateParameter("@Email", SqlDbType.NVarChar, 64, email));
                parameters.Add(SqlHelper.CreateParameter("@Address", SqlDbType.NVarChar, 256, address));
                parameters.Add(SqlHelper.CreateParameter("@Mobile", SqlDbType.VarChar, 30, mobile));
                parameters.Add(SqlHelper.CreateParameter("@Tel", SqlDbType.VarChar, 30, tel));
                parameters.Add(SqlHelper.CreateParameter("@SupplierCode", SqlDbType.NVarChar, 6, supplierCode));
                parameters.Add(SqlHelper.CreateParameter("@AccountStatus", SqlDbType.VarChar, 1, accountStatus));
                parameters.Add(SqlHelper.CreateParameter("@SupplierCode", SqlDbType.NVarChar, 6, supplierCode));
                parameters.Add(SqlHelper.CreateParameter("@CreateDate", SqlDbType.DateTime, createDate));
                parameters.Add(SqlHelper.CreateParameter("@CreatorEmployeeID", SqlDbType.VarChar, 10, creatorEmployeeID));

                try
                {
                    ts.ExecuteNonQuery(strCmd, parameters);
                    strCmd = @"SELECT IDENT_CURRENT ('SupplierAccount')";
                    SupplierAccountOID = Convert.ToInt32(ts.ExecuteScalar(strCmd));
                }
                catch (SqlException ex)
                {
                    ts.RollbackTransactions();
                    throw ex;
                }
                catch (Exception ex)
                {
                    ts.RollbackTransactions();
                    throw ex;
                }
                ts.commitTransaction();
            }
            return SupplierAccountOID;
        }

        public List<Model.SupplierAccount> FindAll()
        {
            string strCmd = @"select SupplierAccountOID, SupplierAccountID, PasswordHash, PasswordSalt, 
                                                              ContactName, Email, Address, Mobile, Tel, SupplierCode, 
                                                              AccountStatus, CreateDate, CreatorEmployeeID, ModifiedDate, 
                                                              SASendLetterState, SASendLetterDate
                                               from SupplierAccount";
            DataTable dt = SqlHelper.AdapterFill(strCmd);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Model.SupplierAccount> sas = new List<Model.SupplierAccount>();
            foreach (DataRow dr in dt.Rows)
            {
                sas.Add(this.GetSupplierAccount(dr));
            }
            return sas;
        }

        private Model.SupplierAccount GetSupplierAccount(DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }
            Model.SupplierAccount supplier = new Model.SupplierAccount();
            supplier.SupplierAccountOID = Convert.ToInt32(dr["SupplierAccountOID"]);
            supplier.SupplierAccountID = Convert.ToString(dr["SupplierAccountID"]);
            supplier.PasswordHash = Convert.ToString(dr["PasswordHash"]);
            supplier.PasswordSalt = Convert.ToString(dr["PasswordSalt"]);
            supplier.ContactName = Convert.ToString(dr["ContactName"]);
            supplier.Email = Convert.ToString(dr["Email"]);
            supplier.Address = Convert.ToString(dr["Address"]);
            supplier.Mobile = Convert.ToString(dr["Mobile"]);
            supplier.Tel = Convert.ToString(dr["Tel"]);
            supplier.SupplierCode = Convert.ToString(dr["SupplierCode"]);
            supplier.AccountStatus = Convert.ToString(dr["AccountStatus"]);
            supplier.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
            supplier.CreatorEmployeeID = Convert.ToString(dr["CreatorEmployeeID"]);
            if (!SqlHelper.IsNull(dr["ModifiedDate"]))
            {
                supplier.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            }
            supplier.SASendLetterState = Convert.ToString(dr["SASendLetterState"]);
            if (!SqlHelper.IsNull(dr["SASendLetterDate"]))
            {
                supplier.SASendLetterDate = Convert.ToDateTime(dr["SASendLetterDate"]);
            }
            return supplier;
        }

        //========================================
        public static void updateSupplierbSendLetterDate(string saSendLetterDate, string SupAccID)
        {
            string strCmd = @"update [dbo].[SupplierAccount]
                                set [SASendLetterDate] = @SASendLetterDate
                                where [SupplierAccountID] = @SupplierAccountID";
            SqlParameter sSupplierAccountID = SqlHelper.CreateParameter("@SupplierAccountID", SqlDbType.VarChar, 10, SupAccID);
            SqlParameter sSASendLetterDate = SqlHelper.CreateParameter("@SASendLetterDate", SqlDbType.DateTime, saSendLetterDate);
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(sSupplierAccountID);
            paramList.Add(sSASendLetterDate);
            SqlHelper.ExecuteNonQuery(strCmd, paramList, CommandType.Text);
        }

        public static DataTable getAllSupplierAccount()
        {
            string strCmd = @"select [AccountStatus] as '啟用狀態', sinfo.SupplierName as '供應商名稱', sa.[SupplierCode] as '供應商代碼', [SupplierAccountID] as '供應商帳號', sa.[Email] as '電子信箱', [ContactName] as '聯絡人', [Mobile] as '手機', sa.[Tel] as '聯絡電話', sr.RatingName as '供應商等級'
                                from [dbo].[SupplierAccount] as sa
                                join [dbo].[SupplierInfo] as sinfo
                                on sa.SupplierCode = sinfo.SupplierCode
                                join [dbo].[SupplierRating] sr
                                on sinfo.SupplierRatingOID = sr.SupplierRatingOID
                                ";
            DataTable dt = SqlHelper.AdapterFill(strCmd, CommandType.Text);
            return dt;
        }

        public static DataTable SearchSupplierAccount(string txtSupCode, string txtSupName, string radiobtnAccountStatus)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            string strCmd = @"select [AccountStatus] as '啟用狀態', sinfo.SupplierName as '供應商名稱', sa.[SupplierCode] as '供應商代碼', [SupplierAccountID] as '供應商帳號', sa.[Email] as '電子信箱', [ContactName] as '聯絡人', [Mobile] as '手機', sa.[Tel] as '聯絡電話', sr.RatingName as '供應商等級'
                                from [dbo].[SupplierAccount] as sa
                                join [dbo].[SupplierInfo] as sinfo
                                on sa.SupplierCode = sinfo.SupplierCode
                                join [dbo].[SupplierRating] sr
                                on sinfo.SupplierRatingOID = sr.SupplierRatingOID
                                where sa.[SupplierCode] = @SupplierCode
                                or [SupplierName] = @SupplierName
                                or [AccountStatus] = @AccountStatus";
            SqlParameter sSupplierCode = SqlHelper.CreateParameter("@SupplierCode", SqlDbType.VarChar, 10, txtSupCode);
            SqlParameter sSupplierName = SqlHelper.CreateParameter("@SupplierName", SqlDbType.NVarChar, 30, txtSupName);
            SqlParameter AccountStatus = SqlHelper.CreateParameter("@AccountStatus", SqlDbType.VarChar, 1, radiobtnAccountStatus);
            paramList.Add(sSupplierCode);
            paramList.Add(sSupplierName);
            paramList.Add(AccountStatus);
            DataTable dt = SqlHelper.AdapterFill(strCmd, paramList, CommandType.Text);
            return dt;
        }

        public static DataTable getDataOfSupCodenotInSupAcc()
        {
            string strCmd = @"select supInfo.[SupplierName] +' ('+ supInfo.[SupplierCode] + ')', supInfo.[SupplierCode] + ' (' + supInfo.[SupplierName] + ')', supInfo.[SupplierCode]
                                from [dbo].[SupplierInfo] supInfo
                                full outer join [dbo].[SupplierAccount] sa
                                on supInfo.[SupplierCode] = sa.[SupplierCode]
                                where supInfo.[SupplierCode] is null
                                or sa.[SupplierCode] is null";
            DataTable dt = SqlHelper.AdapterFill(strCmd, CommandType.Text);
            return dt;
        }

        public static List<string> getSupNameAndSupCode()
        {
            DataTable dt = getDataOfSupCodenotInSupAcc();
            List<string> SupNameAndSupCode = new List<string>();
            List<string> SupCode = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                SupNameAndSupCode.Add(dr[0].ToString());
            }
            return SupNameAndSupCode;
        }

        public static void getAutoCompleteSupNameAndSupCode(ComboBox cbbox)
        {
            DataTable dt = getDataOfSupCodenotInSupAcc();
            cbbox.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    string Sup = row[column].ToString();
                    ac.Add(Sup);
                }
            }
            cbbox.AutoCompleteCustomSource = ac;
        }

        public static int insertDataToSupAcc(string ContactName, string Email, string Mobile, string Tel, string AccountStatus, string CreatorEmployeeID, string ModifiedDate, string saSendLetterState, string saSendLetterDate, string SupplierCode, ref string password)
        {
            // salt和pwd
            string salt = Convert.ToString(Guid.NewGuid());
            password = Util.BuildAuthToken();
            string hashPassword = Util.GetHash(password + salt.ToString());

            string strCmd = @"insert [dbo].[SupplierAccount]
                                ([SupplierAccountID],[PasswordHash],[PasswordSalt],[ContactName],[Email],[Address],[Mobile],[Tel],[AccountStatus],[CreateDate],[CreatorEmployeeID],[ModifiedDate],[SASendLetterState],[SASendLetterDate],[SupplierCode])
                                values
                                ((select 'S' + right(format((select MAX(SupplierAccountOID)+1 from SupplierAccount with (TABLOCKX)), '00000000#'), 9)),@PasswordHash,@PasswordSalt,@ContactName,@Email,@Address,@Mobile,@Tel,@AccountStatus,getdate(),@CreatorEmployeeID,@ModifiedDate,@SASendLetterState,@SASendLetterDate,@SupplierCode)";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(SqlHelper.CreateParameter("@PasswordHash", SqlDbType.VarChar, 128, hashPassword));
            list.Add(SqlHelper.CreateParameter("@PasswordSalt", SqlDbType.VarChar, 68, salt));
            list.Add(SqlHelper.CreateParameter("@ContactName", SqlDbType.NVarChar, 30, ContactName));
            list.Add(SqlHelper.CreateParameter("@Email", SqlDbType.NVarChar, 64, Email));
            list.Add(SqlHelper.CreateParameter("@Address", SqlDbType.NVarChar, 256, DBNull.Value));
            list.Add(SqlHelper.CreateParameter("@Mobile", SqlDbType.VarChar, 30, Mobile));
            list.Add(SqlHelper.CreateParameter("@Tel", SqlDbType.VarChar, 30, Tel));
            list.Add(SqlHelper.CreateParameter("@AccountStatus", SqlDbType.VarChar, 1, AccountStatus));
            list.Add(SqlHelper.CreateParameter("@CreatorEmployeeID", SqlDbType.VarChar, 10, CreatorEmployeeID));
            list.Add(SqlHelper.CreateParameter("@ModifiedDate", SqlDbType.DateTime, ModifiedDate));
            list.Add(SqlHelper.CreateParameter("@SASendLetterState", SqlDbType.VarChar, 1, saSendLetterState));
            list.Add(SqlHelper.CreateParameter("@SASendLetterDate", SqlDbType.DateTime, saSendLetterDate));
            list.Add(SqlHelper.CreateParameter("@SupplierCode", SqlDbType.NVarChar, 6, SupplierCode));
            int result = SqlHelper.ExecuteNonQuery(strCmd, list, CommandType.Text);
            return result;
        }

        //寄信
        public static void updateSupSAsendLetterStatus(string SupCode, string SAsendLetterStatus)
        {
            string strCmd = @"update [dbo].[SupplierAccount]
                            set [SASendLetterState] = @SASendLetterState
                            where [SupplierCode] = @SupplierCode";
            SqlParameter sSupCode = SqlHelper.CreateParameter("@SupplierCode", SqlDbType.NVarChar, 6, SupCode);
            SqlParameter sSAsendLetterStatus = SqlHelper.CreateParameter("@SASendLetterState", SqlDbType.VarChar, 1, SAsendLetterStatus);
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(sSupCode);
            paramList.Add(sSAsendLetterStatus);
            SqlHelper.ExecuteNonQuery(strCmd, paramList, CommandType.Text);
        }

        //更新帳號狀態
        public static bool updateSupAccountStatus(string myCilckCellAccountStatus)
        {

            string strCmd = @"update [dbo].SupplierAccount
                                    set [AccountStatus] = @AccountStatus
                                    where SupplierAccountID = @SupplierAccountID";
            SqlParameter sSupplierAccountID = SqlHelper.CreateParameter("@SupplierAccountID", SqlDbType.VarChar, 10, SupplierAccountForm.CellSupAccID);
            SqlParameter sAccountStatus = SqlHelper.CreateParameter("@AccountStatus", SqlDbType.VarChar, 1, myCilckCellAccountStatus);
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(sSupplierAccountID);
            paramList.Add(sAccountStatus);
            SqlHelper.ExecuteNonQuery(strCmd, paramList, CommandType.Text);
            return true;
        }
    }
}

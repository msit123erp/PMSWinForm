using PMSWin.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PMSWin.PurchasingOrder
{
public class BuyerDao
    {
        public Buyer FindBuyerByEmployeeID(string EmployeeID)
        {
            string strCmd = @"select BuyerOID ,EmployeeID ,PasswordHash, PasswordSalt, AccountStatus
                                                           ,CreateDate, ModifiedDate, BSendLetterState, BSendLetterDate
                                                 from Buyer
                                                 where EmployeeID = @EmployeeID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, EmployeeID));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            Buyer buyer = this.GetBuyer(dt.Rows[0]);
            return buyer;
        }

        public List<Buyer> FindAll()
        {
            string strCmd = @"select BuyerOID ,EmployeeID ,PasswordHash, PasswordSalt, AccountStatus
                                                           ,CreateDate, ModifiedDate, BSendLetterState, BSendLetterDate
                                                 from Buyer";
            DataTable dt = SqlHelper.AdapterFill(strCmd);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Buyer> buyers = new List<Buyer>();
            foreach (DataRow dr in dt.Rows)
            {
                buyers.Add(this.GetBuyer(dr));
            }
            return buyers;
        }
        //仰1
        public static DataTable getAllBuyerAccount()
        {
            string strCmd = @"select [AccountStatus] as '啟用狀態', emp.[EmployeeID] as '員工帳號', [Name] as '姓名',[Email] as '電子信箱', [Mobile] as '手機', [Tel] as '市話'
                            from [dbo].[Buyer] as b
                            join [dbo].[Employee] as emp
                            on emp.EmployeeID = b.EmployeeID";
            DataTable dt = SqlHelper.AdapterFill(strCmd, CommandType.Text);
            return dt;
        }

        public static DataTable SearchBuyerAccount(string txtEmpID, string txtEmpName, string radiobtnAccountStatus)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            string strCmd = @"select [AccountStatus] as '啟用狀態', emp.[EmployeeID] as '員工帳號', [Name] as '姓名',[Email] as '電子信箱', [Mobile] as '手機', [Tel] as '市話'
                            from [dbo].[Buyer] as b
                            join [dbo].[Employee] as emp
                            on emp.EmployeeID = b.EmployeeID
                            where emp.[EmployeeID] = @EmployeeID
                            or [Name] = @EmpName
                            or [AccountStatus] = @AccountStatus";
            SqlParameter EmployeeID = SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, txtEmpID);
            SqlParameter EmpName = SqlHelper.CreateParameter("@EmpName", SqlDbType.NVarChar, 30, txtEmpName);
            SqlParameter AccountStatus = SqlHelper.CreateParameter("@AccountStatus", SqlDbType.VarChar, 1, radiobtnAccountStatus);
            paramList.Add(EmployeeID);
            paramList.Add(EmpName);
            paramList.Add(AccountStatus);
            DataTable dt = SqlHelper.AdapterFill(strCmd, paramList, CommandType.Text);
            return dt;
        }

        public static DataTable SearchBuyerAccount(string txtEmpID, string txtEmpName)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            string strCmd = @"select [AccountStatus] as '啟用狀態', emp.[EmployeeID] as '員工帳號', [Name] as '姓名',[Email] as '電子信箱', [Mobile] as '手機', [Tel] as '市話'
                            from [dbo].[Buyer] as b
                            join [dbo].[Employee] as emp
                            on emp.EmployeeID = b.EmployeeID
                            where emp.[EmployeeID] = @EmployeeID
                            or [Name] = @EmpName";
            SqlParameter EmployeeID = SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, txtEmpID);
            SqlParameter EmpName = SqlHelper.CreateParameter("@EmpName", SqlDbType.NVarChar, 30, txtEmpName);
            paramList.Add(EmployeeID);
            paramList.Add(EmpName);
            DataTable dt = SqlHelper.AdapterFill(strCmd, paramList, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// SearchBuyerAccount 回傳資料
        /// </summary>
        /// <param name="txtEmpID"></param>
        /// <param name="AccountStatus">out AccountStatus</param>
        /// <param name="Name">out Name</param>
        /// <param name="Email">out Email</param>
        /// <param name="Mobile">out Mobile</param>
        /// <param name="Tel">out Tel</param>
        /// <returns></returns>
        public static DataTable SearchBuyerAccount(string txtEmpID, out string AccountStatus, out string Name, out string Email, out string Mobile, out string Tel)
        {
            string strCmd = @"select [AccountStatus] as '啟用狀態', emp.[EmployeeID] as '員工帳號', [Name] as '姓名',[Email] as '電子信箱', [Mobile] as '手機', [Tel] as '市話'
                            from [dbo].[Buyer] as b
                            join [dbo].[Employee] as emp
                            on emp.EmployeeID = b.EmployeeID
                            where emp.[EmployeeID] = @EmployeeID";
            SqlParameter sEmployeeID = SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, txtEmpID);
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(sEmployeeID);
            DataTable dt = SqlHelper.AdapterFill(strCmd, paramList, CommandType.Text);

            AccountStatus = (string)(dt.Rows[0])["啟用狀態"];
            Name = (string)(dt.Rows[0])["姓名"];
            Email = (string)(dt.Rows[0])["電子信箱"];
            Mobile = (string)(dt.Rows[0])["手機"];
            Tel = (string)(dt.Rows[0])["市話"];
            return dt;
        }
        
        public static bool updateBuyerAccountStatus(string myAccountStatus)
        {
            try
            {
                string strCmd = @"update [dbo].[Buyer]
                            set [AccountStatus] = @AccountStatus
                            where [EmployeeID] = @EmployeeID";
                SqlParameter sEmployeeID = SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, PMSWin.BuyerAccount.BuyerAccountForm_Update.CellEmpID);
                SqlParameter sAccountStatus = SqlHelper.CreateParameter("@AccountStatus", SqlDbType.VarChar, 1, myAccountStatus);
                List<SqlParameter> paramList = new List<SqlParameter>();
                paramList.Add(sEmployeeID);
                paramList.Add(sAccountStatus);
                SqlHelper.ExecuteNonQuery(strCmd, paramList, CommandType.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //TODO 型態 bool 會 System.StackOverflowException
        public static void updateBuyerbSendLetterDate(string bSendLetterDate, string EmpID)
        {
            string strCmd = @"update [dbo].[Buyer]
                            set [BSendLetterDate] = @bSendLetterDate
                            where [EmployeeID] = @EmployeeID";
            SqlParameter sEmployeeID = SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, EmpID);
            SqlParameter sbSendLetterDate = SqlHelper.CreateParameter("@bSendLetterDate", SqlDbType.DateTime, bSendLetterDate);
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(sEmployeeID);
            paramList.Add(sbSendLetterDate);
            SqlHelper.ExecuteNonQuery(strCmd, paramList, CommandType.Text);
        }

        /// <summary>
        /// SearchEmployee Employee 資料表
        /// </summary>
        /// <param name="txtEmpID"></param>
        /// <param name="AccountStatus"></param>
        /// <param name="Name"></param>
        /// <param name="Email"></param>
        /// <param name="Mobile"></param>
        /// <param name="Tel"></param>
        /// <returns></returns>
        public static DataTable SearchEmployee(string txtEmpID, out string EmployeeID, out string Name, out string Email, out string Mobile, out string Tel)
        {
            string strCmd = @"select emp.[EmployeeID] as '員工帳號', [Name] as '姓名',[Email] as '電子信箱', [Mobile] as '手機', [Tel] as '市話'
                                from [dbo].[Employee] as emp
                                where EmployeeID = @EmployeeID";
            SqlParameter sEmployeeID = SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, txtEmpID);
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(sEmployeeID);
            DataTable dt = SqlHelper.AdapterFill(strCmd, paramList, CommandType.Text);
            EmployeeID = (string)(dt.Rows[0])["員工帳號"];
            Name = (string)(dt.Rows[0])["姓名"];
            Email = (string)(dt.Rows[0])["電子信箱"];
            Mobile = (string)(dt.Rows[0])["手機"];
            Tel = (string)(dt.Rows[0])["市話"];
            return dt;
        }

        public static void getAutoCompleteOfEmpIDnotInBuyer(System.Windows.Forms.TextBox txtbox, CommandType type = CommandType.Text)
        {
            string strCmd = @"select emp.[EmployeeID]
                                from [dbo].[Employee] emp
                                full outer join [dbo].[Buyer] b
                                on emp.EmployeeID = b.EmployeeID
                                where emp.EmployeeID is null
                                or b.EmployeeID is null";
            DataTable dt = SqlHelper.AdapterFill(strCmd, CommandType.Text);
            txtbox.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    string EmpId = row[column].ToString();
                    ac.Add(EmpId);
                }
            }
            txtbox.AutoCompleteCustomSource = ac;
        }

        //TODO bSendLetterState 非同步
        //TODO 【解決】原因: accStatus 沒預設值 System.Data.SqlClient.SqlException: '參數化查詢 '(@EmployeeID varchar(10),@AccountStatus varchar(1),@PasswordHash' 必須有參數 '@AccountStatus'，但未提供。'
        /// <summary>
        /// 將 Employee 加入 Buyer
        /// </summary>
        /// <param name="typeIntxtEmpID">在 UI 輸入的員工帳號</param>
        /// <param name="accStatus">在 UI 選取的帳號狀態</param>
        /// <param name="modifiedDate">修改日期：同 UI 新增時產生</param>
        /// <param name="bSendLetterState"></param>
        /// <param name="bSendLetterDate">寄信時間：同 UI 新增時產生</param>
        public static void insertEmpToBuyer(string typeIntxtEmpID, string accStatus, string modifiedDate, string bSendLetterState, string bSendLetterDate, ref string password)
        {
            //salt和pwd
            string salt = Convert.ToString(Guid.NewGuid());
            password = Util.BuildAuthToken();
            string hashPassword = Util.GetHash(password + salt.ToString());
            //
            string strCmdInsert = @"insert [dbo].[Buyer]([EmployeeID],[AccountStatus],[PasswordHash],[PasswordSalt],[CreateDate],[ModifiedDate],[BSendLetterState],[BSendLetterDate])
                                    values ( @EmployeeID, @AccountStatus, @PasswordHash, @PasswordSalt, GETDATE(), @ModifiedDate, @BSendLetterState, @BSendLetterDate)
                                    ";
            //accStatus = "E";
            //modifiedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            //bSendLetterState = "S";
            //bSendLetterDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            SqlParameter EmployeeID = SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, typeIntxtEmpID);
            SqlParameter AccountStatus = SqlHelper.CreateParameter("@AccountStatus", SqlDbType.VarChar, 1, accStatus);
            SqlParameter PasswordHash = SqlHelper.CreateParameter("@PasswordHash", SqlDbType.VarChar, 128, hashPassword);
            SqlParameter PasswordSalt = SqlHelper.CreateParameter("@PasswordSalt", SqlDbType.VarChar, 68, salt);
            SqlParameter ModifiedDate = SqlHelper.CreateParameter("@ModifiedDate", SqlDbType.DateTime, modifiedDate);
            SqlParameter BSendLetterState = SqlHelper.CreateParameter("@BSendLetterState", SqlDbType.VarChar, 1, bSendLetterState);
            SqlParameter BSendLetterDate = SqlHelper.CreateParameter("@BSendLetterDate", SqlDbType.DateTime, bSendLetterDate);

            List<SqlParameter> paramList2 = new List<SqlParameter>();
            paramList2.Add(EmployeeID);
            paramList2.Add(AccountStatus);
            paramList2.Add(PasswordHash);
            paramList2.Add(PasswordSalt);
            paramList2.Add(ModifiedDate);
            paramList2.Add(BSendLetterState);
            paramList2.Add(BSendLetterDate);

            SqlHelper.ExecuteNonQuery(strCmdInsert, paramList2, CommandType.Text);
        }

        public static void updateBuyerBsendLetterStatus(string EmpID, string BsendLetterStatus)
        {
            string strCmd = @"update [dbo].[Buyer]
                            set [BSendLetterState] = @BSendLetterState
                            where [EmployeeID] = @EmployeeID";
            SqlParameter sEmployeeID = SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, EmpID);
            SqlParameter sBSendLetterState = SqlHelper.CreateParameter("@BSendLetterState", SqlDbType.VarChar, 1, BsendLetterStatus);
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(sEmployeeID);
            paramList.Add(sBSendLetterState);
            SqlHelper.ExecuteNonQuery(strCmd, paramList, CommandType.Text);
        }
    
        
        //仰2
        
        public int CreateBuyer(string EmployeeID, string PasswordHash, string PasswordSalt, string AccountStatus, DateTime CreateDate)
        {
            int BuyerOID = -1;
            using (Transactions ts = new Transactions(600))
            {
                string strCmd = @"INSERT INTO Buyer(EmployeeID, PasswordHash, PasswordSalt, AccountStatus, CreateDate)
                                                    VALUES(@EmployeeID, @PasswordHash, @PasswordSalt, @AccountStatus, @CreateDate)";
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, EmployeeID));
                parameters.Add(SqlHelper.CreateParameter("@PasswordHash", SqlDbType.VarChar, 128, PasswordHash));
                parameters.Add(SqlHelper.CreateParameter("@PasswordSalt", SqlDbType.VarChar, 68, PasswordSalt));
                parameters.Add(SqlHelper.CreateParameter("@AccountStatus", SqlDbType.VarChar, 1, AccountStatus));
                parameters.Add(SqlHelper.CreateParameter("@CreateDate", SqlDbType.DateTime, CreateDate));

                try
                {
                    ts.ExecuteNonQuery(strCmd, parameters);
                    strCmd = @"SELECT IDENT_CURRENT ('Buyer')";
                    BuyerOID = Convert.ToInt32(ts.ExecuteScalar(strCmd));
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
            return BuyerOID;
        }

        private Buyer GetBuyer(DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }
            Buyer buyer = new Buyer();
            buyer.BuyerOID = Convert.ToInt32(dr["BuyerOID"]);
            buyer.EmployeeID = Convert.ToString(dr["EmployeeID"]);
            buyer.PasswordHash = Convert.ToString(dr["PasswordHash"]);
            buyer.PasswordSalt = Convert.ToString(dr["PasswordSalt"]);
            buyer.AccountStatus = Convert.ToString(dr["AccountStatus"]);
            buyer.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
            if (!SqlHelper.IsNull(dr["ModifiedDate"]))
            {
                buyer.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            }
            buyer.BSendLetterState = Convert.ToString(dr["BSendLetterState"]);
            if (!SqlHelper.IsNull(dr["BSendLetterDate"]))
            {
                buyer.BSendLetterDate = Convert.ToDateTime(dr["BSendLetterDate"]);
            }
            return buyer;
        }
        /// //////////////////////////////////////////////////////////////////////呈穎
        public DataTable GetBuyerName(string EmployeeID)
        {
            string strCmd = @"select *
                                                 from Employee
                                                 where EmployeeID = @EmployeeID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, EmployeeID));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }


            return dt;
        }
        /// //////////////////////////////////////////////////////////////////////呈穎
    }
}

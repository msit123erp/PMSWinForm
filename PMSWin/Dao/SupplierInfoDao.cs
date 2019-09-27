using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMSWin.Model;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PMSWin.Dao
{
    public class SupplierInfoDao
    {
        public Model.SupplierInfo FindSupplierInfoBySupplierCode(string SupplierCode)
        {
            string strCmd = @"select SupplierInfoOID, SupplierCode, SupplierName, 
                                                            TaxID, Email, Tel, [Address], SupplierRatingOID
                                               from dbo.SupplierInfo
                                               where SupplierCode = @SupplierCode";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@SupplierCode", SqlDbType.NVarChar, 6, SupplierCode));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            Model.SupplierInfo si = this.GetSupplierInfo(dt.Rows[0]);
            return si;
        }

        public List<Model.SupplierInfo> FindAll()
        {
            string strCmd = @"select SupplierInfoOID, SupplierCode, SupplierName, 
                                                            TaxID, Email, Tel, [Address], SupplierRatingOID
                                               from dbo.SupplierInfo";
            DataTable dt = SqlHelper.AdapterFill(strCmd);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Model.SupplierInfo> sis = new List<Model.SupplierInfo>();
            foreach (DataRow dr in dt.Rows)
            {
                sis.Add(this.GetSupplierInfo(dr));
            }
            return sis;
        }

        private Model.SupplierInfo GetSupplierInfo(DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }
            Model.SupplierInfo si = new Model.SupplierInfo();
            si.SupplierInfoOID = Convert.ToInt32(dr["SupplierInfoOID"]);
            si.SupplierCode = Convert.ToString(dr["SupplierCode"]);
            si.SupplierName = Convert.ToString(dr["SupplierName"]);
            si.TaxID = Convert.ToString(dr["TaxID"]);
            si.Email = Convert.ToString(dr["Email"]);
            si.Tel = Convert.ToString(dr["Tel"]);
            si.Address = Convert.ToString(dr["Address"]);
            si.SupplierRatingOID = Convert.ToInt32(dr["SupplierRatingOID"]);
            return si;
        }
        
        
        public DataTable FindSupplierBySupplierCode(string supplierName, string supplierCode)
        {
            string cmd = @"select [SupplierCode] as '公司代碼',[SupplierName] as '公司名稱',[TaxID] as '統編',[Email] as '電子信箱',[Tel] as '市話',[RatingName] as '供應商等級'
                        from [dbo].[SupplierInfo] i
                        join [dbo].[SupplierRating] r
                        on i.SupplierRatingOID = r.SupplierRatingOID
                        where ([SupplierCode] = @SupplierCode and [SupplierName] = @SupplierName)
                        or [SupplierName] = @SupplierName
                        or [SupplierCode] = @SupplierCode";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(SqlHelper.CreateParameter("@SupplierName", SqlDbType.NVarChar, 30, supplierName.Replace(" ", "")));
            list.Add(SqlHelper.CreateParameter("@SupplierCode", SqlDbType.NVarChar, 6, supplierCode.Replace(" ", "")));
            DataTable dt = SqlHelper.AdapterFill(cmd, list, CommandType.Text);

            if(dt.Rows.Count == 0)
            {
                return null;
            }

            return dt;
        }
        
        public void SupplierUpdate(string rate,string supplierName)
        {
            string cmd = @"update [dbo].[SupplierInfo]
                            set [SupplierRatingOID] = @SupplierRatingOID
                            where [SupplierName] = @SupplierName";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(SqlHelper.CreateParameter("@SupplierRatingOID", SqlDbType.Int, 1, rate));
            list.Add(SqlHelper.CreateParameter("@SupplierName", SqlDbType.NVarChar, 30, supplierName));
            SqlHelper.ExecuteNonQuery(cmd, list, CommandType.Text);
        }

        public DataTable SupplierCreate(string supplierName, string taxID, string tel, string email, string addr, string rate)
        {
            DataTable dt = new DataTable();
            int SupplierInfoOID = -1;
            using (Transactions tr = new Transactions(600))
            {
                string strcmd = @"INSERT INTO [dbo].[SupplierInfo] ([SupplierCode],[SupplierName],[TaxID],[Email],[Tel],[Address],[SupplierRatingOID])
                                        VALUES ((select 'S' + right(format((select MAX(SupplierInfoOID)+1 from SupplierInfo with (TABLOCKX)), '0000#'), 5))
                                                ,@SupplierName ,@TaxID,@Email,@Tel,@Address, @SupplierRatingOID)";
                List<SqlParameter> list = new List<SqlParameter>();
                list.Add(SqlHelper.CreateParameter("@SupplierName", SqlDbType.NVarChar, 30, supplierName.Replace(" ","")));
                list.Add(SqlHelper.CreateParameter("@TaxID", SqlDbType.VarChar, 10, taxID.Replace(" ", "")));
                list.Add(SqlHelper.CreateParameter("@Email", SqlDbType.VarChar, 64, email.Replace(" ", "")));
                list.Add(SqlHelper.CreateParameter("@Tel", SqlDbType.VarChar, 30, tel.Replace(" ", "")));
                list.Add(SqlHelper.CreateParameter("@Address", SqlDbType.NVarChar, 256, addr.Replace(" ", "")));
                list.Add(SqlHelper.CreateParameter("@SupplierRatingOID", SqlDbType.Int, 1, rate.Replace(" ", "")));

                try
                {
                    tr.ExecuteNonQuery(strcmd, list);

                }
                catch (SqlException ex) {

                    tr.RollbackTransactions();
                    throw ex;
                }
                catch (Exception)
                {
                    tr.RollbackTransactions();
                }

                try
                {
                    SupplierInfoOID = Convert.ToInt32(tr.ExecuteScalar("SELECT IDENT_CURRENT ('dbo.SupplierInfo')", new List<SqlParameter>()));
                }
                catch (SqlException ex) {

                    tr.RollbackTransactions();
                    throw ex;
                }
                catch (Exception)
                {
                    tr.RollbackTransactions();
                    throw;
                }

                tr.commitTransaction();
            }
            string cmd = "select * from SupplierInfo where SupplierInfoOID = @SupplierInfoOID";
            List<SqlParameter> li = new List<SqlParameter>();
            li.Add( SqlHelper.CreateParameter("@SupplierInfoOID", SqlDbType.NVarChar, 30, SupplierInfoOID));
            dt = SqlHelper.AdapterFill(cmd,li, CommandType.Text);
            return dt;
        }

        //關鍵字查詢
        public void getSupplierCode(TextBox txtbox, CommandType type = CommandType.Text)
        {
            string strCmd = @"select [SupplierCode]
                                from [dbo].[SupplierInfo]";
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

        public void getSupplierName(TextBox txtbox, CommandType type = CommandType.Text)
        {
            string strCmd = @"select [SupplierName]
                                from [dbo].[SupplierInfo]";
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
    }

}

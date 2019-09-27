using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin
{
    public sealed class SqlHelper
    {
        static string GetConnectionString()
        {
            return Properties.Settings.Default.PMSConnectionString;
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        public static int ExecuteNonQuery(string strCmd, CommandType type = CommandType.Text)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(strCmd, conn))
                {
                    cmd.CommandType = type;
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string strCmd, CommandType type = CommandType.Text)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(strCmd, conn))
                {
                    cmd.CommandType = type;
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static int ExecuteNonQuery(string strCmd, List<SqlParameter> paramList, CommandType type = CommandType.Text)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(strCmd, conn))
                {
                    cmd.CommandType = type;
                    foreach (SqlParameter parameter in paramList)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable AdapterFill(string strCmd, CommandType type = CommandType.Text)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(strCmd, conn))
                {
                    cmd.CommandType = type;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static DataTable AdapterFill(string strCmd, List<SqlParameter> paramList, CommandType type = CommandType.Text)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(strCmd, conn))
                {
                    cmd.CommandType = type;
                    foreach (SqlParameter parameter in paramList)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static void TransOperation(List<string> cmdList, List<List<SqlParameter>> paramList)
        {
            int count = 0;
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    using (SqlCommand cmd = new SqlCommand()
                    {
                        Connection = conn,
                        Transaction = tran,
                        CommandTimeout = 60
                    })
                    {
                        foreach (string strCmd in cmdList)
                        {
                            cmd.CommandText = strCmd;
                            foreach (SqlParameter parameter in paramList[count])
                            {
                                cmd.Parameters.Add(parameter);
                            }
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                tran.Rollback();
                                throw ex;
                            }
                            catch (Exception ex)
                            {
                                tran.Rollback();
                                throw ex;
                            }
                            cmd.Parameters.Clear();
                            count++;
                        }
                    }
                    tran.Commit();
                }
            }
        }

        public static SqlParameter CreateParameter(string parameterName, SqlDbType dbType, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            SqlParameter param = new SqlParameter(parameterName, dbType);
            param.Value = value;
            param.Direction = direction;
            return param;
        }

        public static SqlParameter CreateParameter(string parameterName, SqlDbType dbType, int size, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            SqlParameter param = new SqlParameter(parameterName, dbType, size);
            param.Value = value;
            param.Direction = direction;
            return param;
        }

        public static SqlParameter CreateParameter(string parameterName, SqlDbType dbType, ParameterDirection direction)
        {
            SqlParameter param = new SqlParameter(parameterName, dbType);
            param.Direction = direction;
            return param;
        }

        public static SqlParameter CreateParameter(string parameterName, SqlDbType dbType, int size, ParameterDirection direction)
        {
            SqlParameter param = new SqlParameter(parameterName, dbType, size);
            param.Direction = direction;
            return param;
        }

        public static bool IsNull(object compareValue)
        {
            return (DBNull.Value.Equals(compareValue));
        }

    }
}

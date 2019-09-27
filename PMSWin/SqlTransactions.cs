using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin
{
    public class Transactions : IDisposable
    {
        private SqlConnection m_sqlConnection;
        private SqlTransaction m_sqlTransaction;
        private SqlCommand m_sqlCommand;

        public Transactions(int TimeOut = 600)
        {
            m_sqlConnection = CreateConn();
            m_sqlConnection.Open();

            m_sqlTransaction = m_sqlConnection.BeginTransaction(IsolationLevel.Serializable);

            m_sqlCommand = new SqlCommand()
            {
                Connection = m_sqlConnection,
                Transaction = m_sqlTransaction,
                CommandTimeout = TimeOut
            };
        }

        private SqlConnection CreateConn()
        {
            return new SqlConnection(Properties.Settings.Default.PMSConnectionString);
        }

        public void TransOperation(List<string> cmdList, List<List<SqlParameter>> paramList)
        {
            int count = 0;
            foreach (string strCmd in cmdList)
            {
                m_sqlCommand.Parameters.Clear();
                m_sqlCommand.CommandText = strCmd;
                foreach (SqlParameter sqlParameter in paramList[count])
                {
                    m_sqlCommand.Parameters.Add(sqlParameter);
                }
                m_sqlCommand.ExecuteNonQuery();
                count++;
            }
        }

        public int ExecuteNonQuery(string strCmd)
        {
            m_sqlCommand.Parameters.Clear();
            m_sqlCommand.CommandText = strCmd;
            return m_sqlCommand.ExecuteNonQuery();
        }

        public int ExecuteNonQuery(string strCmd, List<SqlParameter> paramList)
        {
            m_sqlCommand.Parameters.Clear();
            m_sqlCommand.CommandText = strCmd;

            foreach (SqlParameter parameter in paramList)
            {
                m_sqlCommand.Parameters.Add(parameter);
            }
            return m_sqlCommand.ExecuteNonQuery();
        }

        public object ExecuteScalar(string strCmd)
        {
            m_sqlCommand.Parameters.Clear();
            m_sqlCommand.CommandText = strCmd;
            return m_sqlCommand.ExecuteScalar();
        }

        public object ExecuteScalar(string strCmd, List<SqlParameter> paramList)
        {
            m_sqlCommand.Parameters.Clear();
            m_sqlCommand.CommandText = strCmd;

            foreach (SqlParameter parameter in paramList)
            {
                m_sqlCommand.Parameters.Add(parameter);
            }
            return m_sqlCommand.ExecuteScalar();
        }

        public void commitTransaction()
        {
            m_sqlTransaction.Commit();
        }

        public void RollbackTransactions()
        {
            m_sqlTransaction.Rollback();
        }

        public void CloseConnections()
        {
            m_sqlTransaction.Dispose();
            m_sqlCommand.Dispose();
            if (m_sqlConnection.State == ConnectionState.Open)
            {
                m_sqlConnection.Close();
                m_sqlConnection.Dispose();
            }
        }

        public void Dispose()
        {
            this.CloseConnections();
        }
    }
}

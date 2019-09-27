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
    public class EmployeeDao
    {
        public Employee FindEmployeeByEmployeeID(string EmployeeID) {
            string strCmd = @"select EmployeeOID, EmployeeID, [Name], 
                                                            Email, Mobile, Tel, CompanyCode
                                                 from dbo.Employee
                                                where EmployeeID = @EmployeeID";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.CreateParameter("@EmployeeID", SqlDbType.VarChar, 10, EmployeeID));
            DataTable dt = SqlHelper.AdapterFill(strCmd, parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            Employee emp = this.GetEmployee(dt.Rows[0]);
            return emp;
        }

        public List<Employee> FindAll()
        {
            string strCmd = @"select EmployeeOID, EmployeeID, [Name], 
                                                            Email, Mobile, Tel, CompanyCode
                                                 from dbo.Employee";
            DataTable dt = SqlHelper.AdapterFill(strCmd);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Employee> emps = new List<Employee>();
            foreach (DataRow dr in dt.Rows)
            {
                emps.Add(this.GetEmployee(dr));
            }
            return emps;
        }

        private Employee GetEmployee(DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }
            Employee emp = new Employee();
            emp.EmployeeOID = Convert.ToInt32(dr["EmployeeOID"]);
            emp.EmployeeID = Convert.ToString(dr["EmployeeID"]);
            emp.Name = Convert.ToString(dr["Name"]);
            emp.Email = Convert.ToString(dr["Email"]);
            emp.Mobile = Convert.ToString(dr["Mobile"]);
            emp.Tel = Convert.ToString(dr["Tel"]);
            emp.CompanyCode = Convert.ToString(dr["CompanyCode"]);
            return emp;
        }
    }
}

using PMSWin.PurchasingOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Model
{
    public class Employee
    {
        public int EmployeeOID { get; set; }
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Tel { get; set; }
        public string CompanyCode { get; set; }

        public CompanyInfo GetCompanyInfo()
        {
            CompanyInfoDao dao = new CompanyInfoDao();
            return dao.FindCompanyInfoByCompanyCode(this.CompanyCode);
        }

    }
}

using PMSWin.PurchasingOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Model
{
    public class Buyer
    {
        public int BuyerOID { get; set; }
        public string EmployeeID { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string AccountStatus { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string BSendLetterState { get; set; }
        public Nullable<System.DateTime> BSendLetterDate { get; set; }

        public Employee GetEmployee()
        {
            EmployeeDao dao = new EmployeeDao();
            return dao.FindEmployeeByEmployeeID(this.EmployeeID);
        }

    }
}

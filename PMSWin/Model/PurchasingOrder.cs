using PMSWin.PurchasingOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Model
{
    public class PurchasingOrder
    {
        public int PurchasingOrderOID { get; set; }
        public string PurchasingOrderID { get; set; }
        public string EmployeeID { get; set; }
        public System.DateTime POBeginDate { get; set; }

        public Employee GetEmployee()
        {
            EmployeeDao dao = new EmployeeDao();
            return dao.FindEmployeeByEmployeeID(this.EmployeeID);
        }

        public Buyer GetBuyer()
        {
            BuyerDao dao = new BuyerDao();
            return dao.FindBuyerByEmployeeID(this.EmployeeID);
        }
    }
}

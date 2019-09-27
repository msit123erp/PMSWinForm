using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Model
{
    public class Order
    {
        public int OrderOID { get; set; }
        public string OrderID { get; set; }
        public string PurchasingOrderID { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierAccountID { get; set; }
        public string EmployeeID { get; set; }
        public Nullable<System.DateTime> DateRequired { get; set; }
        public Nullable<System.DateTime> DateReleased { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverTel { get; set; }
        public string ReceiverMobile { get; set; }
        public string ReceiptAddress { get; set; }
    }
}

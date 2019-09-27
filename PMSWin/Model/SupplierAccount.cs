using PMSWin.Dao;
using PMSWin.PurchasingOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Model
{
    public class SupplierAccount
    {
        public int SupplierAccountOID { get; set; }
        public string SupplierAccountID { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Tel { get; set; }
        public string SupplierCode { get; set; }
        public string AccountStatus { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreatorEmployeeID { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string SASendLetterState { get; set; }
        public Nullable<System.DateTime> SASendLetterDate { get; set; }

        public SupplierInfo GetSupplierInfo() {
            SupplierInfoDao dao = new SupplierInfoDao();
            return dao.FindSupplierInfoBySupplierCode(this.SupplierCode);
        }
    }
}

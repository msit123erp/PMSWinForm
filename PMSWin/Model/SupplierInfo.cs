using PMSWin.PurchasingOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Model
{
    public class SupplierInfo
    {
        public int SupplierInfoOID { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string TaxID { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public Nullable<int> SupplierRatingOID { get; set; }

        public SupplierRating GetSupplierRating()
        {
            SupplierRatingDao dao = new SupplierRatingDao();
            return dao.FindSupplierRatingBySupplierRatingOID(this.SupplierRatingOID);
        }
    }
}

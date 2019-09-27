using PMSWin.Dao;
using PMSWin.PurchasingOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Model
{
    public class Part
    {
        public int PartOID { get; set; }
        public string PartNumber { get; set; }
        public string PartName { get; set; }
        public string PartSpec { get; set; }
        public string SupplierCode { get; set; }
        public int PartUnitOID { get; set; }
        public Nullable<int> UnitPrice { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string PictureAdress { get; set; }
        public string PictureDescription { get; set; }

        public SupplierInfo GetSupplierInfo()
        {
            SupplierInfoDao dao = new SupplierInfoDao();
            return dao.FindSupplierInfoBySupplierCode(this.SupplierCode);
        }

        public PartUnit GetPartUnit() {
            PartUnitDao dao = new PartUnitDao();
            return dao.FindPartUnitByPartUnitOID(this.PartUnitOID);
        }

    }
}

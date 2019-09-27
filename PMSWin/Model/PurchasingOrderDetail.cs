using PMSWin.PurchasingOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Model
{
    public class PurchasingOrderDetail
    {
        public int PurchasingOrderDetailListOID { get; set; }
        public string PurchasingOrderID { get; set; }
        public int SourceListOID { get; set; }
        public int Qty { get; set; }

        public PurchasingOrder GetPurchasingOrder() {
            PurchasingOrderDao dao = new PurchasingOrderDao();
            return dao.FindPurchasingOrderByPurchasingOrderID(this.PurchasingOrderID);
        }

        public SourceList GetSourceList()
        {
            PMSWin.PurchasingOrder.SourceListDao dao = new PMSWin.PurchasingOrder.SourceListDao();
            return dao.FindSourceListBySourceListOID(this.SourceListOID);
        }
    }
}

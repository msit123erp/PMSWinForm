using PMSWin.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Model
{
    public class SourceOrderList
    {
        public int SourceOrderListOID { get; set; }
        public int OrderPartOID { get; set; }
        public int Batch { get; set; }
        public decimal Discount { get; set; }
        public int Qty { get; set; }
        public Nullable<int> PurchasingOrderDetailListOID { get; set; }

        public OrderPart GetOrderPart()
        {
            OrderPartDao dao = new OrderPartDao();
            return dao.FindOrderPartByOrderPartOID(this.OrderPartOID);
        }

        public PurchasingOrderDetail GetPurchasingOrderDetail()
        {
            if (!this.PurchasingOrderDetailListOID.HasValue)
            {
                return null;
            }
            PurchasingOrderDetailDao dao = new PurchasingOrderDetailDao();
            return dao.FindPurchasingOrderDetailBySourceListOID(this.OrderPartOID);
        }
    }
}

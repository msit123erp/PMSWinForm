using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Model
{
    public class OrderPart
    {
        public int OrderPartOID { get; set; }
        public string OrderID { get; set; }
        public string PartNumber { get; set; }
        public string PartName { get; set; }
        public string PartSpec { get; set; }
        public string PartUnitName { get; set; }
        public Nullable<int> UnitPrice { get; set; }
    }
}

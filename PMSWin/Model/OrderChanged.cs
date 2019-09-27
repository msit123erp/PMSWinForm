using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Model
{
    public class OrderChanged
    {
        public int OrderChangedOID { get; set; }
        public string OrderID { get; set; }
        public string OrderChangedCategoryCode { get; set; }
        public System.DateTime RequestDate { get; set; }
        public string RequesterRole { get; set; }
        public string RequesterID { get; set; }
    }
}

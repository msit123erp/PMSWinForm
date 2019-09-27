using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Model
{
    public class SourceList
    {
        public int SourceListOID { get; set; }
        public string PartNumber { get; set; }
        public int Batch { get; set; }
        public decimal Discount { get; set; }
        public Nullable<System.DateTime> DiscountBeginDate { get; set; }
        public Nullable<System.DateTime> DiscountEndDate { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}

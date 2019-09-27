using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.Model
{
    public class CompanyInfo
    {
        public int CompanyInfoOID { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string TaxID { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
    }
}

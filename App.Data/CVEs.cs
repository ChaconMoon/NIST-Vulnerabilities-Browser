using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class CVEs
    {
        public List<Cve> CveList { get; set; } 
        public CVEs()
        {
            CveList = new List<Cve>();
        }
    }
}

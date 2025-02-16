using App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class Cve(string id_cve, string sourceIdentifier_cve, string published_cve, string lastModified_cve, string vulnStatus_cve, string description_cve, float impactStore_cve)
    {
        public string Id { get; set; } = id_cve;
        public string SourceIdentifier { get; set; } = sourceIdentifier_cve;
        public string Published { get; set; } = published_cve;
        public string LastModified { get; set; } = lastModified_cve;
        public string VulnStatus { get; set; } = vulnStatus_cve;
        public string Description { get; set; } = description_cve;
        public float ImpactScore { get; set; } = impactStore_cve;

        public override string ToString()
        {
            return Id + SourceIdentifier + Published + LastModified + VulnStatus + Description + ImpactScore + "\n";
        }
        public bool CheckCVE()
        {
            if (Id == "" || SourceIdentifier == "" || Published == "" || LastModified == "" || VulnStatus == "" || Description == "")
            {
                return false;
            }
            return true;
        }
    }
}

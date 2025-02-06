using App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class Cve
    {
        public string id { get; set; }
        public string sourceIdentifier { get; set; }
        public string published { get; set; }
        public string lastModified { get; set; }
        public string vulnStatus { get; set; }
        public string description { get; set; }
        public float impactScore { get; set; }

        public Cve(string id_cve, string sourceIdentifier_cve, string published_cve, string lastModified_cve, string vulnStatus_cve, string description_cve, float impactStore_cve)
        {
            id = id_cve;
            sourceIdentifier = sourceIdentifier_cve;
            published = published_cve;
            lastModified = lastModified_cve;
            vulnStatus = vulnStatus_cve;
            description = description_cve;
            impactScore = impactStore_cve;
        }
        public override string ToString()
        {
            return id + sourceIdentifier + published + lastModified + vulnStatus + description + impactScore + "\n";
        }
    }
}

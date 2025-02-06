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
    public string impactScore { get; set; }

}
}

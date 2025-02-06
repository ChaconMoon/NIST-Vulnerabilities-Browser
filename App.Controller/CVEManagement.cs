using App.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
namespace App.Controller
{
    public class CVEManagement
    {
        public HttpClient httpClient;

        public CVEManagement()
        {
            httpClient = new HttpClient();
        }

        public async Task<JObject> GetCVEInfo(String softwareName)
        {
            try
            {
                CVEs cves = new CVEs();
                string apiURL = "https://services.nvd.nist.gov/rest/json/cves/2.0?keywordSearch=" + softwareName;
                httpClient.DefaultRequestHeaders.Add("User-Agent", "My_NUnit_Project");
                HttpResponseMessage response = await httpClient.GetAsync(apiURL);
                string json = await response.Content.ReadAsStringAsync();
                return JObject.Parse(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public List<Cve> FormatCVEs(JObject cveList)
        {
            List<Cve> cves = new List<Cve>();
            JArray array_cve = new JArray();
            array_cve.Add(cveList["vulnerabilities"]);
            foreach (var cve in array_cve)
            {
                cves.Add(new Cve
                {
                    id = cve["cve_id"].ToString(),
                    sourceIdentifier = cve["summary"].ToString(),
                    published = cve["published_date"].ToString(),
                    lastModified = cve["last_modified_date"].ToString(),
                    vulnStatus = cve["cvss"].ToString(),
                    description = cve["cwe"].ToString(),
                    impactScore = cve["impact_score"].ToString()
                });
            }
            return cves;
        }

    }
}


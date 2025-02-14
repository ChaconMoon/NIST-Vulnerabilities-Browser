using App.Data;
using Moq;
using System.Data;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.RegularExpressions;
namespace App.Controller
{
    public class CVEManagement
    {
        public HttpClient httpClient;

        public CVEManagement()
        {
            httpClient = new HttpClient();
        }

        public virtual async Task<JsonDocument> GetCVEInfo(String softwareName)
        {
            try
            {
                CVEs cves = new CVEs();
                string apiURL = "https://services.nvd.nist.gov/rest/json/cves/2.0?keywordSearch=" + softwareName;
                httpClient.DefaultRequestHeaders.Add("User-Agent", "My_NUnit_Project");
                HttpResponseMessage response = await httpClient.GetAsync(apiURL);
                string json = await response.Content.ReadAsStringAsync();
                JsonDocument doc_json = JsonDocument.Parse(json);
                return doc_json;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /*TESTED*/
        public CVEs FormatJSONCVEs(JsonDocument doc_cve)
        {
            CVEs cves = new CVEs();
            foreach (JsonElement vulnerability in doc_cve.RootElement.GetProperty("vulnerabilities").EnumerateArray())
            {
                string description;
                string id;
                string sourceIdentifier;
                string pulished;
                string lastModified;
                string vulStatus;
                float impactScore;
                try
                {
                  description =  vulnerability.GetProperty("cve").GetProperty("descriptions").EnumerateArray().ElementAt(1).GetProperty("value").ToString();
                }

                catch
                {
                    description = vulnerability.GetProperty("cve").GetProperty("descriptions").EnumerateArray().ElementAt(0).GetProperty("value").ToString();
                }

                try
                {
                    id = vulnerability.GetProperty("cve").GetProperty("id").ToString();
                }

                catch
                {
                    id = "SIN VALOR";
                }

                try
                {
                    sourceIdentifier = vulnerability.GetProperty("cve").GetProperty("sourceIdentifier").ToString();
                }

                catch
                {
                    sourceIdentifier = "SIN VALOR";
                }

                try
                {
                   pulished = vulnerability.GetProperty("cve").GetProperty("published").ToString();
                } 
                catch
                {
                    pulished = "SIN VALOR";
                }

                try
                {
                    lastModified = vulnerability.GetProperty("cve").GetProperty("lastModified").ToString();
                }
                catch
                {
                    lastModified = "SIN VALOR";
                }

                try
                {
                    vulStatus = vulnerability.GetProperty("cve").GetProperty("vulnStatus").ToString();
                } 
                catch
                {
                    vulStatus = "SIN VALOR";
                }

                try
                {
                    CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                    culture.NumberFormat.NumberDecimalSeparator = ".";
                    impactScore = float.Parse(vulnerability.GetProperty("cve").GetProperty("metrics").GetProperty("cvssMetricV2").EnumerateArray().ElementAt(0).GetProperty("cvssData").GetProperty("baseScore").ToString());
                } 
                catch
                {
                    impactScore = float.NaN;
                }

                cves.CveList.Add(new Cve(
                id,
                sourceIdentifier,
                pulished,
                lastModified,
                vulStatus,
                description,
                impactScore
                    )
                );
            }
            return cves;
        }
    }
}


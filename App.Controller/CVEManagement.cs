using App.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;
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

        public async Task<JObject> GetCVEInfo()
        {
            try
            {
                CVEs cves = new CVEs();
                string apiURL = "https://services.nvd.nist.gov/rest/json/cves/2.0?keywordSearch=dotnet";
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
    }
}


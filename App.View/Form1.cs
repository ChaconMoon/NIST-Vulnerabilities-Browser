using App.Controller;
using App.Data;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
namespace App.View
{
    public partial class Form1 : Form
    {
        private CVEManagement cveManagement;
        private CVEs cves;
        public Form1()
        {
            InitializeComponent();
            cveManagement = new CVEManagement();
            cves = new CVEs();
        }

        private async void GetCVEs()
        {
            JObject str = await cveManagement.GetCVEInfo();
            textBox.Text = str["vulnerabilities"][0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetCVEs();
        }
    }
}

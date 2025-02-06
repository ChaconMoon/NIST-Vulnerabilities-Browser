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
            connecting_textLabel.Text = "Connecting to NIST...";
            JObject str = await cveManagement.GetCVEInfo(textBox.Text);
            textBox.Text = cveManagement.FormatCVEs(str).ToString();
            connecting_textLabel.Text = "Connected!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetCVEs();
        }
    }
}

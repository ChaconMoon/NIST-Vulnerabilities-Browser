using App.Controller;
using App.Data;
using System.Data;
using System.Text.Json;
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
            try
            {
                JsonDocument str = await cveManagement.GetCVEInfo(textBox.Text);
                string result = buildDataView(str);
                textBox.Text = result;
                connecting_textLabel.Text = "Connected!";
            }
            catch (NullReferenceException)
            {
                connecting_textLabel.Text = "Error en la petición Web";
            }

        }
        private string buildDataView(JsonDocument str)
        {
            string result = "";
            foreach (Cve cve in cveManagement.FormatJSONSVEs(str).CveList)
            {
                DataGridViewRow row = (DataGridViewRow)resultTable.Rows[0].Clone();
                row.Cells[0].Value = cve.id;
                row.Cells[1].Value = cve.published;
                row.Cells[2].Value = cve.lastModified;
                row.Cells[3].Value = cve.description;
                row.Cells[4].Value = cve.impactScore;
                resultTable.Rows.Add(row);

                result += cve.ToString() + " ";
            }
            return result;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            GetCVEs();
        }
    }
}

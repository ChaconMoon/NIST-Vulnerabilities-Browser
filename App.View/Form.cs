using App.Controller;
using App.Data;
using System.Data;
using System.Text.Json;
namespace App.View
{
    public partial class Form : System.Windows.Forms.Form
    {
        public CVEManagement cveManagement;
        /*TESTED*/
        public Form()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            cveManagement = new CVEManagement();
        }
        /*TESTED*/
        public async Task<string> GetCVEs()
        {
            connecting_textLabel.Text = "Connecting to NIST...";
            try
            {
                JsonDocument str = await cveManagement.GetCVEInfo(TextBoxSoftwareName.Text);
                string result = BuildDataView(str);
                connecting_textLabel.Text = "Connected!";
                return "Successful";
            }
            catch (NullReferenceException)
            {
                connecting_textLabel.Text = "Error en la petición Web";
                throw new NullReferenceException();
            }

        }
        public string BuildDataView(JsonDocument str)
        {
            foreach (Cve cve in CVEManagement.FormatJSONCVEs(str).CveList)
            {
                DataGridViewRow row = (DataGridViewRow)resultTable.Rows[0].Clone();
                row.Cells[0].Value = cve.Id;
                row.Cells[1].Value = cve.Published;
                row.Cells[2].Value = cve.LastModified;
                row.Cells[3].Value = cve.Description;
                row.Cells[4].Value = cve.ImpactScore;
                resultTable.Rows.Add(row);
            }
            return "Successful";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _ = GetCVEs();
            resultTable.Rows.Clear();
            resultTable.Refresh();
        }
    }
}

using Desktop.Services;
using Microsoft.Reporting.WinForms;

namespace Desktop.ViewReports
{
    public partial class ClientesViewReport : Form
    {
        ReportViewer _report;
        ClientesApiService clientesApiService = new ();
        public ClientesViewReport()
        {
            InitializeComponent();
            _report = new ReportViewer();
            _report.Dock = DockStyle.Fill;
            this.Controls.Add(_report);
        }

        private async void ClientesViewReport_Load(object sender, EventArgs e)
        {
            var clientes = await clientesApiService.GetAllAsync();
            _report.LocalReport.ReportEmbeddedResource = "Desktop.Reports.Clientes.rdlc";
            _report.LocalReport.DataSources.Add(new ReportDataSource("DSClientes", clientes));
            _report.SetDisplayMode(DisplayMode.PrintLayout);
            _report.ZoomMode = ZoomMode.Percent;
            _report.ZoomPercent = 100;

            _report.RefreshReport();
        }
    }
}

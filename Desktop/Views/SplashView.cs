
using Desktop.Services;
using Microsoft.Reporting.WinForms;
using Services.Models;

namespace Desktop.Views
{
    public partial class SplashView : Form
    {
        bool dataReady = false;
        bool printReady = false;

        public SplashView()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pbSplash.Value < 98)
                pbSplash.Increment(5);
            if(dataReady && printReady)
            {
                timer1.Enabled = false;
                this.Visible = false;
                var menuPrincipal = new MenuPrincipalView();
                menuPrincipal.ShowDialog();
                this.Close();
            }
            /*if (ConexionRealizada && ImpresionRealizada)
            {
                timer1.Enabled = false;
                this.Visible = false;
                var menuPrincipal = new MenuPrincipalView();
                menuPrincipal.ShowDialog();
                this.Close();
            }*/
        }

        private async void SplashView_Activated(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            var dataTask = LoadData();
            var printTask = PrintReport();
            await Task.WhenAll(dataTask, printTask);
        }

        private async Task LoadData()
        {
            await Task.Run(() =>
            {
                ClientesApiService clientesApiService = new();
                var clientes = clientesApiService.GetAllAsync().Result;
                dataReady = true;
            });
        }

        private async Task PrintReport()
        {
            await Task.Run(() =>
            {
                ClientesApiService clientesApiService = new();
                ReportViewer _report = new ReportViewer();
                var clientes = new List<Cliente>
                {
                    new Cliente { Id = 1, Firstname = "Juan", Lastname = "Pérez", Address = "Calle Falsa 1233", Dni = "29720301" }
                };
                _report.LocalReport.ReportEmbeddedResource = "Desktop.Reports.Clientes.rdlc";
                _report.LocalReport.DataSources.Add(new ReportDataSource("DSClientes", clientes));
                _report.SetDisplayMode(DisplayMode.PrintLayout);
                _report.ZoomMode = ZoomMode.Percent;
                _report.ZoomPercent = 100;

                _report.RefreshReport();
                printReady = true;
            });
        }
    }
}

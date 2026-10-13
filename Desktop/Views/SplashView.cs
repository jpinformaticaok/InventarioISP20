using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class SplashView : Form
    {
        bool ConexionRealizada = false;
        bool ImpresionRealizada = false;
        //CosmopolitaContext _context;

        public SplashView()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pbSplash.Value < 98)
                pbSplash.Increment(20);
            else
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

        private void SplashView_Load(object sender, EventArgs e)
        {

        }

        private void SplashView_Activated(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}

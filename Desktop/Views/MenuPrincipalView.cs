namespace Desktop.Views
{
    public partial class MenuPrincipalView : Form
    {
        public MenuPrincipalView()
        {
            InitializeComponent();
        }

        #region Codigo del boton de saludo
        private void BtnSaludo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hola, apretaste el boton!");
        }
        #endregion

        private void SubMenuSalirDelSistema_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubMenuArticulos_Click(object sender, EventArgs e)
        {
            ArticulosView articulosView = new ArticulosView();
            articulosView.MdiParent = this;
            articulosView.Show();
        }


        private void SubMenuCategorias_Click(object sender, EventArgs e)
        {
            CategoriasView categoriasView = new();
            categoriasView.MdiParent = this;
            categoriasView.Show();
        }

        private void SubMenuPrestamos_Click(object sender, EventArgs e)
        {
            PrestamosView prestamosView = new();
            prestamosView.MdiParent = this;
            prestamosView.Show();
        }

        private void SubMenuUbicaciones_Click(object sender, EventArgs e)
        {
            UbicacionesView ubicacionesView = new();
            ubicacionesView.MdiParent = this;
            ubicacionesView.Show();
        }
    }
}

using Services.Models;
using Desktop.Services;

namespace Desktop.Views
{
    public partial class ProvinciasApiView : Form
    {
        ProvinciasApiService provinciasService = new ProvinciasApiService();
        PaisesApiService paisesService = new PaisesApiService();
        Provincia? provinciaModificada;
        public ProvinciasApiView()
        {
            InitializeComponent();
            _ = LoadProvincias();
            _ = LoadCbPaises();
        }

        private async Task LoadCbPaises()
        {
            List<Pais> listaPaises = await paisesService.GetAllAsync();

            // Proyectamos a un objeto anónimo con los nombres de propiedad que queramos
            var paises = listaPaises
                .Select(l => new { Id = l.Id, Name = l.Name })
                .ToList();

            if (paises != null)
            {
                cbPaises.DisplayMember = "Name";
                cbPaises.ValueMember = "Id";
                cbPaises.DataSource = paises;
                cbPaises.SelectedIndex = -1;
            }
        }

        private async Task LoadProvincias()
        {
            var provincias = await provinciasService.GetAllAsync();
            if (provincias != null)
            {
                dataGridProvincias.DataSource = provincias;
            }
        }

        private async Task LoadDeleteds()
        {
            var provincias = await provinciasService.GetDeletedsAsync();
            if (provincias != null)
            {
                dataGridProvincias.DataSource = provincias;
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            var provincias = await provinciasService.GetAllWithFilterAsync(txtBusqueda.Text);
            if (provincias != null)
            {
                dataGridProvincias.DataSource = provincias;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.tabControl.SelectedTab = tabPageAgregarEditar;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.tabControl.SelectedTab = tabPageLista;
            ClearTextBox();
            provinciaModificada = null;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            bool provinciaGuardada;
            Provincia provincia = new Provincia
            {
                Name = txtProvincia.Text,
                PaisId = cbPaises.SelectedValue != null ? (int)cbPaises.SelectedValue : 0,
            };
            if (provinciaModificada == null)
            {
                provinciaGuardada = await provinciasService.AddProvinciaAsync(provincia);
            }
            else
            {
                provincia.Id = provinciaModificada.Id;
                provinciaGuardada = await provinciasService.UpdateProvinciaAsync(provincia);
            }

            if (!provinciaGuardada)
            {
                MessageBox.Show("Error al guardar la provincia");
                return;
            }
            MessageBox.Show("Provincia guardada correctamente");
            await LoadProvincias();
            ClearTextBox();
            tabControl.SelectedTab = tabPageLista;
            provinciaModificada = null;
        }

        private void ClearTextBox()
        {
            txtProvincia.Clear();
            cbPaises.SelectedIndex = -1;
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            // Capturamos la provincia seleccionada en la grilla
            if (dataGridProvincias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una provincia para modificar");
                return;
            }
            provinciaModificada = (Provincia)dataGridProvincias.CurrentRow.DataBoundItem;
            // LLenamos los campos de texto con los datos de la provincia seleccionada
            txtProvincia.Text = provinciaModificada.Name;
            if (provinciaModificada.PaisId != 0)
                cbPaises.SelectedValue = provinciaModificada.PaisId;
            // Cambiamos a la pestaña de agregar/editar
            tabControl.SelectedTab = tabPageAgregarEditar;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            //capturamos la provincia seleccionada en la grilla
            if (dataGridProvincias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una provincia para eliminar");
                return;
            }
            var provinciaAEliminar = (Provincia)dataGridProvincias.CurrentRow.DataBoundItem;
            //preguntamos si está seguro de eliminar la provincia
            var result = MessageBox.Show($"¿Está seguro de eliminar la provincia {provinciaAEliminar.Name}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                //eliminamos la provincia
                var provinciaEliminada = await provinciasService.DeleteProvinciaAsync((int)provinciaAEliminar.Id!);
                if (!provinciaEliminada)
                {
                    MessageBox.Show("Error al eliminar la provincia");
                    return;
                }
                MessageBox.Show($"Provincia {provinciaAEliminar.Name} eliminada correctamente");
                await LoadProvincias();
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            //chequeamos si la tecla presionada es Enter y pulsamos el botón de buscar
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar.PerformClick();
                e.Handled = true; // Evita que el sonido de "ding" se reproduzca
            }
        }

        private async void verEliminadosCheck_CheckedChanged(object sender, EventArgs e)
        {
            txtBusqueda.Enabled = !verEliminadosCheck.Checked;
            btnBuscar.Enabled = !verEliminadosCheck.Checked;
            btnNuevo.Enabled = !verEliminadosCheck.Checked;
            btnModificar.Enabled = !verEliminadosCheck.Checked;
            btnEliminar.Enabled = !verEliminadosCheck.Checked;
            btnRestaurar.Enabled = verEliminadosCheck.Checked;
            if (verEliminadosCheck.Checked)
            {
                await LoadDeleteds();
            }
            else
            {
                await LoadProvincias();
            }
        }

        private async void btnRestaurar_Click(object sender, EventArgs e)
        {
            //capturamos la provincia seleccionada en el DataGridView
            if (dataGridProvincias.CurrentRow != null)
            {
                var provinciaARestaurar = (Provincia)dataGridProvincias.CurrentRow.DataBoundItem;
                // Preguntamos al usuario si está seguro de restaurar la provincia
                var confirmResult = MessageBox.Show($"¿Está seguro de restaurar la provincia {provinciaARestaurar.Name}?", "Confirmar restauración", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    bool restauradoOk = await provinciasService.RestoreProvinciaAsync(provinciaARestaurar.Id);
                    if (!restauradoOk)
                    {
                        tabControl.SelectedTab = tabPageLista;
                    }
                    else
                    {
                        MessageBox.Show($"Provincia {provinciaARestaurar.Name} restaurada correctamente");
                        await LoadDeleteds();
                    }
                }
            }
        }
    }
}

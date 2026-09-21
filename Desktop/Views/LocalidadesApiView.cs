using Services.Models;
using Desktop.Services;

namespace Desktop.Views
{
    public partial class LocalidadesApiView : Form
    {
        LocalidadesApiService localidadesService = new LocalidadesApiService();
        ProvinciasApiService provinciasService = new ProvinciasApiService();
        PaisesApiService paisesService = new PaisesApiService();
        Localidad? localidadModificada;
        public LocalidadesApiView()
        {
            InitializeComponent();
            _ = LoadLocalidades();
            _ = LoadCbProvincias();
            _ = LoadCbPaises();
        }

        private async Task LoadCbPaises()
        {
            var paises = await paisesService.GetAllAsync();
            if (paises != null)
            {
                cbPaises.DataSource = paises;
                cbPaises.DisplayMember = "Name";
                cbPaises.ValueMember = "Id";
                cbPaises.SelectedIndex = -1;
            }
        }

        private async Task LoadCbProvincias()
        {
            var localidades = await localidadesService.GetAllAsync();
            if (localidades != null)
            {
                cbProvincias.DataSource = localidades;
                cbProvincias.DisplayMember = "Name";
                cbProvincias.ValueMember = "Id";
                cbProvincias.SelectedIndex = -1;
            }
        }

        private async Task LoadLocalidades()
        {
            var localidades = await localidadesService.GetAllAsync();
            if (localidades != null)
            {
                dataGridLocalidades.DataSource = localidades;
            }
        }

        private async Task LoadDeleteds()
        {
            var localidades = await localidadesService.GetDeletedsAsync();
            if (localidades != null)
            {
                dataGridLocalidades.DataSource = localidades;
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            var localidades = await localidadesService.GetAllWithFilterAsync(txtBusqueda.Text);
            if (localidades != null)
            {
                dataGridLocalidades.DataSource = localidades;
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
            localidadModificada = null;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            bool localidadGuardada;
            Localidad localidad = new Localidad
            {
                Name = txtLocalidad.Text,
                ProvinciaId = cbProvincias.SelectedValue != null ? (int)cbProvincias.SelectedValue : 0,
            };
            if (localidadModificada == null)
            {
                localidadGuardada = await localidadesService.AddLocalidadAsync(localidad);
            }
            else
            {
                localidad.Id = localidadModificada.Id;
                localidadGuardada = await localidadesService.UpdateLocalidadAsync(localidad);
            }

            if (!localidadGuardada)
            {
                MessageBox.Show("Error al guardar la localidad");
                return;
            }
            MessageBox.Show("Localidad guardada correctamente");
            await LoadLocalidades();
            ClearTextBox();
            tabControl.SelectedTab = tabPageLista;
            localidadModificada = null;
        }

        private void ClearTextBox()
        {
            txtLocalidad.Clear();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            // Capturamos la localidad seleccionada en la grilla
            if (dataGridLocalidades.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una localidad para modificar");
                return;
            }
            localidadModificada = (Localidad)dataGridLocalidades.CurrentRow.DataBoundItem;
            // LLenamos los campos de texto con los datos del cliente seleccionado
            txtLocalidad.Text = localidadModificada.Name;
            if (localidadModificada.ProvinciaId != 0)
                cbProvincias.SelectedValue = localidadModificada.ProvinciaId;
            // Cambiamos a la pestaña de agregar/editar
            tabControl.SelectedTab = tabPageAgregarEditar;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            //capturamos a la localidad seleccionada en la grilla
            if (dataGridLocalidades.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una localidad para eliminar");
                return;
            }
            var localidadAEliminar = (Localidad)dataGridLocalidades.CurrentRow.DataBoundItem;
            //preguntamos si está seguro de eliminar a la localidad
            var result = MessageBox.Show($"¿Está seguro de eliminar a la localidad {localidadAEliminar.Name}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                //eliminamos a la localidad
                var localidadEliminada = await localidadesService.DeleteLocalidadAsync((int)localidadAEliminar.Id!);
                if (!localidadEliminada)
                {
                    MessageBox.Show("Error al eliminar a la localidad");
                    return;
                }
                MessageBox.Show($"Localidad {localidadAEliminar.Name} eliminada correctamente");
                await LoadLocalidades();
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
                await LoadLocalidades();
            }
        }

        private async void btnRestaurar_Click(object sender, EventArgs e)
        {
            //capturamos a la localidad seleccionada en el DataGridView
            if (dataGridLocalidades.CurrentRow != null)
            {
                var localidadARestaurar = (Localidad)dataGridLocalidades.CurrentRow.DataBoundItem;
                // Preguntamos al usuario si está seguro de eliminar a la localidad
                var confirmResult = MessageBox.Show($"¿Está seguro de restaurar a la localidad {localidadARestaurar.Name}?", "Confirmar restauración", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    bool restauradoOk = await localidadesService.RestoreLocalidadAsync(localidadARestaurar.Id);
                    if (!restauradoOk)
                    {
                        tabControl.SelectedTab = tabPageLista;
                    }
                    else
                    {
                        MessageBox.Show($"Localidad {localidadARestaurar.Name} restaurada correctamente");
                        await LoadDeleteds();
                    }
                }
            }
        }
    }
}

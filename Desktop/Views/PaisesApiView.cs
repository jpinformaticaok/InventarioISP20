using Services.Models;
using Desktop.Services;

namespace Desktop.Views
{
    public partial class PaisesApiView : Form
    {
        PaisesApiService paisesService = new PaisesApiService();
        Pais? paisModificado;
        public PaisesApiView()
        {
            InitializeComponent();
            _ = LoadPaises();
        }

        private async Task LoadPaises()
        {
            var paises = await paisesService.GetAllAsync();
            if (paises != null)
            {
                dataGridPaises.DataSource = paises;
            }
        }

        private async Task LoadDeleteds()
        {
            var paises = await paisesService.GetDeletedsAsync();
            if (paises != null)
            {
                dataGridPaises.DataSource = paises;
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            var paises = await paisesService.GetAllWithFilterAsync(txtBusqueda.Text);
            if (paises != null)
            {
                dataGridPaises.DataSource = paises;
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
            paisModificado = null;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            bool paisGuardado;
            Pais pais = new Pais
            {
                Name = txtPais.Text,
            };
            if (paisModificado == null)
            {
                paisGuardado = await paisesService.AddPaisAsync(pais);
            }
            else
            {
                pais.Id = paisModificado.Id;
                paisGuardado = await paisesService.UpdatePaisAsync(pais);
            }

            if (!paisGuardado)
            {
                MessageBox.Show("Error al guardar el pais");
                return;
            }
            MessageBox.Show("Pais guardado correctamente");
            await LoadPaises();
            ClearTextBox();
            tabControl.SelectedTab = tabPageLista;
            paisModificado = null;
        }

        private void ClearTextBox()
        {
            txtPais.Clear();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            // Capturamos el pais seleccionado en la grilla
            if (dataGridPaises.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un pais para modificar");
                return;
            }
            paisModificado = (Pais)dataGridPaises.CurrentRow.DataBoundItem;
            // LLenamos los campos de texto con los datos del pais seleccionado
            txtPais.Text = paisModificado.Name;
            // Cambiamos a la pestaña de agregar/editar
            tabControl.SelectedTab = tabPageAgregarEditar;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            //capturamos el pais seleccionado en la grilla
            if (dataGridPaises.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un pais para eliminar");
                return;
            }
            var paisAEliminar = (Pais)dataGridPaises.CurrentRow.DataBoundItem;
            //preguntamos si está seguro de eliminar el pais
            var result = MessageBox.Show($"¿Está seguro de eliminar el pais {paisAEliminar.Name}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                //eliminamos el pais
                var paisEliminado = await paisesService.DeletePaisAsync((int)paisAEliminar.Id!);
                if (!paisEliminado)
                {
                    MessageBox.Show("Error al eliminar el pais");
                    return;
                }
                MessageBox.Show($"Pais {paisAEliminar.Name} eliminado correctamente");
                await LoadPaises();
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
                await LoadPaises();
            }
        }

        private async void btnRestaurar_Click(object sender, EventArgs e)
        {
            //capturamos el pais seleccionado en el DataGridView
            if (dataGridPaises.CurrentRow != null)
            {
                var paisARestaurar = (Pais)dataGridPaises.CurrentRow.DataBoundItem;
                // Preguntamos al usuario si está seguro de restaurar el pais
                var confirmResult = MessageBox.Show($"¿Está seguro de restaurar el pais {paisARestaurar.Name}?", "Confirmar restauración", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    bool restauradoOk = await paisesService.RestorePaisAsync(paisARestaurar.Id);
                    if (!restauradoOk)
                    {
                        tabControl.SelectedTab = tabPageLista;
                    }
                    else
                    {
                        MessageBox.Show($"Pais {paisARestaurar.Name} restaurado correctamente");
                        await LoadDeleteds();
                    }
                }
            }
        }
    }
}

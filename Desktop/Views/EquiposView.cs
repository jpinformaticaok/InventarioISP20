using Desktop.Models;
using Desktop.Services;

namespace Desktop.Views
{
    public partial class EquiposView : Form
    {
        EquiposService equiposService = new EquiposService();
        Equipo equipoModificado;

        TiposEquiposService tiposEquiposService = new TiposEquiposService();
        TipoEquipo tipoEquipoModificado;

        public EquiposView()
        {
            InitializeComponent();
            LoadEquipos();
            LoadTiposEquipos();
        }

        private async void LoadTiposEquipos()
        {
            var tiposEquipos = await tiposEquiposService.GetAllAsync();
            if (tiposEquipos != null)
            {
                cbTipoEquipo.DataSource = tiposEquipos;
                cbTipoEquipo.DisplayMember = "descripcion";
                cbTipoEquipo.ValueMember = "id_tipo_equipo";
            }
        }

        private async Task LoadEquipos()
        {
            var clientes = await equiposService.GetAllAsync();
            if (clientes != null)
            {
                dataGridEquipos.DataSource = clientes;
            }
        }

        private void ClearTextBox()
        {
            txtMarca.Clear();
            txtModelo.Clear();
            txtNumeroSerie.Clear();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            var equipos = await equiposService.GetAllWithFilterAsync(txtBusqueda.Text);
            if (equipos != null)
            {
                dataGridEquipos.DataSource = equipos;
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
            equipoModificado = null;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //capturamos el cliente seleccionado en el DataGridView
            if (dataGridEquipos.CurrentRow != null)
            {
                equipoModificado = (Equipo)dataGridEquipos.CurrentRow.DataBoundItem;
                //llenamos los campos del formulario con los datos del cliente seleccionado
                txtMarca.Text = equipoModificado.marca;
                txtModelo.Text = equipoModificado.modelo;
                txtNumeroSerie.Text = equipoModificado.numero_serie;
                //llenamos el combobox con el tipo de equipo del cliente seleccionado
                cbTipoEquipo.SelectedValue = equipoModificado.id_tipo_equipo;
                //cambiamos a la pestaña de agregar/editar
                tabControl.SelectedTab = tabPageAgregarEditar;
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

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            //capturamos el cliente seleccionado en el DataGridView
            if (dataGridEquipos.CurrentRow != null)
            {
                var equipoAEliminar = (Equipo)dataGridEquipos.CurrentRow.DataBoundItem;
                // Preguntamos al usuario si está seguro de eliminar el cliente
                var confirmResult = MessageBox.Show($"¿Está seguro de eliminar al equipo {equipoAEliminar.marca} {equipoAEliminar.modelo}?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    bool borradoOk = await equiposService.DeleteEquipoAsync(equipoAEliminar.id_equipo);
                    if (!borradoOk)
                    {
                        tabControl.SelectedTab = tabPageLista;
                    }
                    else
                    {
                        MessageBox.Show($"Equipo {equipoAEliminar.marca} {equipoAEliminar.modelo} eliminado correctamente");
                        LoadEquipos();
                    }
                }
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            bool equipoGuardado;
            Equipo equipo = new Equipo
            {
                marca = txtMarca.Text,
                modelo = txtModelo.Text,
                numero_serie = txtNumeroSerie.Text,
                id_tipo_equipo = (long)cbTipoEquipo.SelectedValue
            };
            if (equipoModificado == null)
            {
                //equipo.id_equipo = int;
                equipoGuardado = await equiposService.AddEquipoAsync(equipo);
            }
            else
            {
                equipo.id_equipo = equipoModificado.id_equipo;
                equipo.created_at = equipoModificado.created_at;
                equipoGuardado = await equiposService.UpdateEquipoAsync(equipo);
            }

            if (equipoGuardado)
            {
                MessageBox.Show("Equipo guardado correctamente");
                LoadEquipos();
                ClearTextBox();
                tabControl.SelectedTab = tabPageLista;
            }
            else
            {
                MessageBox.Show("Error al guardar el equipo");
            }
        }

        private void btnTiposEquipo_Click(object sender, EventArgs e)
        {
            TiposEquiposView tiposEquiposView = new();
            tiposEquiposView.ShowDialog();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                this.SelectNextControl(
                    this.ActiveControl,
                    true,
                    true,
                    true,
                    true);

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private async void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBusqueda.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto))
            {
                btnBuscar.PerformClick();  // Muestra todos los registros
            }
            //else
            //{
            //    await FiltrarDatos(texto); // Aplica el filtro
            //}
        }
    }
}

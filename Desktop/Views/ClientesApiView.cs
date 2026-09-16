using Services.Models;
using Desktop.Services;

namespace Desktop.Views
{
    public partial class ClientesApiView : Form
    {
        ClientesApiService clientesService = new ClientesApiService();
        Cliente? clienteModificado;
        public ClientesApiView()
        {
            InitializeComponent();
            _ = LoadClientes();
        }

        private async Task LoadClientes()
        {
            var clientes = await clientesService.GetAllAsync();
            if (clientes != null)
            {
                dataGridClientes.DataSource = clientes;
            }
        }

        private async Task LoadDeleteds()
        {
            var clientes = await clientesService.GetDeletedsAsync();
            if (clientes != null)
            {
                dataGridClientes.DataSource = clientes;
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            var clientes = await clientesService.GetAllWithFilterAsync(txtBusqueda.Text);
            if (clientes != null)
            {
                dataGridClientes.DataSource = clientes;
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
            clienteModificado = null;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            bool clienteGuardado;
            Cliente cliente = new Cliente
            {
                Firstname = txtNombre.Text,
                Lastname = txtApellido.Text,
                Dni = txtDni.Text,
                Address = txtDireccion.Text,
                LocalidadId = 1
            };
            if (clienteModificado == null)
            {
                clienteGuardado = await clientesService.AddClienteAsync(cliente);
            }
            else
            {
                cliente.Id = clienteModificado.Id;
                cliente.Created_at = clienteModificado.Created_at;
                cliente.LocalidadId = clienteModificado.LocalidadId;
                clienteGuardado = await clientesService.UpdateClienteAsync(cliente);
            }

            if (!clienteGuardado)
            {
                MessageBox.Show("Error al guardar el cliente");
                return;
            }
            MessageBox.Show("Cliente guardado correctamente");
            await LoadClientes();
            ClearTextBox();
            tabControl.SelectedTab = tabPageLista;
            clienteModificado = null;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClearTextBox()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtDireccion.Clear();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            // Capturamos el cliente seleccionado en la grilla
            if (dataGridClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente para modificar");
                return;
            }
            clienteModificado = (Cliente)dataGridClientes.CurrentRow.DataBoundItem;
            // LLenamos los campos de texto con los datos del cliente seleccionado
            txtNombre.Text = clienteModificado.Firstname;
            txtApellido.Text = clienteModificado.Lastname;
            txtDni.Text = clienteModificado.Dni;
            txtDireccion.Text = clienteModificado.Address;
            // Cambiamos a la pestaña de agregar/editar
            tabControl.SelectedTab = tabPageAgregarEditar;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            //capturamos el cliente seleccionado en la grilla
            if (dataGridClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente para eliminar");
                return;
            }
            var clienteAEliminar = (Cliente)dataGridClientes.CurrentRow.DataBoundItem;
            //preguntamos si está seguro de eliminar el cliente
            var result = MessageBox.Show($"¿Está seguro de eliminar al cliente {clienteAEliminar.Firstname} {clienteAEliminar.Lastname}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                //eliminamos el cliente
                var clienteEliminado = await clientesService.DeleteClienteAsync((int)clienteAEliminar.Id!);
                if (!clienteEliminado)
                {
                    MessageBox.Show("Error al eliminar el cliente");
                    return;
                }
                MessageBox.Show($"Cliente {clienteAEliminar.Firstname} {clienteAEliminar.Lastname} eliminado correctamente");
                await LoadClientes();
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
                await LoadClientes();
            }
        }

        private async void btnRestaurar_Click(object sender, EventArgs e)
        {
            //capturamos el cliente seleccionado en el DataGridView
            if (dataGridClientes.CurrentRow != null)
            {
                var clienteARestaurar = (Cliente)dataGridClientes.CurrentRow.DataBoundItem;
                // Preguntamos al usuario si está seguro de eliminar el cliente
                var confirmResult = MessageBox.Show($"¿Está seguro de restaurar al cliente {clienteARestaurar.Firstname} {clienteARestaurar.Lastname}?", "Confirmar restauración", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    bool restauradoOk = await clientesService.RestoreClienteAsync(clienteModificado.Id);
                    if (!restauradoOk)
                    {
                        tabControl.SelectedTab = tabPageLista;
                    }
                    else
                    {
                        MessageBox.Show($"Cliente {clienteARestaurar.Firstname} {clienteARestaurar.Lastname} restaurado correctamente");
                        await LoadDeleteds();
                    }
                }
            }
        }
    }
}

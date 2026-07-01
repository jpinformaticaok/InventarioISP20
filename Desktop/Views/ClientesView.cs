using Desktop.Models;
using Desktop.Services;

namespace Desktop.Views
{
    public partial class ClientesView : Form
    {
        ClientesService clientesService = new ClientesService();
        Cliente clienteModificado;
        public ClientesView()
        {
            InitializeComponent();
            LoadClientes();
        }

        private async void LoadClientes()
        {
            var clientes = await clientesService.GetAllAsync();
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
                firstname = txtNombre.Text,
                lastname = txtApellido.Text,
                dni = txtDni.Text,
                address = txtDireccion.Text,
            };
            if (clienteModificado == null)
            {
                clienteGuardado = await clientesService.AddClienteAsync(cliente);
            }
            else
            {
                cliente.id = clienteModificado.id;
                cliente.created_at = clienteModificado.created_at;
                clienteGuardado = await clientesService.UpdateClienteAsync(cliente);
            }

            if (clienteGuardado)
            {
                MessageBox.Show("Cliente guardado correctamente");
                LoadClientes();
                ClearTextBox();
                tabControl.SelectedTab = tabPageLista;
            }
            else
            {
                MessageBox.Show("Error al guardar el cliente");
            }
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //capturamos el cliente seleccionado en el DataGridView
            if (dataGridClientes.CurrentRow != null)
            {
                clienteModificado = (Cliente)dataGridClientes.CurrentRow.DataBoundItem;
                //llenamos los campos del formulario con los datos del cliente seleccionado
                txtNombre.Text = clienteModificado.firstname;
                txtApellido.Text = clienteModificado.lastname;
                txtDni.Text = clienteModificado.dni;
                txtDireccion.Text = clienteModificado.address;
                //cambiamos a la pestaña de agregar/editar
                tabControl.SelectedTab = tabPageAgregarEditar;
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            //capturamos el cliente seleccionado en el DataGridView
            if (dataGridClientes.CurrentRow != null)
            {
                var clienteAEliminar = (Cliente)dataGridClientes.CurrentRow.DataBoundItem;
                // Preguntamos al usuario si está seguro de eliminar el cliente
                var confirmResult = MessageBox.Show($"¿Está seguro de eliminar al cliente {clienteAEliminar.firstname} {clienteAEliminar.lastname}?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    bool borradoOk = await clientesService.DeleteClienteAsync(clienteModificado.id);
                    if (!borradoOk)
                    {
                        tabControl.SelectedTab = tabPageLista;
                    }
                    else
                    {
                        MessageBox.Show($"Cliente {clienteAEliminar.firstname} {clienteAEliminar.lastname} eliminado correctamente");
                        LoadClientes();
                    }
                }
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
    }
}

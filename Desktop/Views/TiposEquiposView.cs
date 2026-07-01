using Desktop.Models;
using Desktop.Services;
using System.ComponentModel;

namespace Desktop.Views
{
    public partial class TiposEquiposView : Form
    {
        private TiposEquiposService tiposEquiposService = new();
        public TiposEquiposView()
        {
            InitializeComponent();
            dgvTiposEquipos.ReadOnly = false;
            dgvTiposEquipos.AllowUserToAddRows = true;
            dgvTiposEquipos.AllowUserToDeleteRows = true;

            CargarGrid();
        }

        private async Task CargarGrid()
        {
            BindingList<TipoEquipo> datos;
            var lista = await tiposEquiposService.GetAllAsync();
            datos = new BindingList<TipoEquipo>(lista);

            dgvTiposEquipos.AutoGenerateColumns = true;
            dgvTiposEquipos.DataSource = datos;

            dgvTiposEquipos.Columns["id_tipo_equipo"].ReadOnly = true;
        }

        private async void dgvTiposEquipos_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var item = e.Row.DataBoundItem as TipoEquipo;

            if (item == null)
                return;

            if (item.id_tipo_equipo == 0)
                return;

            DialogResult r = MessageBox.Show("¿Eliminar tipo de equipo?", "Confirmar", MessageBoxButtons.YesNo);

            if (r != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }
            //messagebox que muestra el id del tipo de equipo que se va a eliminar
            await tiposEquiposService.DeleteTipoEquipoAsync(item.id_tipo_equipo);
        }

        private async void dgvTiposEquipos_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dgvTiposEquipos.Rows[e.RowIndex];

            if (row.IsNewRow)
                return;

            TipoEquipo item = row.DataBoundItem as TipoEquipo;

            if (item == null)
                return;

            if (string.IsNullOrWhiteSpace(item.descripcion))
                return;

            // NUEVO
            if (item.id_tipo_equipo == null)
            {
                await tiposEquiposService.AddTipoEquipoAsync(item);
            }
            // MODIFICAR
            else
            {
                await tiposEquiposService.UpdateTipoEquipoAsync(item);
            }
            await CargarGrid();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dgvTiposEquipos.CurrentRow == null)
            {
                MessageBox.Show("No hay ninguna fila seleccionada.");
                return;
            }

            var item = (TipoEquipo)dgvTiposEquipos.CurrentRow.DataBoundItem;

            MessageBox.Show($"ID: {item.id_tipo_equipo}");
        }
    }
}

using Consola.Class;


namespace Desktop.Views
{
    public partial class ArticulosView : Form
    {
        public ArticulosView()
        {
            InitializeComponent();
        }

        private void BtnAgregarAlumno_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno("Juan", "Aguero");
            ListAlumnos.Items.Add(alumno);
        }
    }
}

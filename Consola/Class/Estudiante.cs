
namespace Consola.Class
{
    public class Estudiante : Persona
    {
        //public string Propiedad1 { get; set; } // Creada automáticamente una propiedad con un campo de respaldo privado

        //private string? nombre; // Campo privado que respalda la propiedad Nombre

        public string? Nombre // Propiedad con un campo de respaldo privado
        {
            get { return nombre?.ToUpper(); }
            set { nombre = value; }
        }

        public string Domicilio { get; set; } = string.Empty; // Propiedad con un valor predeterminado de cadena vacía
        public int Edad { get; set; }

        // Creamos una propiedad llamada DatosCompletos que concatena todos los datos del estudiante y los devuelve al llamarla
        public string DatosCompletos
        {
            get { return $"Hola, soy el estudiante {Nombre} y tengo {Edad} años."; }
        }

        public void Saludar()
        {
            Console.WriteLine($"Hola, soy el estudiante {Nombre} y tengo {Edad} años.");
        }

        public override void Hablar()
        {
            Console.WriteLine($"Hola, soy estudiante!!");
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}

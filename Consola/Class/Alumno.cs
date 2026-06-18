using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola.Class
{
    public partial class Alumno
    {
        static int instancias_de_alumnos = 0; // Variable estática que cuenta la cantidad de instancias de la clase Alumno que se han creado
        string nombre;  // Por default es private, no se puede acceder desde fuera de la clase
        string apellido;
        int dni;
        DateOnly fecha_nacimiento; // DateOnly es un tipo de dato que representa solo la fecha, sin la hora. Es útil para almacenar fechas de nacimiento, fechas de eventos, etc.

        public Alumno()
        {
            
        }
        // Constructor de la clase Alumno, se ejecuta cada vez que se crea un nuevo objeto de tipo Alumno
        public Alumno(string nombre, string apellido, int dni=0, DateOnly fecha_nacimiento = new DateOnly())
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.fecha_nacimiento = fecha_nacimiento;

            instancias_de_alumnos++; // Incrementamos el contador de instancias cada vez que se crea un nuevo alumno
        }

        // Método que imprime la ficha de datos del alumno, devuelve un string con la información formateada
        public string ImpresionFichaDeDatos()
        {
            return $"Nombre: {nombre} {apellido}\nDNI: {dni}\nFecha de nacimiento: {fecha_nacimiento.ToString("dd/MM/yyyy")}";
        }

        public override string ToString()
        {
            return $"{nombre} {apellido}";
        }
    }
}

using Consola.Class;

public class Program
{
    private static void Main(string[] args)
    {
        //CreamosVariables();

        //CreamosMatricesYVectores();

        //Console.WriteLine("Probando imprimir algo en la pantalla");
        //ImpresionDeParametros(args);

        //CapturaDeValoresDelUsuario();
        //CreamosAlumnosEImprimimosSuFichaDeDatos();

        //CreamosEstudiantesEImprimimosSuSaludo();

        //ProbamosMetodosConDiferentesValoresDeRetorno();
        //Ejercicio1();
        /*Bicicleta bici = new ();
        bici.velocidad = 20;
        bici.tieneCampanilla = true;
        Console.WriteLine($"La bicicleta tiene una velocidad de {bici.velocidad} km/h y {(bici.tieneCampanilla ? "tiene" : "no tiene")} campanilla.");*/
        Ejercicio3();
        Console.ReadKey();
    }

    private static void Ejercicio3()
    {
        Persona[] grupo = new Persona[2];
        Persona persona1 = new ();
        Estudiante estudiante1 = new ();
        grupo[0] = persona1;
        grupo[1] = estudiante1;
        foreach (Persona persona in grupo)
        {
                persona.Hablar();
        }
        estudiante1.Nombre = "Juan Pablo";
        DateTime ahora = new DateTime();
        ahora = DateTime.Now;
        Console.WriteLine(ahora);
        Object prueba = new Object();
        Console.WriteLine(prueba.ToString());
        Console.WriteLine(estudiante1.ToString());
        
    }

    private static void Ejercicio1()
    {
        Persona persona1 = new();
        persona1.nombre = "Juan Pablo";
        Console.WriteLine($"La edad de {persona1.nombre}"/* es: {persona1.edad}"*/);
        persona1.CumplirAnios();
        
    }

    private static void ProbamosMetodosConDiferentesValoresDeRetorno()
    {
        AlumnoCurso alumno1 = new AlumnoCurso("Lucía", "Gómez", 19);

        alumno1.AgregarNota(8);
        alumno1.AgregarNota(7.5);
        alumno1.AgregarNota(9);
        alumno1.AgregarNota(3);
        alumno1.AgregarNota(5);

        string nombreCompleto = alumno1.ObtenerNombreCompleto();
        int cantidadNotas = alumno1.ObtenerCantidadDeNotas();
        double promedio = alumno1.CalcularPromedio();
        bool aprobado = alumno1.EstaAprobado();
        char inicial = alumno1.ObtenerInicial();
        DateTime fechaConsulta = alumno1.ObtenerFechaConsulta();
        List<double> notas = alumno1.ObtenerNotas();
        int materiasDesaprobadas = alumno1.ContarMateriasDesaprobadas();
        int materiasAprobadas = alumno1.ContarMateriasAprobadas();
        string aprobo = alumno1.AproboElCurso();

        Console.WriteLine("Nombre completo: " + nombreCompleto);
        Console.WriteLine("Cantidad de notas: " + cantidadNotas);
        Console.WriteLine("Promedio: " + promedio);
        Console.WriteLine("¿Está aprobado?: " + aprobado);
        Console.WriteLine("Inicial: " + inicial);
        Console.WriteLine("Fecha de consulta: " + fechaConsulta);

        Console.WriteLine("Materias desaprobadas: " + materiasDesaprobadas);
        Console.WriteLine("Materias aprobadas: " + materiasAprobadas);
        Console.WriteLine(aprobo + " en 2026");
    }

    private static void CreamosEstudiantesEImprimimosSuSaludo()
    {
        Estudiante estudiante1 = new Estudiante();
        estudiante1.Nombre = "Juan Pablo";
        estudiante1.Edad = 43;
        estudiante1.Domicilio = "Bv. Roque Saenz Peña 2119";
        Console.WriteLine(estudiante1.DatosCompletos);
        //estudiante1.Saludar();
    }

    private static void CreamosAlumnosEImprimimosSuFichaDeDatos()
    {
        Alumno alumno = new Alumno("Juan Pablo", "Aguero", 29720301, new DateOnly(1982, 8, 12));
        Console.WriteLine(alumno.ImpresionFichaDeDatos());

        Alumno alumno2 = new Alumno("Maria Jose", "Longoni", 29720301, new DateOnly(1983, 2, 17));
        Console.WriteLine(alumno.ImpresionFichaDeDatos());

        Alumno alumno3 = new Alumno("Marcelo", "Albertissi", 29720301, new DateOnly(1978, 4, 10));
        Console.WriteLine(alumno.ImpresionFichaDeDatos());

        // Imprimimos la cantidad de instancias de alumnos creadas
        Console.WriteLine(Alumno.ImprimirCantidadDeInstancias());
    }

    private static void CreamosMatricesYVectores()
    {
        // Creamos un vector de 12 meses del año
        string[] meses = new string[12] { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        // Creamos una matriz de 3x2 con nombres y apellidos
        string[,] nosotros = new string[3, 2] { { "Juan", "Aguero" }, { "Majo", "Longoni" }, { "Marcelo", "Albertissi"} };

        meses[0] = "ENERO";
        meses[11] = "DICIEMBRE";

        nosotros[1, 0] = "MARIA JOSE";
        nosotros[0, 1] = "BARRIOS";

        int[] edades = [ 20, 25, 30, 35, 40 ];
    }

    private static void CapturaDeValoresDelUsuario()
    {
        Console.Write("Ingrese el año de su nacimiento: ");
        string? anio_nacimiento = Console.ReadLine();
        int anio = Convert.ToInt32(anio_nacimiento);
        int edad = DateTime.Now.Year - anio;
        Console.WriteLine($"Su edad es aproximada es: {edad}");
    }

    private static void ImpresionDeParametros(string[] args)
    {
        if (args.Length > 1)
            Console.WriteLine($"Hola: {args[0]} {args[1]}");
    }

    private static void CreamosVariables()
    {
        int numero = 10;
        int numero2;

        numero2 = 20;
        int numero3 = 30;
    }
}
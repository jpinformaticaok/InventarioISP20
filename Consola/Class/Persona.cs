
namespace Consola.Class
{
    public class Persona
    {
        public string nombre = string.Empty;
        private int edad = 0;
        public void CumplirAnios()
        {
            edad++; //edad = edad + 1  edad += 1
            Console.WriteLine($"Tengo {edad} años.");
        }

        public virtual void Hablar()
        {
            Console.WriteLine($"Hola!!!!.");
        }
    }
}

using ClassLibrary;
using ClassLibrary.Excepciones;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                OtraClase otraClase = new OtraClase();
            }
            catch (MiException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
            }
        }
    }
}

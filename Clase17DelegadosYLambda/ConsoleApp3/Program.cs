using System.Threading.Channels;

namespace ConsoleApp3
{
    internal class Program
    {
        public delegate void Delegado(string s);
        static void Main(string[] args)
        {
            Delegado delegado = Notificar;
            delegado("Hola Soy el Delegado");          
        }
        static void Notificar(string s)
        {
            Console.WriteLine(s);
        }
    }
}

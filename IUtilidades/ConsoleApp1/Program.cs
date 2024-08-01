using ClassLibrary;
using ClassLibrary1;
using ClassLibrary1.DBO;
using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Auto auto = new Auto("MTP350", "FORD", DateTime.Now, 500, ETipoAuto.Urbano);
            List<Vehiculo> vehiculos = new List<Vehiculo> { auto };
            Auto auto2 = new Auto();
            Console.WriteLine(auto.HoraEgreso);
            //JsonSerializadorYDeseralizador<List<Vehiculo>> jsonSerializadorYDeseralizador = new JsonSerializadorYDeseralizador<List<Vehiculo>>();
            //string path = "C:\\Users\\ezequ\\source\\repos\\IUtilidades\\ConsoleApp1\\Archivos";
            //path = Path.Join(path, $"{Path.PathSeparator}Vehiculo.json");
            //jsonSerializadorYDeseralizador.Serializar(path, vehiculos);
            ////jsonSerializadorYDeseralizador.Deserializar(path, out auto2);
            //Console.WriteLine(auto2.ToString());

        }
    }
}

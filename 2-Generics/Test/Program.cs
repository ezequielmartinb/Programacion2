using ClassLibrary;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Torneo<EquipoFutbol> torneoFutbol = new Torneo<EquipoFutbol>("LPF");
            Torneo<EquipoBasquet> torneoBasquet = new Torneo<EquipoBasquet>("NBA");

            EquipoFutbol equipo1 = new EquipoFutbol("River Plate", new DateTime(1901, 05, 25));
            EquipoFutbol equipo2 = new EquipoFutbol("Boca Juniors", new DateTime(1905, 04, 03));
            EquipoFutbol equipo3 = new EquipoFutbol("Independiente", new DateTime(1905, 01, 01));

            EquipoBasquet equipo4 = new EquipoBasquet("Lakers", new DateTime(1947, 01, 01));
            EquipoBasquet equipo5 = new EquipoBasquet("Bulls", new DateTime(1966, 01, 19));
            EquipoBasquet equipo6 = new EquipoBasquet("Lakers", new DateTime(1989, 11, 03));

            if (torneoBasquet + equipo4)
            {
                Console.WriteLine($"Se agrego el equipo {equipo4.Ficha()} correctamente");
            }
            if (torneoBasquet + equipo5)
            {
                Console.WriteLine($"Se agrego el equipo {equipo5.Ficha()} correctamente");
            }
            if (torneoBasquet + equipo6)
            {
                Console.WriteLine($"Se agrego el equipo {equipo6.Ficha()} correctamente");
            }
            if (torneoFutbol + equipo1)
            {
                Console.WriteLine($"Se agrego el equipo {equipo1.Ficha()} correctamente");
            }
            if (torneoFutbol + equipo2)
            {
                Console.WriteLine($"Se agrego el equipo {equipo2.Ficha()} correctamente");
            }
            if (torneoFutbol + equipo3)
            {
                Console.WriteLine($"Se agrego el equipo {equipo3.Ficha()} correctamente");
            }
            Console.WriteLine(torneoFutbol.Mostrar());
            Console.WriteLine();
            Console.WriteLine(torneoBasquet.Mostrar());
            if (torneoFutbol + equipo3 == false)
            {
                Console.WriteLine($"NO se agrego el equipo {equipo3.Ficha()} correctamente PORQUE YA EXISTE");
            }
            Console.WriteLine(torneoFutbol.Mostrar());

            Console.WriteLine(torneoFutbol.JugarPartido);
            Console.WriteLine(torneoFutbol.JugarPartido);
            Console.WriteLine(torneoFutbol.JugarPartido);
            Console.WriteLine("");
            Console.WriteLine(torneoBasquet.JugarPartido);
            Console.WriteLine(torneoBasquet.JugarPartido);
            Console.WriteLine(torneoBasquet.JugarPartido);

        }
    }
}

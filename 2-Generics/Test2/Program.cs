using ClassLibrary2;

namespace Test2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Recibo recibo1 = new Recibo();
            Factura factura1 = new Factura(123);
            Factura factura2 = new Factura(456);

            Contabilidad<Factura, Recibo> contabilidad = new Contabilidad<Factura, Recibo>();

            contabilidad += recibo1;
            contabilidad += factura1;
            contabilidad += factura2;
            Console.WriteLine("EGRESOS: ");
            foreach (Documento item in contabilidad.Egresos)            {

                Console.WriteLine(item.Numero);
            }
            Console.WriteLine("INGRESOS: ");
            foreach (Documento item in contabilidad.Ingresos)
            {
                Console.WriteLine(item.Numero);
            }
        }
    }
}

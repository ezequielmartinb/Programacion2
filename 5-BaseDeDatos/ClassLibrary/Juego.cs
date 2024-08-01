namespace ClassLibrary
{
    public class Juego
    {
        private int codigoJuego;
        private int codigoUsuario;
        private string genero;
        private string nombre;
        private double precio;

        public Juego(string nombre, double precio, string genero, int codigoUsuario)
        {
            this.codigoUsuario = codigoUsuario;
            this.genero = genero;
            this.nombre = nombre;
            this.precio = precio;
        }

        public Juego(string nombre, double precio, string genero, int codigoJuego, int codigoUsuario) : this(nombre, precio, genero, codigoUsuario)
        {
            this.codigoJuego = codigoJuego;
        }

        public int CodigoJuego { get => codigoJuego; }
        public int CodigoUsuario { get => codigoUsuario; }
        public string Genero { get => genero; }
        public string Nombre { get => nombre; }
        public double Precio { get => precio; }
    }
}

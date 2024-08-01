namespace ClassLibrary
{
    public delegate void DelegadoString(string msg);
    public class Persona
    {
        private string apellido;
        private string nombre;
        public event DelegadoString EventoString;

        public Persona()
        {
            this.apellido = String.Empty;
            this.Nombre = String.Empty;
        }

        public string Apellido { get => apellido; set => apellido = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public string Mostrar()
        {
            this.EventoString.Invoke($"{this.nombre} {this.apellido}");
            return $"{this.nombre} {this.apellido}";
        }

    }
}

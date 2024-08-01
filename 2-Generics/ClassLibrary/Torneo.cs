using System.Numerics;
using System.Text;

namespace ClassLibrary
{
    public class Torneo<T> where T : Equipo
    {
        private List<T> equipos;
        private string nombre;

        public Torneo()
        {
            this.equipos = new List<T>();
        }
        public string JugarPartido
        {
            get
            {
                Random rnd = new Random();
                T equipo1;
                T equipo2;

                do
                {
                    equipo1 = equipos[rnd.Next(0, equipos.Count)];
                    equipo2 = equipos[rnd.Next(0, equipos.Count)];
                } while (equipo1 == equipo2);
                return CalcularPartido(equipo1, equipo2);

            }
        }
        public Torneo(string nombre) : this()
        {
            this.nombre = nombre;
        }
        public static bool operator ==(Torneo<T> torneo, T equipo)
        {
            foreach (T item in torneo.equipos)
            {
                if (item == equipo)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Torneo<T> torneo, T equipo)
        {
            return !(torneo == equipo);
        }
        public static bool operator +(Torneo<T> torneo, T equipo)
        {
            if (torneo != equipo && torneo is not null && equipo is not null)
            {
                torneo.equipos.Add(equipo);
                return true;
            }
            return false;
        }
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.nombre);
            foreach (T item in equipos)
            {
                sb.AppendLine(item.Ficha());
            }
            return sb.ToString();
        }
        private string CalcularPartido(T e1, T e2)
        {
            Random rnd = new Random();

            if (e1 != e2)
            {
                return $"{e1.Nombre} {rnd.Next(0, 10)} - {rnd.Next(0, 10)} {e2.Nombre}";
            }
            return "No puede jugar un equipo contra si mismo";
        }
    }
}

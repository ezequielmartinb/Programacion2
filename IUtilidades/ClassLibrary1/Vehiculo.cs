using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [JsonConverter(typeof(Vehiculo))]    
    public abstract class Vehiculo
    {
        private string patente;
        private string marca;
        private DateTime horaIngreso;
        private DateTime horaEgreso;
        public Vehiculo()
        {
            this.horaEgreso = new DateTime();
            this.horaIngreso = new DateTime();
            this.patente = string.Empty;
            this.marca = string.Empty;
        }
        public Vehiculo(string patente, string marca)
        {
            this.patente = patente;
            this.marca = marca;
        }
        public Vehiculo(string patente, string marca, DateTime horaIngreso) : this(patente, marca)
        {
            this.horaIngreso = horaIngreso;
            this.horaEgreso = new DateTime(1754, 1, 1, 12, 0, 0);
        }
        public Vehiculo(DateTime horaIngreso, DateTime horaEgreso, string patente, string marca) : this(patente, marca, horaIngreso)
        {
            this.horaEgreso = horaEgreso;
        }
        public DateTime HoraIngreso { get => horaIngreso; set => horaIngreso = value; }
        public DateTime HoraEgreso
        {
            get => this.horaEgreso;
            set
            {
                if (value > this.horaIngreso)
                {
                    this.horaEgreso = value;
                }
            }
        }
        public string Patente { get => patente; set => patente = value; }
        public string Marca { get => marca; set => marca = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Patente: {this.Patente}");
            sb.AppendLine($"Marca: {this.marca}");
            sb.AppendLine($"Hora Ingreso: {this.horaIngreso}");
            if (this.horaEgreso > this.horaIngreso)
            {
                sb.AppendLine($"Hora Egreso: {this.horaEgreso}");
            }

            return sb.ToString();
        }

        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return v1.patente == v2.patente;
        }
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        public override bool Equals(object? obj)
        {
            if (obj is Vehiculo)
            {
                return this == ((Vehiculo)obj);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public abstract float CargoEstacionamiento();

        public static int OrdenarPorPatente(Vehiculo v1, Vehiculo v2)
        {
            return String.Compare(v1.Patente, v2.Patente, StringComparison.OrdinalIgnoreCase);
        }
        public static int OrdenarPorMarca(Vehiculo v1, Vehiculo v2)
        {
            return String.Compare(v1.Marca, v2.Marca, StringComparison.OrdinalIgnoreCase);
        }
        public static int OrdenarPorHoraIngreso(Vehiculo v1, Vehiculo v2)
        {
            return DateTime.Compare(v1.HoraEgreso, v2.HoraEgreso);
        }
        public static int OrdenarPorHoraEgreso(Vehiculo v1, Vehiculo v2)
        {
            return DateTime.Compare(v1.HoraIngreso, v2.HoraIngreso);
        }
        public static bool ValidarPatente(string patente)
        {
            string patron = @"^[A-Z]{2,3}\d{3}[A-Z]{0,2}$";
            return Regex.IsMatch(patente, patron);
        }
        public static bool ValidarMarca(string valor)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
            return regex.IsMatch(valor);
        }

    }
}

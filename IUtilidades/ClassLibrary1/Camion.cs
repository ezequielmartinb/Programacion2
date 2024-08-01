using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClassLibrary
{

    public sealed class Camion : Vehiculo
    {
        private int id;
        private ETipoCamion tipo;
        private float valorHora;
        static int espacioOcupado;
        static int ultimoId;

        static Camion()
        {
            espacioOcupado = 2;
            ultimoId = 0;
        }
        public Camion() : base()
        {

        }
        public Camion(ETipoCamion tipo)
        {
            this.tipo = tipo;
        }
        public Camion(float valorHora, ETipoCamion tipo) : this(tipo)
        {
            this.valorHora = valorHora;
        }
        public Camion(string patente, string marca, DateTime horaIngreso, float valorHora, ETipoCamion tipo) : base(patente, marca, horaIngreso)
        {
            ultimoId++;
            this.tipo = tipo;
            this.valorHora = valorHora;
            this.id = ultimoId;
        }
        
        public int EspacioOcupado { get => espacioOcupado; }
        public ETipoCamion Tipo { get => tipo; set => tipo = value; }
        public float ValorHora { get => valorHora; set => valorHora = value; }
        public int Id { get => id; set => id = value; }

        public override float CargoEstacionamiento()
        {
            float costo = 0;
            if (this.HoraIngreso.Hour == this.HoraEgreso.Hour)
            {
                costo = this.valorHora * 1;
            }
            else
            {
                switch (this.tipo)
                {
                    case ETipoCamion.ClaseC1:
                        costo = this.valorHora * (this.HoraEgreso.Hour - this.HoraIngreso.Hour);
                        break;
                    case ETipoCamion.ClaseC2:
                        costo = this.valorHora * (this.HoraEgreso.Hour - this.HoraIngreso.Hour) * 2;
                        break;
                    case ETipoCamion.ClaseC3:
                        costo = this.valorHora * (this.HoraEgreso.Hour - this.HoraIngreso.Hour) * 3;
                        break;
                }
            }
            return costo;
        }
        public static bool operator ==(Camion c1, Camion c2)
        {
            return c1.Patente == c2.Patente && c1.tipo == c2.tipo;
        }
        public static bool operator !=(Camion c1, Camion c2)
        {
            return !(c1 == c2);
        }
        public override bool Equals(object? obj)
        {
            if (obj is Camion)
            {
                return this == ((Camion)obj);
            }
            return false;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***DATOS CAMIÓN***");
            sb.Append(base.ToString());
            sb.AppendLine($"Tipo del camión: {this.tipo.ToString()}");
            if (this.HoraEgreso != DateTime.MinValue)
            {
                sb.AppendLine($"Valor a pagar: {this.CargoEstacionamiento().ToString("$ 00.00")}");
            }

            return sb.ToString();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

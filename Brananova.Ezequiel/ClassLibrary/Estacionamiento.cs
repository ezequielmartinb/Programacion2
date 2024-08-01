using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ClassLibrary.Clases;

namespace ClassLibrary
{
    public class Estacionamiento
    {
        private string nombre;
        static float capacidadEstacionamiento;
        private List<Vehiculo> listadoDeVehiculos;
        private float ganancias;
        static Estacionamiento()
        {
            capacidadEstacionamiento = 20;
        }
        public Estacionamiento()
        {
            this.listadoDeVehiculos = new List<Vehiculo>();
            this.nombre = string.Empty;
            this.ganancias = 0;
        }
        public Estacionamiento(string nombre) : this()
        {
            this.nombre = nombre;
        }
        public Estacionamiento(string nombre, List<Vehiculo> listadoDeVehiculos) : this(nombre)
        {
            this.listadoDeVehiculos = listadoDeVehiculos;
        }
        public Estacionamiento(string nombre, int capacidadDeEstacionamiento, List<Vehiculo> listadoDeVehiculos, float ganancias)
        {
            this.nombre = nombre;
            this.listadoDeVehiculos = listadoDeVehiculos;
            this.ganancias = ganancias;
            capacidadEstacionamiento = capacidadDeEstacionamiento;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public float CapacidadEstacionamiento { get => capacidadEstacionamiento; }
        public List<Vehiculo> ListadoDeVehiculos { get => listadoDeVehiculos; set => listadoDeVehiculos = value; }
        public float Ganancias { get => ganancias; set => ganancias = value; }

        public static bool operator +(Estacionamiento estacionamiento, Vehiculo vehiculo)
        {
            if (estacionamiento.ListadoDeVehiculos != null && estacionamiento != vehiculo && capacidadEstacionamiento > 0 && capacidadEstacionamiento <= 20)
            {
                estacionamiento.ListadoDeVehiculos.Add(vehiculo);
                if (vehiculo is Auto)
                {
                    capacidadEstacionamiento = capacidadEstacionamiento - ((Auto)vehiculo).EspacioOcupado;
                }
                else if (vehiculo is Moto)
                {
                    capacidadEstacionamiento = capacidadEstacionamiento - ((Moto)vehiculo).EspacioOcupado;
                }
                else
                {
                    capacidadEstacionamiento = capacidadEstacionamiento - ((Camion)vehiculo).EspacioOcupado;
                }
                return true;
            }
            return false;
        }
        public static bool operator -(Estacionamiento estacionamiento, Vehiculo vehiculo)
        {
            if (estacionamiento.ListadoDeVehiculos != null && estacionamiento == vehiculo)
            {
                vehiculo.HoraEgreso = DateTime.Now;
                if (vehiculo is Auto)
                {
                    capacidadEstacionamiento = capacidadEstacionamiento + ((Auto)vehiculo).EspacioOcupado;
                }
                else if (vehiculo is Moto)
                {
                    capacidadEstacionamiento = capacidadEstacionamiento + ((Moto)vehiculo).EspacioOcupado;
                }
                else
                {
                    capacidadEstacionamiento = capacidadEstacionamiento + ((Camion)vehiculo).EspacioOcupado;
                }
                estacionamiento.Ganancias += vehiculo.CargoEstacionamiento();
                estacionamiento.ListadoDeVehiculos.Remove(vehiculo);
                return true;
            }
            return false;
        }
        public static bool operator ==(Estacionamiento estacionamiento, Vehiculo vehiculo)
        {
            return estacionamiento.listadoDeVehiculos.Contains(vehiculo);
        }
        public static bool operator !=(Estacionamiento estacionamiento, Vehiculo vehiculo)
        {
            return !(estacionamiento == vehiculo);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Estacionamiento: {this.nombre}");
            sb.AppendLine($"Capacidad: {capacidadEstacionamiento}");
            sb.AppendLine($"Lista de Vehiculos: ");
            foreach (Vehiculo item in this.listadoDeVehiculos)
            {
                sb.AppendLine(item.ToString());
            }
            if (this.Ganancias != 0)
            {
                sb.AppendLine($"Ganancia: {ganancias.ToString("00.00")}");
            }

            return sb.ToString();
        }
        public string InformarSalida(Vehiculo vehiculo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Estacionamiento: {this.nombre}");
            sb.AppendLine($"Vehiculo: {vehiculo.ToString()}");
            sb.AppendLine($"Cargo estacionamiento: {vehiculo.CargoEstacionamiento()}");

            return sb.ToString();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj is Vehiculo)
            {
                return this == ((Vehiculo)obj);
            }
            return false;
        }         
    }
}

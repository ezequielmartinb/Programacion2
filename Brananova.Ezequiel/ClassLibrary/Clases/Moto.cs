﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Clases
{
    public sealed class Moto : Vehiculo
    {
        private int id;
        private float valorHora;
        private ETipoMoto tipo;
        static float espacioOcupado;
        static int ultimoId;
        static Moto()
        {
            espacioOcupado = 0.5F;
            ultimoId = 0;
        }
        public Moto() : base()
        {

        }
        public Moto(ETipoMoto tipo)
        {
            this.tipo = tipo;
        }
        public Moto(float valorHora, ETipoMoto tipo) : this(tipo)
        {
            this.valorHora = valorHora;
        }
        public Moto(string patente, string marca, DateTime horaIngreso, float valorHora, ETipoMoto tipo) : base(patente, marca, horaIngreso)
        {
            ultimoId++;
            this.tipo = tipo;
            this.valorHora = valorHora;
            this.id = ultimoId;
        }
        public float EspacioOcupado { get => espacioOcupado; }
        public float ValorHora { get => valorHora; set => valorHora = value; }
        public ETipoMoto Tipo { get => tipo; set => tipo = value; }
        public int Id { get => id; set => id = value; }

        public override float CargoEstacionamiento()
        {
            float costo = 0;
            if (HoraIngreso.Hour == HoraEgreso.Hour)
            {
                costo = valorHora * 1;
            }
            else
            {
                switch (tipo)
                {
                    case ETipoMoto.Sport:
                        costo = valorHora * (HoraEgreso.Hour - HoraIngreso.Hour) + 100;
                        break;
                    case ETipoMoto.Scooter:
                        costo = valorHora * (HoraEgreso.Hour - HoraIngreso.Hour);
                        break;
                    case ETipoMoto.Touring:
                        costo = valorHora * (HoraEgreso.Hour - HoraIngreso.Hour) + 500;
                        break;
                }
            }
            return costo;
        }
        public static bool operator ==(Moto m1, Moto m2)
        {
            return m1.Patente == m2.Patente && m1.tipo == m2.tipo;
        }
        public static bool operator !=(Moto m1, Moto m2)
        {
            return !(m1 == m2);
        }
        public override bool Equals(object? obj)
        {
            if (obj is Moto)
            {
                return this == (Moto)obj;
            }
            return false;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***DATOS MOTO***");
            sb.Append(base.ToString());
            sb.AppendLine($"Tipo de moto: {tipo.ToString()}");
            if (HoraEgreso != DateTime.MinValue)
            {
                sb.AppendLine($"Valor a pagar: {CargoEstacionamiento().ToString("$ 00.00")}");
            }
            return sb.ToString();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}

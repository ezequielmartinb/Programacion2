using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public abstract class Paquete : IAduana
    {
        private string codigoSeguimiento;
        protected decimal costoEnvio;
        private string destino;
        private string origen;
        private double pesoKg;

        protected Paquete(string codigoSeguimiento, decimal costoEnvio, string destino, string origen, double pesoKg)
        {
            this.codigoSeguimiento = codigoSeguimiento;
            this.costoEnvio = costoEnvio;
            this.destino = destino;
            this.origen = origen;
            this.pesoKg = pesoKg;
        }

        public abstract bool TienePrioridad { get; }

        public decimal Impuestos => (this.costoEnvio * 35) / 100;

        public string ObtenerInformacionDePaquete()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Codigo Seguimiento: {this.codigoSeguimiento}");
            sb.AppendLine($"Costo Envio: {this.costoEnvio}");
            sb.AppendLine($"Destino: {this.destino}");
            sb.AppendLine($"Origen: {this.origen}");
            sb.AppendLine($"Peso: {this.pesoKg:#.00}");
            if (this.TienePrioridad == false)
            {
                sb.AppendLine($"NO tiene prioridad");
            }
            else
            {
                sb.AppendLine($"SI tiene prioridad");
            }

            return sb.ToString();
        }

        public virtual decimal AplicarImpuestos()
        {
            return this.costoEnvio + Impuestos;
        }
    }
}

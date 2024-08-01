using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class PaquetePesado : Paquete, IAfip
    {
        public PaquetePesado(string codigoSeguimiento, decimal costoEnvio, string destino, string origen, double pesoKg) : base(codigoSeguimiento, costoEnvio, destino, origen, pesoKg)
        {
        }

        public override bool TienePrioridad { get => false; }

        decimal IAfip.Impuestos { get => (this.costoEnvio * 25) / 100; }

        public override decimal AplicarImpuestos()
        {
            return this.costoEnvio + this.Impuestos + ((IAfip)this).Impuestos;
        }
    }
}

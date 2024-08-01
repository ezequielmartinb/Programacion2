using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GestionImpuestos
    {
        private List<IAduana> impuestosAduana;
        private List<IAfip> impuestosAfip;

        public GestionImpuestos()
        {
            this.impuestosAfip = new List<IAfip>();
            this.impuestosAduana = new List<IAduana>();
        }
        public void RegistrarImpuestos(IEnumerable<Paquete> paquetes)
        {
            if (paquetes != null)
            {
                foreach (Paquete paquete in paquetes)
                {
                    RegistrarImpuestos(paquete);
                }
            }
        }
        public void RegistrarImpuestos(Paquete paquete)
        {
            if (paquete != null)
            {
                this.impuestosAduana.Add(paquete);
                if (paquete is IAfip)
                {
                    IAfip paqueteAfip = (IAfip)paquete;
                    this.impuestosAfip.Add(paqueteAfip);
                }
            }
        }
        public decimal CalcularTotalImpuestosAduana()
        {
            decimal total = 0;
            foreach (IAduana item in this.impuestosAduana)
            {
                total += item.Impuestos;
            }
            return total;
        }
        public decimal CalcularTotalImpuestosAfip()
        {
            decimal total = 0;
            foreach (IAfip item in this.impuestosAfip)
            {
                total += item.Impuestos;
            }
            return total;
        }

    }
}

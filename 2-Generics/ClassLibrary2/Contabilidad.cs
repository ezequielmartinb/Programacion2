using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Contabilidad<T, U> where T : Documento where U : Documento, new()
    {
        private List<T> egresos = new List<T>();
        private List<U> ingresos = new List<U>();
        public Contabilidad()
        {
            this.egresos = new List<T>();
            this.ingresos = new List<U>();
        }

        public List<T> Egresos { get => egresos; set => egresos = value; }
        public List<U> Ingresos { get => ingresos; set => ingresos = value; }

        public static Contabilidad<T, U> operator +(Contabilidad<T, U> contabilidad, T egreso)
        {
            if (contabilidad is not null && egreso is not null && contabilidad.egresos.Contains(egreso) == false)
            {
                contabilidad.egresos.Add(egreso);
                return contabilidad;
            }
            return contabilidad;
        }
        public static Contabilidad<T, U> operator +(Contabilidad<T, U> contabilidad, U ingreso)
        {
            if (contabilidad is not null && ingreso is not null && contabilidad.ingresos.Contains(ingreso) == false)
            {
                contabilidad.ingresos.Add(ingreso);
                return contabilidad;
            }
            return contabilidad;
        }
    }
}

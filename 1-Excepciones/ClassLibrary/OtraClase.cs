using ClassLibrary.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class OtraClase
    {
        public OtraClase()
        {
            try
            {
                MiClase miClase = new MiClase();
            }
            catch (Exception ex)
            {
                throw new MiException("Excepcion de Otra Clase", ex.InnerException);
            }
        }
    }
}

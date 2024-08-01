using ClassLibrary.Excepciones;

namespace ClassLibrary
{
    public class MiClase
    {
        public MiClase()
        {
            try
            {
                MiClase miClase = new MiClase(2);
            }
            catch
            {
                throw new UnaException("Excepcion del constructor sin parametros");
            }
        }
        public MiClase(int id)
        {
            try
            {
                LanzarExcepcion();
            }
            catch (DivideByZeroException ex)
            {
                throw ex;
            }
        }
        public static void LanzarExcepcion()
        {
            throw new DivideByZeroException();
        }
    }
}

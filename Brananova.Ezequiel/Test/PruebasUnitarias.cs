using ClassLibrary.Clases;
using ClassLibrary.Login;

namespace Test
{
    [TestClass]
    public class PruebasUnitarias
    {
        [TestMethod]
        public void ValidarPatente_CuandoNoEsValida_DeberiaRetornarFalse()
        {
            //ARRANGE
            string patente = "111";
            //ACT
            bool resultado = Vehiculo.ValidarPatente(patente);

            //ASSERT
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void ValidarEmail_CuandoEsValida_DeberiaRetornarTrue()
        {
            //ARRANGE
            string mail = "ezequielmartinb@gmail.com";
            //ACT
            bool resultado = Usuario.ValidarEmail(mail);

            //ASSERT
            Assert.IsTrue(resultado);
        }
        [TestMethod]
        public void DeserializacionJSON_CuandoElPathNoExiste_DeberiaArrojarUnaExcepcionDeTipoTypeInitializationException()
        {
            //ARRANGE
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Path.Join(path, $"{Path.DirectorySeparatorChar}Carpeta Inexistente");
            //ACT Y ASSERT
            Assert.ThrowsException<TypeInitializationException>(() => Autenticacion.DeserializacionJSON(path));
        }
    }
}
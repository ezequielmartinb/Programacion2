using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClassLibrary.Login
{
    public static class Autenticacion
    {
        static List<Usuario> listaDeUsuarios;

        public static List<Usuario> ListaDeUsuarios { get => listaDeUsuarios; }

        static Autenticacion()
        {
            listaDeUsuarios = new List<Usuario>();
            CargarUsuarios();
        }

        private static void CargarUsuarios()
        {
            List<Usuario> usuarios;
            string ruta = Directory.GetCurrentDirectory();
            ruta = Path.Join(ruta, $"{Path.DirectorySeparatorChar}usuarios.json");
            try
            {
                usuarios = DeserializacionJSON(ruta);
                foreach (Usuario item in usuarios)
                {
                    if (item != null && !listaDeUsuarios.Contains(item))
                    {
                        listaDeUsuarios.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public static List<Usuario> DeserializacionJSON(string path)
        {
            try
            {
                using (StreamReader lectura = new StreamReader(path))
                {
                    string json = lectura.ReadToEnd();
                    List<Usuario> usuarios = JsonSerializer.Deserialize<List<Usuario>>(json);
                    return usuarios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public static void SerializarIngresoUsuarios(string nombre, string apellido)
        {
            string ruta = Directory.GetCurrentDirectory();
            ruta = Path.Join(ruta, $"{Path.DirectorySeparatorChar}usuarios.log");
            try
            {
                using (StreamWriter writer = new StreamWriter(ruta, true))
                {
                    writer.WriteLine($"{nombre} {apellido} {DateTime.Now.ToString("yyyy/MM/dd - HH:mm:ss")}");
                }
            }
            catch
            {
                throw new Exception($"No se pudo escribir el archivo en la ruta {ruta}");
            }
        }

        public static List<string> DeserializarIngresoUsuarios()
        {
            List<string> listaDeIngresos = new List<string>();
            string ruta = Directory.GetCurrentDirectory();
            ruta = Path.Join(ruta, $"{Path.DirectorySeparatorChar}usuarios.log");
            if (Path.Exists(ruta))
            {
                using (StreamReader lectura = new StreamReader(ruta))
                {
                    while (!lectura.EndOfStream)
                    {
                        if (lectura.ReadLine() != null)
                        {
                            string lineaDeTexto = lectura.ReadLine();
                            listaDeIngresos.Add(lineaDeTexto);
                        }
                    }
                }
            }
            return listaDeIngresos;
        }
    }
}

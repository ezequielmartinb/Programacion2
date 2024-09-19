using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;


namespace Entidades.Final
{
    public static class Manejadora
    {
        public static bool DeserializarJSON(string path, out List<Usuario> users)
        {
            bool retorno = true;

            try
            {
                string jsonString = File.ReadAllText(path);
                users = System.Text.Json.JsonSerializer.Deserialize<List<Usuario>>(jsonString);
            }
            catch (Exception ex)
            {
                users = new List<Usuario>();
                Console.WriteLine(ex.Message);
                retorno = false;
            }

            return retorno;
        }
        public static bool SerializarJSON(List<Usuario> users, string path)
        {
            bool retorno = true;

            try
            {               
                List<Usuario> listaDeApellidosRepetidos = new List<Usuario>();
                if (!DeserializarJSON(path, out listaDeApellidosRepetidos))
                {
                    listaDeApellidosRepetidos = new List<Usuario>();
                }               

                listaDeApellidosRepetidos.AddRange(users);

                var toJson = JsonConvert.SerializeObject(listaDeApellidosRepetidos, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });

                File.WriteAllText(path, toJson);
            }
            catch
            {
                retorno = false;
            }
            return retorno;
        }
        public static bool EscribirArchivo(List<Usuario> users)
        {
            bool retorno = true;
            string correos = String.Empty;
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ruta = Path.Join(ruta, $"{Path.DirectorySeparatorChar}usuarios.log");
            try
            {
                using (StreamWriter writer = new StreamWriter(ruta, true))
                {
                    writer.WriteLine($"Fecha y hora: {DateTime.Now.ToString("yyyy/MM/dd - HH:mm:ss")}");
                    writer.WriteLine($"Apellido: {users[0].Apellido}");
                    foreach (Usuario usuario in users)
                    {
                        if(usuario.Apellido == users[0].Apellido)
                        {
                            correos += $"{usuario.Correo}{Environment.NewLine}";
                        }
                    }
                    writer.WriteLine($"Correo: ");
                    writer.WriteLine($"{correos}");
                    writer.WriteLine("***********************");
                }
            }
            catch
            {
                throw new Exception($"No se pudo escribir el archivo en la ruta {ruta}");
            }

            return retorno;
        }
    }
}

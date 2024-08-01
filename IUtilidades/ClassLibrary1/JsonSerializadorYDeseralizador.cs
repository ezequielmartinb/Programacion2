using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace ClassLibrary1
{
    public class JsonSerializadorYDeseralizador<V> : IUtils<V>
    {
        public bool Deserializar(string path, out V datos)
        {
            bool retorno = true;

            try
            {
                string jsonString = File.ReadAllText(path);                
                datos = System.Text.Json.JsonSerializer.Deserialize<V>(jsonString);
            }
            catch(Exception ex) 
            {
                datos = default(V);
                Console.WriteLine(ex.Message);
                retorno = false;
            }

            return retorno;
        }

        public bool Serializar(string path, V datos)
        {
            bool retorno = true;
            
            try
            {
                //JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
                //jsonSerializerOptions.WriteIndented = true;
                var toJson = JsonConvert.SerializeObject(datos, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                //string jsonString = System.Text.Json.JsonSerializer.Serialize(datos, jsonSerializerOptions);
                File.WriteAllText(path, toJson);
            }
            catch
            {
                retorno = false;
            }
            return retorno;
        }
    }
}

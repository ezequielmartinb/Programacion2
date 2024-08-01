using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;

namespace ClassLibrary.Utilidades
{
    public class JsonSerializadorYDeseralizador<V> : IUtils<V>
    {
        public bool Deserializar(string path, out V datos)
        {
            bool retorno = true;

            try
            {
                string jsonString = File.ReadAllText(path);
                datos = JsonSerializer.Deserialize<V>(jsonString);
            }
            catch
            {
                datos = default;
                retorno = false;
            }

            return retorno;
        }

        public bool Serializar(string path, V datos)
        {
            bool retorno = true;
            try
            {
                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
                jsonSerializerOptions.WriteIndented = true;
                string jsonString = JsonSerializer.Serialize(datos, jsonSerializerOptions);
                File.WriteAllText(path, jsonString);
            }
            catch
            {
                retorno = false;
            }
            return retorno;
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WJ_SurverBot.Json
{
    internal class JsonReader
    {
        public static KeyValuePair<string, Dictionary<string, string>> ReadJsonFile(string filePath)
        {
            // Otwórz plik JSON z dysku
            string jsonString = File.ReadAllText(filePath);

            // Deserializuj JSON do obiektu typu KeyValuePair<string, Dictionary<string, string>>
            var result = JsonConvert.DeserializeObject<KeyValuePair<string, Dictionary<string, string>>>(jsonString);

            // Zwróć odczytany obiekt
            return result;
        }
    }
}

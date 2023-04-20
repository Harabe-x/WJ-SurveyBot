using Newtonsoft.Json;

namespace WJ_SurveyBot.Json
{
    internal class JsonReader
    {
        /// <summary>
        /// Reads a JSON file and returns a KeyValuePair containing the JSON object's root key and a Dictionary of key-value pairs of the object's properties
        /// </summary>
        /// <param name="filePath">The path to the JSON file</param>
        /// <returns>A KeyValuePair containing the root key and a Dictionary of key-value pairs of the object's properties</returns>
        public static KeyValuePair<string, Dictionary<string, string>> ReadJsonFile(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);

            var result = JsonConvert.DeserializeObject<KeyValuePair<string, Dictionary<string, string>>>(jsonString);

            return result;
        }
    }
}
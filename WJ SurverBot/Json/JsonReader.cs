using Newtonsoft.Json;

namespace WJ_SurveyBot.Json;

internal class JsonReader
{
    public static KeyValuePair<string, Dictionary<string, string>> ReadJsonFile(string filePath)
    {
        var jsonString = File.ReadAllText(filePath);

        var result = JsonConvert.DeserializeObject<KeyValuePair<string, Dictionary<string, string>>>(jsonString);

        return result;
    }
}
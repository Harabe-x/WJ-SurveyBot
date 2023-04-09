using System.Collections.Generic;
using Newtonsoft.Json;
using WJ_SurverBot.Json;

public class JsonWriter : IJsonWriter
{
    public void SaveDataToJsonFile(string fileName, object data)
    {
        JsonSerializer serializer = new JsonSerializer();
        serializer.Formatting = Formatting.Indented;
        File.Create(fileName).Dispose();
        using (StreamWriter sw = new StreamWriter(fileName, true))
        using (JsonTextWriter writer = new JsonTextWriter(sw))
        {
            serializer.Serialize(writer, data);

        }
    }
}



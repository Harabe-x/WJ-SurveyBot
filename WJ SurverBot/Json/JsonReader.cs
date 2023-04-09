using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WJ_SurverBot.Survey.Model;

namespace WJ_SurverBot.Json
{
    internal class JsonReader
    {
        public static SurveyModel ReadJson(string json)
        {
            return JsonConvert.DeserializeObject<SurveyModel>(json);
        }
    }
}

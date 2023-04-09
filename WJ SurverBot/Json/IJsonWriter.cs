using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WJ_SurverBot.Json
{
    internal interface IJsonWriter
    {
        void SaveDataToJsonFile(string filePath, object data);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WJ_SurverBot.Survey.Model;

namespace WJ_SurverBot.Survey.CsvReader
{
    internal interface ICsvReader
    { 
       List<string> GetCityList(string path,int ammount);


    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WJ_SurverBot.Survey.Extension;
using WJ_SurverBot.Survey.Model;

namespace WJ_SurverBot.Survey.CsvReader
{
    internal class CsvReader : ICsvReader
    {
        public List<string> GetCityList(string path, int ammount)
        {

            var random = new Random();
            var CityList = File.ReadLines(path).Skip(random.Next(2, 42906))
                 .Take(100).ToCity().ToList();
            return RemoveQuote(CityList);
        }

       

         List<string>  RemoveQuote(List<string> list)
        {
            List<string> result = new List<string>();
            foreach (var item in list)
            {
                string city="";

                for (int i = 0; i < item.Length; i++)
                {
                    if (item[i] != '"')
                    {
                        city += item[i];
                    }
                }
                result.Add(city);
            }
            return result;
        }

        
    }
}

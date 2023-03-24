using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WJ_SurverBot.Survey.Model;

namespace WJ_SurverBot.Survey.Extension
{
    internal static class CsvReaderExtension
    {
        public static IEnumerable<string> ToCity(this IEnumerable<string> soruce)
        {
            foreach (var line in soruce)
            {
                var splittedLine = line.Split(',');
               
                yield return splittedLine[0];
            }
        }
    }
}

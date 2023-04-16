using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WJ_SurverBot.OperationsMenu.OperationsMenu_interfaces;
using WJ_SurveyBot.OperationsMenu;

namespace WJ_SurverBot.OperationsMenu
{
    internal class DeleteSurveyPatternMenu : IDeleteSurveyPatternMenu
    {
        public void RunMenu()
        {
            
            var patterns = GetSavedSurveysPatterns("SurveyPatterns");
            
            var menu = new Menu( patterns.Select(x => x.Key).ToArray() ,"Select pattern to delete" );
            
            var selectedOption = menu.Run();
            
            Console.WriteLine("Are You Sure ? Y/N ");
          
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                File.Delete(patterns[selectedOption].Value);    
            }
            
        }

        public List<KeyValuePair<string, string>> GetSavedSurveysPatterns(string folderPath)
        {
            var files = new List<KeyValuePair<string, string>>();

            var filePaths = Directory.GetFiles(folderPath);

            foreach (var filePath in filePaths)
                files.Add(new KeyValuePair<string, string>(Path.GetFileName(filePath), filePath));

            return files;
        }

    }
}

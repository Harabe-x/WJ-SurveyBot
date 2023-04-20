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
        /// <summary>
        /// Runs the menu for deleting a survey pattern.
        /// </summary>
        public void RunMenu()
        {
            
            var patterns = GetSavedSurveysPatterns("SurveyPatterns");
            
            var menu = new Menu( patterns.Select(x => x.Key).ToArray() , @"
█     █░▄▄▄██▀▀▀     ██████  █    ██  ██▀███   ██▒   █▓▓█████▓██   ██▓
▓█░ █ ░█░  ▒██      ▒██    ▒  ██  ▓██▒▓██ ▒ ██▒▓██░   █▒▓█   ▀ ▒██  ██▒
▒█░ █ ░█   ░██      ░ ▓██▄   ▓██  ▒██░▓██ ░▄█ ▒ ▓██  █▒░▒███    ▒██ ██░
░█░ █ ░█▓██▄██▓       ▒   ██▒▓▓█  ░██░▒██▀▀█▄    ▒██ █░░▒▓█  ▄  ░ ▐██▓░
░░██▒██▓ ▓███▒      ▒██████▒▒▒▒█████▓ ░██▓ ▒██▒   ▒▀█░  ░▒████▒ ░ ██▒▓░
░ ▓░▒ ▒  ▒▓▒▒░      ▒ ▒▓▒ ▒ ░░▒▓▒ ▒ ▒ ░ ▒▓ ░▒▓░   ░ ▐░  ░░ ▒░ ░  ██▒▒▒ 
  ▒ ░ ░  ▒ ░▒░      ░ ░▒  ░ ░░░▒░ ░ ░   ░▒ ░ ▒░   ░ ░░   ░ ░  ░▓██ ░▒░ 
  ░   ░  ░ ░ ░      ░  ░  ░   ░░░ ░ ░   ░░   ░      ░░     ░   ▒ ▒ ░░  
    ░    ░   ░            ░     ░        ░           ░     ░  ░░ ░     
Select pattern to delete");
            
            var selectedOption = menu.Run();
            
            Console.WriteLine("Are You Sure ? Y/N ");
          
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                File.Delete(patterns[selectedOption].Value);    
            }
            
        }
  /// <summary>
        /// Gets a list of saved survey pattern file paths and their names.
        /// </summary>
        /// <param name="folderPath">The folder path where the survey patterns are saved.</param>
        /// <returns>A list of KeyValuePair objects where the key is the pattern name and the value</returns>
        public List<KeyValuePair<string, string>> GetSavedSurveysPatterns(string folderPath)
        {
            var filePaths = Directory.GetFiles(folderPath);

            return filePaths.Select(filePath => new KeyValuePair<string, string>(Path.GetFileName(filePath), filePath)).ToList();
        }      

    }
}

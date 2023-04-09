using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WJ_SurverBot.Survey;

namespace WJ_SurverBot.Menu
{
    internal class ActionMenu
    {

        private readonly Menu menu;

        public void SendSurveys(ISurveySender sender)
        {
            Console.Clear();
            var surveysPattern = GetSavedSurveysPatterns("SurveyPatterns");

            
            List<string > surveys = new List<string>() ;
            var menu = new Menu(surveysPattern.Select(file => file.Key).ToArray(),"" +
                @"
                            █     █░▄▄▄██▀▀▀        ██████  █    ██  ██▀███   ██▒   █▓▓█████▓██   ██▓
                           ▓█░ █ ░█░  ▒██         ▒██    ▒  ██  ▓██▒▓██ ▒ ██▒▓██░   █▒▓█   ▀ ▒██  ██▒
                           ▒█░ █ ░█   ░██         ░ ▓██▄   ▓██  ▒██░▓██ ░▄█ ▒ ▓██  █▒░▒███    ▒██ ██░
                           ░█░ █ ░█▓██▄██▓          ▒   ██▒▓▓█  ░██░▒██▀▀█▄    ▒██ █░░▒▓█  ▄  ░ ▐██▓░ 
                           ░░██▒██▓ ▓███▒         ▒██████▒▒▒▒█████▓ ░██▓ ▒██▒   ▒▀█░  ░▒████▒ ░ ██▒▓░
                           ░ ▓░▒ ▒  ▒▓▒▒░         ▒ ▒▓▒ ▒ ░░▒▓▒ ▒ ▒ ░ ▒▓ ░▒▓░   ░ ▐░  ░░ ▒░ ░  ██▒▒▒ 
                           ▒ ░ ░  ▒ ░▒░         ░ ░▒  ░ ░░░▒░ ░ ░   ░▒ ░ ▒░   ░ ░░   ░ ░  ░▓██ ░▒░ 
                           ░   ░  ░ ░ ░         ░  ░  ░   ░░░ ░ ░   ░░   ░      ░░     ░   ▒ ▒ ░░  
                           ░    ░   ░               ░     ░        ░           ░     ░  ░░ ░   
 Select Survey Pattern");
            var option =  menu.Run();
            Console.Clear();
            Console.WriteLine($"You Selected {surveysPattern[option].Key}");
            var surveypattern = Json.JsonReader.ReadJson(File.ReadAllText(surveysPattern[option].Value));

            //Console.WriteLine("How much form do you wanna send: ");
            //int.TryParse(Console.ReadLine(), out int parsedValue);
            for (int i = 0; i < 100; i++)
            {
            sender.SendAnswer(surveypattern.FormUrl.ToString(), surveypattern.FormAnswers.ToArray(), surveypattern.FormTextAreaAnswers.ToArray());
            }          
        }

        public List<KeyValuePair<string, string>> GetSavedSurveysPatterns(string folderPath)
        {
            List<KeyValuePair<string, string>> files = new List<KeyValuePair<string, string>>();

            string[] filePaths = Directory.GetFiles(folderPath);

            foreach (string filePath in filePaths)
            {
                files.Add(new KeyValuePair<string, string>(Path.GetFileName(filePath), filePath));
            }

            return files;
        }
    }
}
           
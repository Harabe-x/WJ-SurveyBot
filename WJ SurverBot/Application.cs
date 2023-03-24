 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WJ_SurverBot.Survey;
using WJ_SurverBot.Survey.CsvReader;
using WJ_SurverBot.Survey.ScenarioStrategy;
using Figgle;
using OpenQA.Selenium.DevTools.V108.Runtime;

namespace WJ_SurverBot
{
    internal class Application : IApplication
    {


        private readonly ICsvReader _csvReader;

        private readonly ISurveySender _surveySender;

        public Application(ISurveySender surveySender, ICsvReader csvReader)
        {
            _surveySender = surveySender;
            _csvReader = csvReader;
        }
        public void Run()
        {
            Console.Title = "WJ Survey Bot v1.0.0";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(FiggleFonts.Slant.Render("               WJ Survey"));
            Console.ResetColor();
            Console.WriteLine("Enter ammount of surveys: ");
            bool success = int.TryParse(Console.ReadLine(), out int parsedAmmount);

            if (success)
            {
            Console.ForegroundColor = ConsoleColor.Green;
                
            Console.WriteLine("Bot Started");
                for (int i = 0; i < parsedAmmount; i++)
                {
                    Random random = new Random();
                    int option = random.Next(1, 6);
                    switch (option)
                    {
                        case 1:
                    Console.WriteLine("Sending Survey #1 Pattern");
                        IScenarioStrategy scenario1 = new FirstSurveyPattern(_csvReader);
                        _surveySender.SendAnswer(scenario1);
                            break;
                        case 2:
                            Console.WriteLine("Sending Survey #1 Pattern");

                            IScenarioStrategy _scenario1 = new FirstSurveyPattern(_csvReader);
                            _surveySender.SendAnswer(_scenario1);
                            break;
                        case 3: 
                    Console.WriteLine("Sending Survey #2 Pattern");

                            IScenarioStrategy scenario2 = new SecondSurveyScnario(_csvReader);
                    _surveySender.SendAnswer(scenario2);
                            break;

                        case 4:
                            Console.WriteLine("Sending Survey #3 Pattern");

                            IScenarioStrategy scenario3 = new ThridSurveyScenario(_csvReader);
                    _surveySender.SendAnswer(scenario3);
                            break;
                        case 5:
                            Console.WriteLine("Sending Survey #4 Pattern");

                            IScenarioStrategy scenario4 = new FourthSurveyStrategy(_csvReader);
                    _surveySender.SendAnswer(scenario4);
                            break;
                        default:
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Survey Sent");

                }
            }
        }
    }
}
    
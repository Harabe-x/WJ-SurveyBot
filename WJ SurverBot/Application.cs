using WJ_SurverBot.Survey.ScenarioStrategy;
using WJ_SurverBot.Survey;
using Figgle;

namespace WJ_SurverBot
{
    internal class Application : IApplication
    {



        private readonly ISurveySender _surveySender;


        public Application(ISurveySender surveySender)
        {
           _surveySender = surveySender;
        }
        public void Run()
        {




            
        }
    }
}

            //Console.Title = "WJ Survey Bot v1.0.0";
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine(FiggleFonts.Slant.Render("               WJ Survey"));
            //Console.ResetColor();
            //Console.WriteLine("Enter ammount of surveys: ");
            //bool success = int.TryParse(Console.ReadLine(), out int parsedAmmount);

            //if (success)
            //{
            //    Console.ForegroundColor = ConsoleColor.Green;

            //    Console.WriteLine("Bot Started");
            //    for (int i = 0; i < parsedAmmount; i++)
            //    {
            //        Random random = new Random();
            //        int option = random.Next(1, 6);
            //        switch (option)
            //        {
            //            case 1:
            //                Console.WriteLine("Sending Survey #1 Pattern");
            //                ISurveyPatternStrategy scenario1 = new FirstSurveyPattern(_csvReader);
            //                _surveySender.SendAnswer(scenario1);
            //                break;
            //            case 2:
            //                Console.WriteLine("Sending Survey #1 Pattern");

            //                ISurveyPatternStrategy _scenario1 = new FirstSurveyPattern(_csvReader);
            //                _surveySender.SendAnswer(_scenario1);
            //                break;
            //            case 3:
            //                Console.WriteLine("Sending Survey #2 Pattern");

            //                ISurveyPatternStrategy scenario2 = new SecondSurveyPattern(_csvReader);
            //                _surveySender.SendAnswer(scenario2);
            //                break;

            //            case 4:
            //                Console.WriteLine("Sending Survey #3 Pattern");

            //                ISurveyPatternStrategy scenario3 = new ThridSurveyPatern(_csvReader);
            //                _surveySender.SendAnswer(scenario3);
            //                break;
            //            case 5:
            //                Console.WriteLine("Sending Survey #4 Pattern");

            //                ISurveyPatternStrategy scenario4 = new FourthSurveyPattern(_csvReader);
            //                _surveySender.SendAnswer(scenario4);
            //                break;
            //            default:
            //                break;
            //        }
            //        Console.ForegroundColor = ConsoleColor.Green;
            //        Console.WriteLine("Survey Sent");

            //    }
            //}
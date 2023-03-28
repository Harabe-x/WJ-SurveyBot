using Figgle;
using WJ_SurverBot.Survey;
using WJ_SurverBot.Survey.CsvReader;
using WJ_SurverBot.Survey.Playground;
using WJ_SurverBot.Survey.ScenarioStrategy;

namespace WJ_SurverBot
{
    internal class Application : IApplication
    {


        private readonly ICsvReader _csvReader;

        private readonly ISurveySender _surveySender;

        private readonly IChromeDrivePlayground _chromeDrivePlayground;

        public Application(ISurveySender surveySender, ICsvReader csvReader , IChromeDrivePlayground chromeDrivePlayground)
        {
           _surveySender = surveySender;
           _csvReader = csvReader;
           _chromeDrivePlayground = chromeDrivePlayground;
        }
        public void Run()
        {

            ISurveyPatternStrategy surveypattern = new ThridSurveyPatern();


            _surveySender.SendAnswer("https://docs.google.com/forms/d/e/1FAIpQLScJIv8gUfdGTAzk-15MY93sMag6jdXTpLP5lTvDdm1fgSrP0w/viewform"
                , surveypattern.GetSurveyAnswers(), surveypattern.GetSurveyTextAnswers()); 


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
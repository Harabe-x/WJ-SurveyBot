using WJ_SurverBot.Survey;
using Figgle;
using WJ_SurverBot.Fiddler_Core;
using WJ_SurverBot.OperationsMenu;
using Newtonsoft.Json;
using WJ_SurveyBot.Survey;
using System.Collections.Generic;

namespace WJ_SurverBot
{
    internal class Application : IApplication
    {



        private readonly ISurveySender _surveySender;


        private readonly IHttpRequestCapture _requestCapture;

        public Application(ISurveySender surveySender, IHttpRequestCapture requestCapture)
        {
            _surveySender = surveySender;
            _requestCapture = requestCapture;
        }
        public async void Run()
        {
            //_requestCapture.Start();
            //_requestCapture.Stop();

            //if (_requestCapture.InstallCertificate())
            //{

            //    Console.WriteLine("Enter Pattern Name : ");
            //    string name = Console.ReadLine();
            //    Console.WriteLine("Enter Survey URL: ");
            //    var pattern = new AddSurveyPattern(_requestCapture);
            //    pattern.Start(Console.ReadLine(),name);

            //}

            var kPiar = Json.JsonReader.ReadJsonFile("C:\\tempJson\\outside.json");


            SurveySender ss = new();
            Thread.Sleep(1009);
            for (int i = 0; i < 100; i++)
            {
                _surveySender.SendAnswer(kPiar.Key, kPiar.Value);
                Thread.Sleep(10);
            }
            Console.ReadLine();
            
        }
    }
}
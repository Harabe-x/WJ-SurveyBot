using WJ_SurverBot.Survey.ScenarioStrategy;
using WJ_SurverBot.Survey;
using Figgle;
using WJ_SurverBot.Fiddler_Core;

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
        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (_requestCapture.InstallCertificate())
            {
                _requestCapture.Start();
                _requestCapture.Stop();

            }
        }
    }
}
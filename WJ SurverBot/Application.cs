using WJ_SurveyBot.OperationsMenu.OperationsMenu_interfaces;
using WJ_SurveyBot.OperationsMenu;
using WJ_SurveyBot.Fiddler_Core;
using WJ_SurveyBot.Survey;
using WJ_SurveyBot.Json;
using WJ_SurverBot.OperationsMenu.OperationsMenu_interfaces;

namespace WJ_SurveyBot
{
    /// <summary>
    /// Represents the application class that serves as the entry point for the survey bot.
    /// </summary>
    internal class Application : IApplication
    {
        private readonly IAddSurveyPattern _addSurveyPattern;
        private readonly IHttpRequestCapture _requestCapture;
        private readonly ISurveySender _surveySender;
        private readonly ISurveySenderMenu _surveySenderMenu;
        private readonly IDeleteSurveyPatternMenu _deleteSurveyPatternMenu;

        /// <summary>
        /// Initializes a new instance of the Application class with the specified dependencies.
        /// </summary>
        /// <param name="surveySender">The survey sender object.</param>
        /// <param name="requestCapture">The HTTP request capture object.</param>
        /// <param name="addSurveyPattern">The add survey pattern object.</param>
        /// <param name="surveySenderMenu">The survey sender menu object.</param>
        /// <param name="deleteSurveyPatternMenu">The delete survey pattern menu object.</param>
        public Application(ISurveySender surveySender, IHttpRequestCapture requestCapture,
            IAddSurveyPattern addSurveyPattern, ISurveySenderMenu surveySenderMenu,
            IDeleteSurveyPatternMenu deleteSurveyPatternMenu)
        {
            _deleteSurveyPatternMenu = deleteSurveyPatternMenu;
            _surveySenderMenu = surveySenderMenu;
            _addSurveyPattern = addSurveyPattern;
            _surveySender = surveySender;
            _requestCapture = requestCapture;
        }

        /// <summary>
        /// Runs the survey bot application.
        /// </summary>
        public async void Run()
        {
            // Display the main menu and get the selected option.
            var menu = new Menu(new string[] { "Send Survey", "Add Survey Pattern ", "Delete Pattern", "Exit" }, @"                  
█     █░▄▄▄██▀▀▀     ██████  █    ██  ██▀███   ██▒   █▓▓█████▓██   ██▓
▓█░ █ ░█░  ▒██      ▒██    ▒  ██  ▓██▒▓██ ▒ ██▒▓██░   █▒▓█   ▀ ▒██  ██▒
▒█░ █ ░█   ░██      ░ ▓██▄   ▓██  ▒██░▓██ ░▄█ ▒ ▓██  █▒░▒███    ▒██ ██░
░█░ █ ░█▓██▄██▓       ▒   ██▒▓▓█  ░██░▒██▀▀█▄    ▒██ █░░▒▓█  ▄  ░ ▐██▓░
░░██▒██▓ ▓███▒      ▒██████▒▒▒▒█████▓ ░██▓ ▒██▒   ▒▀█░  ░▒████▒ ░ ██▒▓░
░ ▓░▒ ▒  ▒▓▒▒░      ▒ ▒▓▒ ▒ ░░▒▓▒ ▒ ▒ ░ ▒▓ ░▒▓░   ░ ▐░  ░░ ▒░ ░  ██▒▒▒ 
  ▒ ░ ░  ▒ ░▒░      ░ ░▒  ░ ░░░▒░ ░ ░   ░▒ ░ ▒░   ░ ░░   ░ ░  ░▓██ ░▒░ 
  ░   ░  ░ ░ ░      ░  ░  ░   ░░░ ░ ░   ░░   ░      ░░     ░   ▒ ▒ ░░  
    ░    ░   ░            ░     ░        ░           ░     ░  ░░ ░         
Select Option");
            switch (menu.Run())
            {
                case 0:
                    _surveySenderMenu.RunMenu(_surveySender);
                    break;
                case 1:
                    _surveySenderMenu.RunMenu(_surveySender);
                    _requestCapture.InstallCertificate();

                    Console.WriteLine("Enter Name: ");
                    var name = Console.ReadLine();
                    Console.WriteLine("Enter Form Url: ");

                    if (name != null)
                        _addSurveyPattern.Start(Console.ReadLine(), name);
                    break;
                case 2:
                    Console.Clear();
                    _deleteSurveyPatternMenu.RunMenu();
                    break;
                case 3:
                    return;
            }

            Console.Clear();
            Run();
        }
    }
}

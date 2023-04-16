using WJ_SurverBot.OperationsMenu.OperationsMenu_interfaces;
using WJ_SurveyBot.OperationsMenu.OperationsMenu_interfaces;
using WJ_SurveyBot.OperationsMenu;
using WJ_SurveyBot.Fiddler_Core;
using WJ_SurveyBot.Survey;
using WJ_SurveyBot.Json;

namespace WJ_SurveyBot;

internal class Application : IApplication
{
    private readonly IAddSurveyPattern _addSurveyPattern;

    private readonly IHttpRequestCapture _requestCapture;

    private readonly ISurveySender _surveySender;

    private readonly ISurveySenderMenu _surveySenderMenu;
    private readonly IDeleteSurveyPatternMenu _deleteSurveyPatternMenu;


    public Application(ISurveySender surveySender, IHttpRequestCapture requestCapture,
        IAddSurveyPattern addSurveyPattern, ISurveySenderMenu surveySenderMenu
            , IDeleteSurveyPatternMenu deleteSurveyPatternMenu)
    {
        _deleteSurveyPatternMenu = deleteSurveyPatternMenu;
        _surveySenderMenu = surveySenderMenu;
        _addSurveyPattern = addSurveyPattern;
        _surveySender = surveySender;
        _requestCapture = requestCapture;
    }


    /// <summary>
    ///     I'm testing various things here for now, this code will still be changed
    /// </summary>
    public async void Run()
    {
        var menu = new Menu(new string[] { "Send Survey", "Add Survey Pattern ", "Delete Pattern", "Edit Pattern", "Exit" }, "Select Option");
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
                _addSurveyPattern.Start(Console.ReadLine(), name);
                break;
            case 2:
                Console.Clear();
                _deleteSurveyPatternMenu.RunMenu();
                break;
            case 3:
                throw new NotImplementedException("Not implemented yet");
            case 4:
                return;



        }
        Console.ReadLine();
    }
}
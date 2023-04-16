using Microsoft.Extensions.DependencyInjection;
using WJ_SurverBot.OperationsMenu;
using WJ_SurverBot.OperationsMenu.OperationsMenu_interfaces;
using WJ_SurveyBot.Fiddler_Core;
using WJ_SurveyBot.OperationsMenu;
using WJ_SurveyBot.OperationsMenu.OperationsMenu_interfaces;
using WJ_SurveyBot.Survey;

namespace WJ_SurveyBot;

internal class Program
{
    private static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddSingleton<IApplication, Application>();
        services.AddSingleton<ISurveySender, SurveySender>();
        services.AddSingleton<IHttpRequestCapture, HttpRequestCapture>();
        services.AddSingleton<ISurveySenderMenu, SurveySenderMenu>();
        services.AddSingleton<IAddSurveyPattern, AddSurveyPattern>();
        services.AddSingleton<IDeleteSurveyPatternMenu, DeleteSurveyPatternMenu>();
        var servicesProvider = services.BuildServiceProvider();
        var app = servicesProvider.GetService<IApplication>();
        app.Run();
    } 
}
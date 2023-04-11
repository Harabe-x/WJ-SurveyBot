using Microsoft.Extensions.DependencyInjection;
using WJ_SurverBot.Fiddler_Core;
using WJ_SurverBot.Survey;
using WJ_SurveyBot.Survey;

namespace WJ_SurverBot;


class Program
{

    private static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddSingleton<IApplication, Application>();
        services.AddSingleton<ISurveySender, SurveySender>();
        services.AddSingleton<IHttpRequestCapture, HttpRequestCapture>();
        var servicesProvider = services.BuildServiceProvider();
        var app = servicesProvider.GetService<IApplication>();
        app.Run();



    }
}


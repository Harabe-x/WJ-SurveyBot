using Figgle;
using Microsoft.Extensions.DependencyInjection;
using WJ_SurverBot.Json;
using WJ_SurverBot.Survey;

using WJ_SurverBot.VisualEffects;
using WJ_SurveyBot.Survey;

namespace WJ_SurverBot;


class Program
{

    private static void Main(string[] args)
    {

        var services = new ServiceCollection();
        services.AddSingleton<IApplication, Application>();
        services.AddSingleton<ISurveySender, SurveySender>();
        services.AddSingleton<IWriteAnimation, WriteAnimation>();
        services.AddSingleton<IJsonWriter, JsonWriter>();
        var servicesProvider = services.BuildServiceProvider();
        var app = servicesProvider.GetService<IApplication>();
        app.Run();



    }
}


using Microsoft.Extensions.DependencyInjection;
using WJ_SurverBot.Survey;
using WJ_SurverBot.Survey.CsvReader;
using WJ_SurverBot.Survey.Playground;

namespace WJ_SurverBot;


class Program
{

    private static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddSingleton<IApplication, Application>();
        services.AddSingleton<ISurveySender, SurveySender>();
        services.AddSingleton<ICsvReader, CsvReader>();
        services.AddSingleton<IChromeDrivePlayground, ChromeDrivePlayground>();
        var servicesProvider = services.BuildServiceProvider();
        var app = servicesProvider.GetService<IApplication>();
        app.Run();



    }
}


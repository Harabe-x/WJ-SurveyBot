using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using WJ_SurverBot;
using WJ_SurverBot.Survey;

namespace WJ_SurveyBot;


class Program
{
    private static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddSingleton<IApplication, Application>();
        services.AddSingleton<ISurveySender, SurveySender>();

        var servicesProvider = services.BuildServiceProvider();
        var app = servicesProvider.GetService<IApplication>();
        app.Run();



    }
}


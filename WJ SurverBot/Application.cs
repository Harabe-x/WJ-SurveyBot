 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WJ_SurverBot.Survey;
using WJ_SurverBot.Survey.ScenarioStrategy;

namespace WJ_SurverBot
{
    internal class Application : IApplication
    {


        private readonly ISurveySender _surveySender;

        public Application(ISurveySender surveySender)
        {
            _surveySender = surveySender;
        }
        public void Run()
        {
            IScenarioStrategy scenario = new FirstSurveyPattern();
            _surveySender.SendAnswer(scenario);

        }
    }
}
    
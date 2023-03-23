using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WJ_SurverBot.Survey.ScenarioStrategy;

namespace WJ_SurverBot.Survey
{
    internal interface ISurveySender
    {
        void SendAnswer(IScenarioStrategy scenario);
    }
}

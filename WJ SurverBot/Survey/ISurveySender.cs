using WJ_SurverBot.Survey.ScenarioStrategy;

namespace WJ_SurverBot.Survey
{
    internal interface ISurveySender
    {
        void SendAnswer(string formUrl , string[] FormAnswer, string[] textFieldsAnswer);
    }
}

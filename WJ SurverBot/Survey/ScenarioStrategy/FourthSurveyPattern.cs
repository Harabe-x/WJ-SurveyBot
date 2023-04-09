using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace WJ_SurverBot.Survey.ScenarioStrategy
{
    internal class FourthSurveyPattern : ISurveyPatternStrategy
    {
        public string[] GetSurveyAnswers()
        {
            return new string[] { "Tak" };
        }
        public string[] GetSurveyTextAnswers()
        {
            return new string[] { };
        }
    }
}

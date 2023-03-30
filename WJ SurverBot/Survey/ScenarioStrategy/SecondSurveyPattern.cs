using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace WJ_SurverBot.Survey.ScenarioStrategy
{
    internal class SecondSurveyPattern : ISurveyPatternStrategy
    {
        public string[] GetSurveyAnswers()
        {
            return new string[] { "Nie" };
        }
        public string[] GetSurveyTextAnswers()
        {
            return new string[] { };
        }
    }
}

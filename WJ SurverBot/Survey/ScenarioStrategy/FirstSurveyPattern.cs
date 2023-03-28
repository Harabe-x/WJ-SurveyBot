using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using WJ_SurverBot.Survey.CsvReader;

namespace WJ_SurverBot.Survey.ScenarioStrategy
{
    internal class FirstSurveyPattern : ISurveyPatternStrategy
    {
        public string[] GetSurveyAnswers()
        {
            return new string[] { };
        }
        public string[] GetSurveyTextAnswers()
        {
            return new string[] { };
        } 
    }

}
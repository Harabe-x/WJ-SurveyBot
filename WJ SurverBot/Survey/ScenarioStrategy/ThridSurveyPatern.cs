using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using WJ_SurverBot.Survey.CsvReader;

namespace WJ_SurverBot.Survey.ScenarioStrategy
{
    internal class ThridSurveyPatern : ISurveyPatternStrategy
    {
        public string[] GetSurveyAnswers()
        {
            return new string[] { "17-30", "Male", "Yes (go to question 5)", "Falcons", "No", "No (go to question 9)", "Already involved in another sports", "No (go to question 12)", "Top 50" };
        }
        public string[] GetSurveyTextAnswers()
        {
            return new string[] { "Jebać disa" , "123" , "456" };
        }
    }
}

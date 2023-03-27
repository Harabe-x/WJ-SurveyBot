using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using WJ_SurverBot.Survey.CsvReader;
using WJ_SurverBot.Survey.ScenarioStrategy;

namespace WJ_SurverBot.Survey
{
    internal class SurveySender : ISurveySender
    {
        private readonly ChromeDriver driver = new ChromeDriver();


        private readonly ICsvReader _csvReader;

        public SurveySender(ICsvReader csvReader = null)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            _csvReader = csvReader;
        }


        public void SendAnswer(string formUrl, string[] FormAnswer, string[] textFieldsAnswer)
        {
            driver.Navigate().GoToUrl(formUrl);
            ReadOnlyCollection<IWebElement> webElements = driver.FindElements(By.TagName("div"));
            Dictionary<string, IWebElement> surveyElemnts = new();
            IWebElement nextButton = null;
            int currentIndex = 0;


            foreach (var webElement in webElements)
            {
                Console.Title = $"Analyzing Elements [{currentIndex}/{webElements.Count}]";
                try
                {

                    foreach (var answer in FormAnswer)
                    {
                        if (answer == webElement.Text )
                        {
                            surveyElemnts.Add(webElement.Text, webElement);
                        }                        
                    }

                    if (webElement.Text == "Dalej" || webElement.Text == "Prześlij")
                    {
                        
                    }
                  
                }
                catch (ArgumentException e)
                {
                    currentIndex++;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Duplicated {webElement.ToString()}");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                currentIndex++;
                Console.Title = $"Analyzing Elements [{currentIndex}/{webElements.Count}]";
            }

            foreach (var item in surveyElemnts)
            {
                item.Value.Click();
            }

            IList<IWebElement> textareas = driver.FindElements(By.CssSelector("textarea"));
            textareas[0].Click();
            textareas[0].SendKeys(_csvReader.GetCityList("Resources\\worldcities.csv", 1)[0]);
            nextButton.Click();
        }
    }



}


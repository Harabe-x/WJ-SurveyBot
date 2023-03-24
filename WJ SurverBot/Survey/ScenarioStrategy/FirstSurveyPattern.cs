using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using WJ_SurverBot.Survey.CsvReader;
using System.Formats.Asn1;

namespace WJ_SurverBot.Survey.ScenarioStrategy
{
    internal class FirstSurveyPattern : IScenarioStrategy
    {
        private readonly ChromeDriver driver = new ChromeDriver();


        private readonly ICsvReader _csvReader;

        public FirstSurveyPattern(ICsvReader csvReader)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            _csvReader = csvReader;
            driver.Navigate().GoToUrl("https://docs.google.com/forms/d/e/1FAIpQLScJIv8gUfdGTAzk-15MY93sMag6jdXTpLP5lTvDdm1fgSrP0w/formResponse");
        }
        public void SendSurvey()
        {
            FillFirstPartOfForm();
            FillSecondPartOfForm();

        }

        private void FillFirstPartOfForm()
        {
            ReadOnlyCollection<IWebElement> webElements = driver.FindElements(By.TagName("div"));
            Dictionary<string, IWebElement> surveyElemnts = new();
            IWebElement nextButton = null;
            int currentIndex = 0;
            
           
            foreach (var webElement in webElements)
            {
                Console.Title = $"Analyzing Elements [{currentIndex}/{webElements.Count}]";
                try
                {

                    if (webElement.Text == "17-30" ||
                        webElement.Text == "Male" ||
                        webElement.Text == "Yes (go to question 5)" ||
                        webElement.Text == "Falcons" ||
                        webElement.Text == "No" ||
                        webElement.Text == "No (go to question 9)" ||
                        webElement.Text == "I'm not a sports person" ||
                        webElement.Text == "No (go to question 12)" ||
                        webElement.Text == "Top 30")
                    {
                        surveyElemnts.Add(webElement.Text, webElement);
                    }
                    if (webElement.Text == "Dalej")
                    {
                        nextButton = webElement;
                    }

                }
                catch (ArgumentException e)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    currentIndex++;
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
        private void FillSecondPartOfForm()
        {
            ReadOnlyCollection<IWebElement> webElements = driver.FindElements(By.TagName("div"));
            foreach (var webElement in webElements)
            {
               if (webElement.Text == "Prześlij")
                {
                    webElement.Click();
                    driver.Close();
                    return;   
                }
            }
        }




    }
    
}
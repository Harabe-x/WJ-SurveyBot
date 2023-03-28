using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V108.Debugger;
using System.Collections.ObjectModel;
using WJ_SurverBot.Survey.CsvReader;
using WJ_SurverBot.Survey.ScenarioStrategy;

namespace WJ_SurverBot.Survey
{
    internal class SurveySender : ISurveySender
    {

        private readonly ChromeDriver driver;


        int currentIndex = 0;

        public SurveySender()
        {
           driver = new ChromeDriver();
            
            
            Console.ForegroundColor = ConsoleColor.Cyan;
        }


        public void SendAnswer(string formUrl, string[] FormAnswer, string[] textFieldsAnswer)
        {
            driver.Navigate().GoToUrl(formUrl);


            ReadOnlyCollection<IWebElement> webElements = driver.FindElements(By.TagName("div"));


            IWebElement? webButton = null;
            

            Dictionary<string, IWebElement> surveyElemnts = new();
            
            
            foreach (var webElement in webElements)
            {

                if (webElement.Text == null)
                {
                    currentIndex++;

                    continue;
                }

                if (surveyElemnts.Count ==  FormAnswer.Length && webButton != null )
                {
                    break;
                }

                Console.Title = $"Analyzing Elements [{currentIndex}/{webElements.Count}]";
                try
                {

                    foreach (var answer in FormAnswer)
                    {
                        if (answer == webElement.Text )
                        {
                            surveyElemnts.Add(webElement.Text, webElement);
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine($"Added {webElement.ToString()} ");
                            Console.ForegroundColor = ConsoleColor.Cyan;

                        }
                    }

                    if (webElement.Text == "Dalej" || webElement.Text == "Prześlij")
                    {
                        webButton = webElement;

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Added {webElement.ToString()} ");
                        Console.ForegroundColor = ConsoleColor.Cyan;

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

            }

            foreach (var item in surveyElemnts)
            {
                item.Value.Click();
            }

            IList<IWebElement> textareas = driver.FindElements(By.CssSelector("textarea"));



            for (int i = 0; i < textareas.Count; i++)
            {
                textareas[i].Click();
                textareas[i].SendKeys(textFieldsAnswer[i]);
            }

            
            

            webButton.Click();
        }
    }



}


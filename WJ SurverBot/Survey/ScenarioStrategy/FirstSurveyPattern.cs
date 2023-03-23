using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace WJ_SurverBot.Survey.ScenarioStrategy
{
    internal class FirstSurveyPattern : IScenarioStrategy
    {
        private readonly ChromeDriver driver = new ChromeDriver();


        public FirstSurveyPattern()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://docs.google.com/forms/d/e/1FAIpQLScJIv8gUfdGTAzk-15MY93sMag6jdXTpLP5lTvDdm1fgSrP0w/formResponse");
        }
        public void SendSurvey()
        {
          //  FillFirstPartOfForm();
            Tested1();
            //IWebElement submitButton = driver.FindElement(By.CssSelector("div[role='button']"));
            //submitButton.Click();

        }

        private void FillFirstPartOfForm()
        {
            int currentIndex = 0;
           
            ReadOnlyCollection<IWebElement> webElements = driver.FindElements(By.TagName("div"));

            Dictionary<string, IWebElement> surveyElemnts = new();
            foreach (var webElement in webElements)
            {
                Console.Title = $"Analyzing Elements [{currentIndex}/{webElements.Count}]";
                try
                {

                    if (webElement.Text == "17-30" ||
                        webElement.Text == "Male" ||
                        webElement.Text == "Yes (go to question 5)" ||
                        webElement.Text == "Falcons" ||
                        webElement.Text == "Yes" ||
                        webElement.Text == "No (go to question 9)" ||
                        webElement.Text == "Lack of knowledge" ||
                        webElement.Text == "No (go to question 12)" ||
                        webElement.Text == "Top 10")
                    {
                        surveyElemnts.Add(webElement.Text, webElement);
                    }

                }
                catch (ArgumentException e)
                {
                    currentIndex++;
                    Console.WriteLine("Throw");
                }
                currentIndex++;
                Console.Title = $"Analyzing Elements [{currentIndex}/{webElements.Count}]";
            }
           
            foreach (var item in surveyElemnts)
            {
                item.Value.Click();
            }
        }
        private void Tested1()
        {


            IWebElement el = driver.FindElement(By.XPath("//*[contains(concat( \" \", @class, \" \" ), concat( \" \", \"tL9Q4c\", \" \" ))]"));
            for (int i = 0; i < 3; i++)
            {
                el.Click();
                el.SendKeys("All Girls Are The Same");
            }
                //Console.ReadKey();
            //for (int i = 0; i < 10; i++)
            //{
            //    foreach (var item in driver.FindElements(By.TagName("div")))
            //    {
            //        Console.WriteLine($"===================\nTagName:{item.TagName}\nLocation:{item.Location}\nText:{item.Text}\nitem To string: {item.ToString()}");
            //    }
            //    Console.ReadKey();
            //}
        }
    }
    
}
using WJ_SurverBot.Survey.VisualEffects;
using OpenQA.Selenium.Chrome;
using WJ_SurverBot.Survey;
using OpenQA.Selenium;


namespace WJ_SurveyBot.Survey
{
    internal class SurveySender : ISurveySender , IDisposable
    {
        private readonly ChromeDriver driver;
        private readonly AnimatedConsoleTitle titleAnimation;

        public SurveySender()
        {
            driver = new ChromeDriver();
            titleAnimation = new AnimatedConsoleTitle();
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public void SendAnswer(string formUrl, string[] formAnswer, string[] textFieldsAnswer)
        {
            driver.Navigate().GoToUrl(formUrl);
            
            var webElements = driver.FindElements(By.TagName("div"));
            var surveyElements = new Dictionary<string, IWebElement>();
            IWebElement webButton = null;

            titleAnimation.AddFrames(new[] {
                "Processing Elements [>----]",
                "Processing Elements [->---]",
                "Processing Elements [-->--]",
                "Processing Elements [--->-]",
                "Processing Elements [---->]"
            });
            
            titleAnimation.StartAnimation();

            foreach (var webElement in webElements)
            {
                if (string.IsNullOrEmpty(webElement.Text))
                {
                    continue;
                }

                if (formAnswer.Contains(webElement.Text))
                {
                    try
                    {
                        surveyElements.Add(webElement.Text, webElement);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Added {webElement} ");
                    }
                    catch (ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"Duplicated {webElement}");
                    }
                    finally
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                }
                else if (webElement.Text == "Dalej" || webElement.Text == "Prześlij")
                {
                    webButton = webElement;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Button found {webElement} ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Skipped {webElement} ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }

            titleAnimation.StopAnimation();

            Console.Title = "WJ Survey Bot v1.1.0";

            foreach (var item in surveyElements)
            {
                item.Value.Click();
            }

            var textAreas = driver.FindElements(By.CssSelector("textarea"));
            for (int i = 0; i < textAreas.Count; i++)
            {
                textAreas[i].Click();
                textAreas[i].SendKeys(textFieldsAnswer[i]);
            }

            webButton?.Click();
            
        }
        public void Dispose()
        {
            driver.Dispose();
        }

    }
}

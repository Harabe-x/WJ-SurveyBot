using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V108.Debugger;
using System;
using System.Collections.Generic;
using System.Linq;
using WJ_SurverBot.Survey;
using WJ_SurverBot.Survey.VisualEffects;
using static System.Net.Mime.MediaTypeNames;

namespace WJ_SurveyBot.Survey
{
    internal class SurveySender : ISurveySender , IDisposable
    {
        private readonly AnimatedConsoleTitle titleAnimation;

        public SurveySender()
        {
            titleAnimation = new AnimatedConsoleTitle();
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public void SendAnswer(string formUrl, string[] formAnswer, string[] textFieldsAnswer)
        {
            ChromeDriver driver = new ChromeDriver();
            //driver.Manage().Window.Minimize();
        //    driver.Manage().Window.Minimize();
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
                else   if (webElement.Text == "Dalej" || webElement.Text == "Prześlij")
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
            IList<IWebElement> textareas = driver.FindElements(By.CssSelector("textarea"));


            for (int i = 0; i < textareas.Count; i++)
            {
                textareas[i].Click();
                textareas[i].SendKeys(textFieldsAnswer[i]);
            }
                webButton?.Click();


           driver.Dispose();

        }


        public void Dispose()
        {

        }

    }
}


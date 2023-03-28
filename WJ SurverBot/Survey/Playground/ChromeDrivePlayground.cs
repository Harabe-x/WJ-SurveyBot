using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WJ_SurverBot.Survey.Playground
{
    internal class ChromeDrivePlayground : IChromeDrivePlayground
    {
        public void StartChromeDrive(string url)
        {
            ChromeDriver driver = new ChromeDriver();
           
            driver.Navigate().GoToUrl(url);


            ReadOnlyCollection<IWebElement> webElements = driver.FindElements(By.CssSelector("span"));



            foreach (var webElement in webElements)
            {
                Console.WriteLine($"x:{webElement.Location.X} y:{webElement.Location.Y}");
                Console.WriteLine(webElement.TagName);
                Console.WriteLine(webElement.Text);
                Console.WriteLine("------------------------------------");

              
            }






            driver.Close();


        }
    }
}

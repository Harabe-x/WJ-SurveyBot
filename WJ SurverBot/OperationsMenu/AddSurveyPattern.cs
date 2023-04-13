using Fiddler;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using WJ_SurverBot.Fiddler_Core;

namespace WJ_SurverBot.OperationsMenu
{
    internal class AddSurveyPattern
    {
        private readonly ChromeDriver _chromeDriver;

        private readonly IHttpRequestCapture _httpRequestCapture;

        public AddSurveyPattern(IHttpRequestCapture httpRequestCapture)
        {
            _httpRequestCapture = httpRequestCapture;
            _chromeDriver = new ChromeDriver();
            _chromeDriver.Manage().Window.Minimize();
        }

        public void Start(string formUrl, string name)
        {
            CaptureHttpResponse(formUrl);

            var requestBody = GetFormResponseSession();
            var requestUrl = GetRequestUrl(requestBody);
            var formData = ReturnSessionBodyAsDictionary(requestBody);

            var keyValuePair = new KeyValuePair<string, Dictionary<string, string>>(requestUrl, formData);

            SaveKeyValuePairToJsonFile(keyValuePair, $"C:\\tempJson\\{name}.json");
        }

        private void CaptureHttpResponse(string formUrl)
        {
            _chromeDriver.Navigate().GoToUrl(formUrl);
            _chromeDriver.Manage().Window.Maximize();
            Console.WriteLine("Press any key to continue ...");
            _httpRequestCapture.Start();

            while (true)
            {
                try
                {
                    _chromeDriver.FindElement(By.TagName("body"));
                }
                catch (NoSuchElementException)
                {
                    _httpRequestCapture.Stop();
                    break;
                }
                catch (NoSuchWindowException)
                {
                    _httpRequestCapture.Stop();
                    break;
                }

                Thread.Sleep(1000);
            }
        }

        private Session GetFormResponseSession()
        {
            return _httpRequestCapture.ReturnAllRequests().First(x => x.fullUrl.Contains("formResponse"));
        }

        private string GetRequestUrl(Session session)
        {
            return session.fullUrl;
        }

        private Dictionary<string, string> ReturnSessionBodyAsDictionary(Session session)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            var requestBody = session.GetRequestBodyAsString();
            var formEntries = requestBody.Split("&");

            foreach (var entry in formEntries)
            {
                var keyValuePair = entry.Split("=");

                if (keyValuePair.Length != 2)
                {
                    continue;
                }

                var key = WebUtility.UrlDecode(keyValuePair[0]);
                var value = WebUtility.UrlDecode(keyValuePair[1]);

                result.Add(key, value);
            }

            return result;
        }

        private void SaveKeyValuePairToJsonFile(KeyValuePair<string, Dictionary<string, string>> keyValuePair, string filePath)
        {
            string jsonString = JsonConvert.SerializeObject(keyValuePair);
            File.WriteAllText(filePath, jsonString);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using Fiddler;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WJ_SurveyBot.Fiddler_Core;

namespace WJ_SurveyBot.OperationsMenu
{
    /// <summary>
    /// Represents an implementation of the IAddSurveyPattern interface, which allows for capturing and saving survey patterns.
    /// </summary>
    internal class AddSurveyPattern : IAddSurveyPattern
    {
        private readonly IHttpRequestCapture _httpRequestCapture;

        private ChromeDriver? _chromeDriver;

        /// <summary>
        /// Initializes a new instance of the AddSurveyPattern class with the specified IHttpRequestCapture parameter.
        /// </summary>
        /// <param name="httpRequestCapture">An instance of the IHttpRequestCapture interface used to capture HTTP requests and responses.</param>
        public AddSurveyPattern(IHttpRequestCapture httpRequestCapture)
        {
            _httpRequestCapture = httpRequestCapture;
        }

        /// <summary>
        /// Starts the process of capturing and saving a survey pattern.
        /// </summary>
        /// <param name="formUrl">The URL of the survey form to capture.</param>
        /// <param name="name">The name to give to the saved survey pattern file.</param>
        public void Start(string? formUrl, string name)
        {
            CaptureHttpResponse(formUrl);

            var requestBody = GetFormResponseSession();
            var requestUrl = GetRequestUrl(requestBody);
            var formData = ReturnSessionBodyAsDictionary(requestBody);
            var keyValuePair = new KeyValuePair<string, Dictionary<string, string>>(requestUrl, formData);

            SaveKeyValuePairToJsonFile(keyValuePair, $"SurveyPatterns\\{name}.json");
        }

        /// <summary>
        /// Captures the HTTP response of the survey form URL.
        /// </summary>
        /// <param name="formUrl">The URL of the survey form to capture.</param>
        /// <remarks>This method launches a Chrome browser instance, navigates to the specified form URL, and maximizes the window. It then starts capturing HTTP requests and waits for the survey form to load. Once the form is fully loaded, it stops capturing HTTP requests and disposes of the Chrome browser instance.</remarks>

        private void CaptureHttpResponse(string? formUrl)
        {
            _chromeDriver = new ChromeDriver();
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

            _chromeDriver.Dispose();
        }

        /// <summary>
        /// Returns the session containing the form response.
        /// </summary>
        /// <returns>The session containing the form response.</returns>
        /// <remarks>This method retrieves all captured HTTP requests and returns the first session whose URL contains the string "formResponse".</remarks>

        private Session GetFormResponseSession()
        {
            return _httpRequestCapture.ReturnAllRequests().First(x => x.fullUrl.Contains("formResponse"));
        }

        /// <summary>
        /// Returns the URL of the specified session.
        /// </summary>
        /// <param name="session">The session whose URL is to be returned.</param>
        /// <returns>The URL of the specified session.</returns>
        /// <remarks>This method retrieves the full URL of the specified session.</remarks>

        private string GetRequestUrl(Session session)
        {
            return session.fullUrl;
        }

        /// <summary>
        /// Returns the form data from the specified session as a dictionary.
        /// </summary>
        /// <param name="session">The session whose form data is to be returned.</param>
        /// <returns>The form data from the specified session as a dictionary.</returns>
        /// <remarks>This method retrieves the body of the specified session as a string, splits it into form entries, and adds each entry to a dictionary with the entry key as the dictionary key and the entry value as the dictionary value. It then URL decodes both the key and value of each entry before adding it to the dictionary.</remarks>

        private Dictionary<string, string> ReturnSessionBodyAsDictionary(Session session)
        {
            var result = new Dictionary<string, string>();

            var requestBody = session.GetRequestBodyAsString();
            var formEntries = requestBody.Split("&");

            foreach (var entry in formEntries)
            {
                var keyValuePair = entry.Split("=");

                if (keyValuePair.Length != 2) continue;

                var key = WebUtility.UrlDecode(keyValuePair[0]);
                var value = WebUtility.UrlDecode(keyValuePair[1]);

                result.Add(key, value);
            }

            return result;
        }
        /// <summary>
        /// Saves the specified key-value pair to a JSON file.
        /// </summary>
        /// <param name="keyValuePair">The key-value pair to be saved.</param>
        /// <param name="filePath">The file path to save the key-value pair to.</param>
        /// <remarks>This method serializes the specified key-value pair to a JSON string and saves it to the specified file path.</remarks>

        private void SaveKeyValuePairToJsonFile(KeyValuePair<string, Dictionary<string, string>> keyValuePair,
            string filePath)
        {
            var jsonString = JsonConvert.SerializeObject(keyValuePair);
            File.WriteAllText(filePath, jsonString);
        }
    }
}

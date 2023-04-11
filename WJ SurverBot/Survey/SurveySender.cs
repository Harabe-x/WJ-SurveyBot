using WJ_SurverBot.Survey.VisualEffects;
using OpenQA.Selenium.Chrome;
using WJ_SurverBot.Survey;
using OpenQA.Selenium;
using System.Net.Http;

namespace WJ_SurveyBot.Survey
{
    internal class SurveySender : ISurveySender , IDisposable
    {


        private HttpClient _httpClient;

        public SurveySender()
        {
            _httpClient = new HttpClient();
        }
      
        public async Task SendAnswer(string requestUrl, Dictionary<string, string> httpRequestBody)
        {           
            var content = new FormUrlEncodedContent(httpRequestBody);

            var response = await _httpClient.PostAsync(requestUrl, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"------------------------\nRequest sent! \nTime:{DateTime.Now.ToString("hh:mm:ss")}");
            }
            else
            {
                Console.WriteLine($"Error. Error Code: {response.StatusCode} \n Response Content:{response.Content}");
            }
        }
        public void Dispose()
        {
            _httpClient.Dispose(); 
        }

    }
}

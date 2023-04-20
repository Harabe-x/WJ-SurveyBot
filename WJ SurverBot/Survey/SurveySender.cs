using WJ_SurveyBot.Survey;

/// <summary>
/// A class responsible for sending surveys using HTTP POST requests.
/// </summary>
internal class SurveySender : ISurveySender, IDisposable
{
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Initializes a new instance of the SurveySender class with a new instance of HttpClient.
    /// </summary>
    public SurveySender()
    {
        _httpClient = new HttpClient();
    }

    /// <summary>
    /// Disposes the HttpClient instance used by this SurveySender instance.
    /// </summary>
    public void Dispose()
    {
        _httpClient.Dispose();
    }

    /// <summary>
    /// Sends a survey answer to the specified URL using the specified HTTP request
    /// body.
    /// </summary>
    /// <param name="requestUrl">The URL to send the survey to.</param>
    /// <param name="httpRequestBody">The HTTP request body containing the survey answer.</param>
    public async Task SendAnswer(string requestUrl, Dictionary<string, string> httpRequestBody)
    {
        var content = new FormUrlEncodedContent(httpRequestBody);

        var responseTask = _httpClient.PostAsync(requestUrl, content);

        responseTask.Wait();

        var response = responseTask.Result;

        Console.WriteLine(response.IsSuccessStatusCode
            ? $"------------------------\nSurvey sent! \nTime:{DateTime.Now:hh:mm:ss}"
            : $"Error. Error Code: {response.StatusCode} \n Response Content:{response.Content}");
    }
}
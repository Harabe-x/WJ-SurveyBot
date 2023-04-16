namespace WJ_SurveyBot.Survey;

internal class SurveySender : ISurveySender, IDisposable
{
    private readonly HttpClient _httpClient;

    public SurveySender()
    {
        _httpClient = new HttpClient();
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }

    public async Task SendAnswer(string requestUrl, Dictionary<string, string> httpRequestBody)
    {
        var content = new FormUrlEncodedContent(httpRequestBody);

        var response = await _httpClient.PostAsync(requestUrl, content);

        Console.WriteLine(response.IsSuccessStatusCode
            ? $"------------------------\nSurvey sent! \nTime:{DateTime.Now:hh:mm:ss}"
            : $"Error. Error Code: {response.StatusCode} \n Response Content:{response.Content}");
    }
}
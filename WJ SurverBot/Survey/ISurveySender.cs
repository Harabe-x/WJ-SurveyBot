namespace WJ_SurverBot.Survey
{
    internal interface ISurveySender
    {
        Task SendAnswer(string requestUrl,Dictionary<string , string> httpRequestBody);
    }
}

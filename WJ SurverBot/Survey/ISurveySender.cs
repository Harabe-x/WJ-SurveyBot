namespace WJ_SurveyBot.Survey;

internal interface ISurveySender
{
    Task SendAnswer(string requestUrl, Dictionary<string, string> httpRequestBody);
}
using Fiddler;

namespace WJ_SurveyBot.Fiddler_Core;

internal interface IHttpRequestCapture
{
    public void Start();
    public void Stop();
    public Session FindRequest(string url);
    public List<Session> ReturnAllRequests();

    public bool InstallCertificate();
}
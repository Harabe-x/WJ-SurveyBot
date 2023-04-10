using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiddler;

namespace WJ_SurverBot.Fiddler_Core
{
    internal class RequestCapture : IRequestCapture
    {
        private readonly List<Session> capturedSessions;

        public RequestCapture()
        {
            capturedSessions = new List<Session>();
        }

        public Session FindRequest(string url)
        {
            return capturedSessions.FirstOrDefault(x => x.fullUrl == url);
        }

        public List<Session> ReturnAllRequests()
        {
            return capturedSessions.ToList();
        }

        public void Start()
        {
            FiddlerApplication.AfterSessionComplete += OnRequest;

            var settings = new FiddlerCoreStartupSettingsBuilder()
                .RegisterAsSystemProxy()
                .Build();

            FiddlerApplication.Startup(settings);

            Console.ReadLine();
        }

        public void Stop()
        {
            FiddlerApplication.Shutdown();
        }

        private void OnRequest(Session session)
        {
            capturedSessions.Add(session);
            Console.WriteLine($"-----------------\nRequest To: {session.fullUrl}\nClient IP: {session.clientIP}\nResponseBody: {session.GetResponseBodyAsString()}");
        }
    }
}

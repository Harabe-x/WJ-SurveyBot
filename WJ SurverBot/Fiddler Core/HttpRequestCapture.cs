using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiddler;
using Newtonsoft.Json;

namespace WJ_SurverBot.Fiddler_Core
{
    internal class HttpRequestCapture : IHttpRequestCapture
    {

        public bool IsCaptureEnabled { get;  set; }


        public bool SaveRequestsToFile { get;  set; }


        private readonly List<Session> capturedSessions;

        public HttpRequestCapture()
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


        public  bool InstallCertificate()
        {
            if (!CertMaker.rootCertExists())
            {
                if (!CertMaker.createRootCert())
                    return false;

                if (!CertMaker.trustRootCert())
                    return false;
            }

            return true;
        }

        public void Start()
        {
            Thread thread = new(StartCaptureInSepartedThread);
            thread.Start();
        }


        private void StartCaptureInSepartedThread()
        {
            if (IsCaptureEnabled)
            {
                return;
            }


            FiddlerApplication.AfterSessionComplete += OnRequest;

            var settings = new FiddlerCoreStartupSettingsBuilder()
                .ListenOnPort(8888)
                .RegisterAsSystemProxy()
                .DecryptSSL()
                .Build();


            FiddlerApplication.Startup(settings);
            IsCaptureEnabled = true;
            Console.ReadLine();
        }


        public void Stop()
        {
            IsCaptureEnabled = false;
            FiddlerApplication.Shutdown();
        }

        private void OnRequest(Session session)
        {
            capturedSessions.Add(session); 
        }
    }
}

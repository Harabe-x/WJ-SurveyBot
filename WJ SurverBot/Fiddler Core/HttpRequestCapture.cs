using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiddler;
using Newtonsoft.Json;

namespace WJ_SurveyBot.Fiddler_Core
{
    internal class HttpRequestCapture : IHttpRequestCapture
    {

        public bool IsCaptureEnabled { get;  set; }

        private readonly List<Session> _capturedSessions;

        public HttpRequestCapture()
        {
            _capturedSessions = new List<Session>();
        }



        public Session FindRequest(string url)
        {
            return _capturedSessions.FirstOrDefault(x => x.fullUrl == url);
        }

        public List<Session> ReturnAllRequests()
        {
            return _capturedSessions.ToList();
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
            Thread thread = new(StartCaptureInSeparatedThread);
            thread.Start();
        }

    

        private void StartCaptureInSeparatedThread()
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
            if (!IsCaptureEnabled)
            {
                return;
            }
            FiddlerApplication.Shutdown();
            IsCaptureEnabled = false;
        }   
   

        private void OnRequest(Session session)
        {
            _capturedSessions.Add(session); 
        }
    }
}

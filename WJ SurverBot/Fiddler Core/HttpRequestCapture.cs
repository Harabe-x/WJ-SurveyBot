using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiddler;
using Newtonsoft.Json;

namespace WJ_SurveyBot.Fiddler_Core
{
    /// <summary>
    /// Represents a class for capturing HTTP requests using Fiddler Core library.
    /// </summary>
    internal class HttpRequestCapture : IHttpRequestCapture
    {
        /// <summary>
        /// Flag indicating whether capture is enabled or not.
        /// </summary>
        public bool IsCaptureEnabled { get; set; }

        /// <summary>
        /// List of captured sessions.
        /// </summary>
        private readonly List<Session?> _capturedSessions;

        /// <summary>
        /// Initializes a new instance of the HttpRequestCapture class.
        /// </summary>
        public HttpRequestCapture()
        {
            _capturedSessions = new List<Session>();
        }

        /// <summary>
        /// Returns a request specified by URL.
        /// </summary>
        /// <param name="url">The URL of the request to find.</param>
        /// <returns>The request session matching the URL, if found.</returns>
        public Session FindRequest(string url)
        {
            return _capturedSessions.FirstOrDefault(x => x.fullUrl == url);
        }

        /// <summary>
        /// Returns a list of all captured requests.
        /// </summary>
        /// <returns>A list of all captured requests.</returns>
        public List<Session> ReturnAllRequests()
        {
            return _capturedSessions.ToList();
        }

        /// <summary>
        /// Installs an SSL certificate.
        /// </summary>
        /// <returns>True if certificate installation was successful; otherwise, false.</returns>
        public bool InstallCertificate()
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

        /// <summary>
        /// Starts the capture on a separate thread.
        /// </summary>
        public void Start()
        {
            Thread thread = new(StartCaptureInSeparatedThread);
            thread.Start();
        }

        /// <summary>
        /// Fiddler Core configuration and request capture.
        /// </summary>
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

        /// <summary>
        /// Stops the capture.
        /// </summary>
        public void Stop()
        {
            if (!IsCaptureEnabled)
            {
                return;
            }
            FiddlerApplication.Shutdown();
            IsCaptureEnabled = false;
        }

        /// <summary>
        /// Event handler for request capture.
        /// </summary>
        /// <param name="session">The captured HTTP request session.</param>
        private void OnRequest(Session session)
        {
            _capturedSessions.Add(session);
        }
    }
}

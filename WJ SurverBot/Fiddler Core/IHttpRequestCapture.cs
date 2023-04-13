using Fiddler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WJ_SurverBot.Fiddler_Core
{
    internal interface IHttpRequestCapture
    {
        public void Start();
        public void Stop();
        public Session FindRequest(string url);
        public List<Session> ReturnAllRequests();

        public bool InstallCertificate();


    }
}

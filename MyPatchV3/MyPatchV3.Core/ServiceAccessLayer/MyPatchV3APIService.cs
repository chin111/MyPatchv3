using System;
using System.Net.Http;
using Refit;
using Fusillade;

namespace MyPatchV3.SAL
{
    public class MyPatchV3APIService : IAPIService
    {
        //      public const string APIBaseURL = "http://192.168.2.222:9810/api";
        public const string APIBaseURL = "http://127.0.0.1:8080/api";

        public MyPatchV3APIService(string BaseURL = null)
        {
            Func<HttpMessageHandler, IMyPatchV3API> createClient = messageHandler => {
                var client = new HttpClient(messageHandler)
                {
                    BaseAddress = new Uri(BaseURL ?? APIBaseURL)
                };
                
                return RestService.For<IMyPatchV3API>(client);
            };

            _background = new Lazy<IMyPatchV3API>(() => createClient(new RateLimitedHttpMessageHandler(new HttpClientHandler(), Priority.Background)));

            _userInitiated = new Lazy<IMyPatchV3API>(() => createClient(new RateLimitedHttpMessageHandler(new HttpClientHandler(), Priority.UserInitiated)));

            _speculative = new Lazy<IMyPatchV3API>(() => createClient(new RateLimitedHttpMessageHandler(new HttpClientHandler(), Priority.Speculative)));

        }

        private readonly Lazy<IMyPatchV3API> _background;
        private readonly Lazy<IMyPatchV3API> _userInitiated;
        private readonly Lazy<IMyPatchV3API> _speculative;

        public IMyPatchV3API Background
        {
            get { return _background.Value; }
        }

        public IMyPatchV3API UserInitiated
        {
            get { return _userInitiated.Value; }
        }

        public IMyPatchV3API Speculative
        {
            get { return _speculative.Value; }
        }
    }
}


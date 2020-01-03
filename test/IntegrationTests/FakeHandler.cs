using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class FakeHandler : DelegatingHandler
    {
        private readonly HttpResponseMessage _response;

        public FakeHandler(HttpResponseMessage response = null)
        {
            _response = response ?? new HttpResponseMessage(HttpStatusCode.OK);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_response);
        }
    }
}
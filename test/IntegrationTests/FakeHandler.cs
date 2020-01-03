using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class FakeHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
}
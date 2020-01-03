using System.Net;
using System.Net.Http;
using IntegrationTestingHttpClientFactorSample;

namespace IntegrationTests
{
    public class FakeHttpClientFactoryWhereTypedClientTwoWillFail : IHttpClientFactory
    {
        public HttpClient CreateClient(string name)
        {
            return name switch
            {
                nameof(IMyTypedClient) => new HttpClient(new FakeHandler()),
                _ => new HttpClient(new FakeHandler(new HttpResponseMessage(HttpStatusCode.BadRequest)))
            };
        }
    }
}
using System.Net.Http;

namespace IntegrationTests
{
    public class FakeHttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string name)
        {
            return new HttpClient(new FakeHandler());
        }
    }
}
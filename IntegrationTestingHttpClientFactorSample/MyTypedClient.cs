using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationTestingHttpClientFactorSample
{
    public class MyTypedClient : IMyTypedClient
    {
        private readonly HttpClient _httpClient;

        public MyTypedClient(HttpClient httpClient) => _httpClient = httpClient;

        public async Task MakeRequest()
        {
            await _httpClient.GetAsync("https://www.mythingthatdoesnotexist.com");
        }
    }
}
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationTestingHttpClientFactorSample
{
    public class MyTypedClientTwo : IMyTypedClientTwo
    {
        private readonly HttpClient _httpClient;

        public MyTypedClientTwo(HttpClient httpClient) => _httpClient = httpClient;

        public async Task MakeRequest()
        {
            var result = await _httpClient.GetAsync("https://www.mythingthatdoesnotexist.com");
        }
    }
}
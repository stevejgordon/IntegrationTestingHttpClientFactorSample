using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class WeatherForecastTests : IClassFixture<ApplicationTestFixture>
    {
        private readonly HttpClient _client;

        public WeatherForecastTests(ApplicationTestFixture fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task TestingGetRequest()
        {
            var result = await _client.GetAsync("WeatherForecast");

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}

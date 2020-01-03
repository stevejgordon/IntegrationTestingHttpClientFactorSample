using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Xunit;

namespace IntegrationTests
{
    public class WeatherForecastTests : IClassFixture<ApplicationTestFixture>
    {
        private readonly ApplicationTestFixture _fixture;
        private readonly HttpClient _client;

        public WeatherForecastTests(ApplicationTestFixture fixture)
        {
            _fixture = fixture;
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task TestingGetRequest()
        {
            var result = await _client.GetAsync("WeatherForecast");

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task TestingGetRequest_WithSeparateBehavioursForEachClient()
        {
            var client = _fixture.WithWebHostBuilder(b =>
            {
                b.ConfigureTestServices(services =>
                {
                    services.RemoveAll<IHttpClientFactory>();
                    services.AddSingleton<IHttpClientFactory, FakeHttpClientFactoryWhereTypedClientTwoWillFail>();
                });
            }).CreateClient();

            var result = await client.GetAsync("WeatherForecast");

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}

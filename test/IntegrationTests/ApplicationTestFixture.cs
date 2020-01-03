using System.Net.Http;
using IntegrationTestingHttpClientFactorSample;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace IntegrationTests
{
    public class ApplicationTestFixture : WebApplicationFactory<Program>
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = base.CreateHostBuilder()
                .ConfigureServices(services =>
                {
                    services.RemoveAll<IHttpClientFactory>();
                    services.AddSingleton<IHttpClientFactory, FakeHttpClientFactory>();
                });

            return builder;
        }
    }
}
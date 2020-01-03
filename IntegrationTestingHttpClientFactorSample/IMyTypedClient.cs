using System.Threading.Tasks;

namespace IntegrationTestingHttpClientFactorSample
{
    public interface IMyTypedClient
    {
        Task MakeRequest();
    }
}
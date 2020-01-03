using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IntegrationTestingHttpClientFactorSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMyTypedClient _myTypedClient;
        private readonly IMyTypedClientTwo _myTypedClientTwo;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMyTypedClient myTypedClient, IMyTypedClientTwo myTypedClientTwo)
        {
            _logger = logger;
            _myTypedClient = myTypedClient;
            _myTypedClientTwo = myTypedClientTwo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _myTypedClient.MakeRequest();

            await _myTypedClientTwo.MakeRequest();

            return Ok();
        }
    }
}

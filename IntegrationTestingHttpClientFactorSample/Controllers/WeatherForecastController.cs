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

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMyTypedClient myTypedClient)
        {
            _logger = logger;
            _myTypedClient = myTypedClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _myTypedClient.MakeRequest();

            return Ok();
        }
    }
}

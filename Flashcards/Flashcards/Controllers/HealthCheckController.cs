using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Net;

namespace flashcards.Controllers
{
    [Route("api/[controller]")]
    public class HealthCheckController : Controller
    {
        private readonly ILogger<HealthCheckController> _logger;

        public HealthCheckController(ILogger<HealthCheckController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet()] 
        public IActionResult Get() 
        {
            _logger.LogInformation("healthcheck");
            return Ok("ok");
        }

        [AllowAnonymous]
        [HttpGet("ip")]
        public IActionResult GetIp()
        {
            _logger.LogInformation("ip");
            var externalip = new WebClient().DownloadString("http://icanhazip.com");
            return Ok(externalip);
        }

        [AllowAnonymous]
        [HttpGet("folder")]
        public IActionResult GetFolder()
        {
            _logger.LogInformation("folder");
            string path = Directory.GetCurrentDirectory();
            return Ok(path);
        }
    }
}

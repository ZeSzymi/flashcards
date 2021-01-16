using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;

namespace flashcards.Controllers
{
    [Route("api/[controller]")]
    public class HealthCheckController : Controller
    {
        [AllowAnonymous]
        [HttpGet()] 
        public IActionResult Get() 
        {
            return Ok("ok");
        }

        [AllowAnonymous]
        [HttpGet("ip")]
        public IActionResult GetIp()
        {
            var externalip = new WebClient().DownloadString("http://icanhazip.com");
            return Ok(externalip);
        }

        [AllowAnonymous]
        [HttpGet("folder")]
        public IActionResult GetFolder()
        {
            string path = Directory.GetCurrentDirectory();
            return Ok(path);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}

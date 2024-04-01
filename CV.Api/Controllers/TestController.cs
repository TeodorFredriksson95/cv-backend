using Microsoft.AspNetCore.Mvc;

namespace CV_backend.Controllers
{
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet]
        [Route("api/test")]
        public IActionResult Index()
        {
            return Ok(new {message = "test controller went through"});
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return Redirect("~/swagger");
        }
    }
}
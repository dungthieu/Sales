
using Microsoft.AspNetCore.Mvc;

namespace Sale.Api.Controllers
{
    public class AboutController : Controller
    {
        [Route("trang-chu.html")]
        public IActionResult Index()
        {
            return View();
        }
    }
}


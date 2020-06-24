using Microsoft.AspNetCore.Mvc;

namespace COVIDApplicationView.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
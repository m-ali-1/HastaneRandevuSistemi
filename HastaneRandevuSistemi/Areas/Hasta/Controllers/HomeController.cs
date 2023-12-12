using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevuSistemi.Areas.Hasta.Controllers
{
    [Area("Hasta")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

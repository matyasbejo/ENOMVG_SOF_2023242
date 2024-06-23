using Microsoft.AspNetCore.Mvc;

namespace ENOMVG_SOF_2023242.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace ElecCarWebApp.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome (int ID)
        {
            ViewData["message"] = "this is a message";
            return View();

        }
    }
}
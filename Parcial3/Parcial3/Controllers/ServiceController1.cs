using Microsoft.AspNetCore.Mvc;

namespace Parcial3.Controllers
{
    public class ServiceController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

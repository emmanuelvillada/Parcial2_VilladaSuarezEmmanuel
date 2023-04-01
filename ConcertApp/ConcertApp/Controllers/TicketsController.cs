using Microsoft.AspNetCore.Mvc;

namespace ConcertApp.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace BlackJack.WEB.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
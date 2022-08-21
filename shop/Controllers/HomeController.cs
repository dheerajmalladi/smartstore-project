using Microsoft.AspNetCore.Mvc;

namespace shop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult welcome()
        {
            return View();
        }
    }
}

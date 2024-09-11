using Microsoft.AspNetCore.Mvc;

namespace TechnologyKidaASPnetcoreMVC.Controllers
{
    public class TestController : Controller
    {
        static int a = 0;
        public IActionResult showButton()
        {

            ++a;
            return View(a);
        }
    }
}

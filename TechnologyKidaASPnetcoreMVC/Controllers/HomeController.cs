using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechnologyKidaASPnetcoreMVC.Models;

namespace TechnologyKidaASPnetcoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<People> people = new List<People>();
            
            people.Add(new People { id = 1, Name = "Ram", city = "pune" });
            people.Add(new People { id = 2, Name = "sham", city="mumbai" });
            people.Add(new People { id = 3, Name = "sai", city="satara" });
            people.Add(new People { id = 4, Name = "rupa", city="karad" });
            return View("Index",people);
            //people.id = 1;
            //people.Name = "Test";
            //people.city = "Pune";
            //int a = 10;
          
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

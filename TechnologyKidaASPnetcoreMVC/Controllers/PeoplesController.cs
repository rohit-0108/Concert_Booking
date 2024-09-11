using Microsoft.AspNetCore.Mvc;
using TechnologyKidaASPnetcoreMVC.Data;
using TechnologyKidaASPnetcoreMVC.Models;

namespace TechnologyKidaASPnetcoreMVC.Controllers
{
    public class PeoplesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeoplesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var people= _context.People.ToList();
            return View(people);
        }

        //HttpGet,HttpPost :People/Index

        //create new People
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(People people)
        {
            _context.People.Add(people);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Edit a people
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var people= _context.People.Find(id);
            return View(people);
        } 
        [HttpPost]
        public IActionResult Edit(People people)
        {
            _context.People.Update(people);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        //delete a people


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var people = _context.People.Find(id);
            return View(people);
        }
        [HttpPost]
        public IActionResult Delete(People people)
        {
            _context.People.Remove(people);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}

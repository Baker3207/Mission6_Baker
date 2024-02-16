using Microsoft.AspNetCore.Mvc;
using Mission6.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private readonly MoviesContext _context;

        public HomeController(MoviesContext temp)
        {
            _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetToKnow()
        {
            return View("GetToKnow");


        }
        public IActionResult addMovie()
        {
            return View("addMovie");


        }

        [HttpPost]
        public IActionResult addMovie(movie response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();

            return View("thanks", response);
        }
    }
}

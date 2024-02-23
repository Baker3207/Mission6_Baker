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
       
        [HttpGet]

        public IActionResult AddMovie()
        {
            //ViewBag.Ratings = _context.Ratings.ToList();
            return View("AddMovie", new movie());
        }

        [HttpPost]
        public IActionResult AddMovie(movie response)
        {
            if (ModelState.IsValid)
            {
                // Assuming Rating is a navigation property
                _context.Movies.Add(response);
                _context.SaveChanges();

                // Redirect to "Thanks" action
                return RedirectToAction("Thanks", new { id = response.MovieID });
            }

            // If ModelState is not valid, return to the AddMovie view with the provided response model
            return View("AddMovie", response);
        }

        public IActionResult movieDB()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }


        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieID == id);

            return View("addMovie", recordToEdit);
        }

        [HttpPost]
         public IActionResult Edit(movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("movieDB");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieID == id);

            return View(recordToDelete);
        }

        [HttpPost]

        public IActionResult Delete(movie deleteMovie)
        {
            _context.Movies.Remove(deleteMovie);
            _context.SaveChanges();

            return RedirectToAction("movieDB");
        }

        public IActionResult Thanks(int id)
        {
            // Retrieve the movie from the database based on the id
            var movie = _context.Movies.FirstOrDefault(m => m.MovieID == id);

            if (movie != null)
            {
                // Pass the movie to the "Thanks" view
                return View(movie);
            }

            // If the movie is not found, you might handle this case accordingly
            return View("Error");
        }


    }


}

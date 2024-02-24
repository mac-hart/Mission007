using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission06.Models;
using System.Diagnostics;

namespace Mission06.Controllers
{
    public class HomeController : Controller
    {

        private MovieContext _movieContext;
        public HomeController(MovieContext temp)
        {
            _movieContext = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SubmitMovie()
        {
            ViewBag.Categories = _movieContext.Categories
                .Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.CategoryName })
                .ToList();

            return View("SubmitMovie");
        }

        [HttpPost]

        public IActionResult SubmitMovie(SubmitMovie response)
        {
             
            _movieContext.Movies.Add(response); //add record to database
            _movieContext.SaveChanges();

            return View("Confirmation", response);
        }

        public IActionResult Data ()
        {
            var movies = _movieContext.Movies
                .OrderBy(x => x.Title).ToList();
            
            return View(movies);
        }


        [HttpGet]
        public IActionResult Edit (int id) 
        {
            var recordToEdit = _movieContext.Movies
                .Single(x => x.MovieID == id);

            var categories = _movieContext.Categories
            .Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.CategoryName })
            .ToList();

            ViewBag.Categories = categories;

            return View("SubmitMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(SubmitMovie updatedInfo)
        {
            _movieContext.Update(updatedInfo);
            _movieContext.SaveChanges();

            return RedirectToAction("Data");
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        { 
            var recordToDelete = _movieContext.Movies
                .Single(x => x.MovieID.Equals(id));

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(SubmitMovie deletion)
        {
            _movieContext.Movies.Remove(deletion);
            _movieContext.SaveChanges();

            return RedirectToAction("Data");

        }

    }
}

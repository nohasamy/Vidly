using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyStore.Models;
using VidlyStore.ViewModels;

namespace VidlyStore.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        } 
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Display()
        {
            var movies = _context.Movies.Include(m => m.Genre);
            return View(movies);
        }
        public ActionResult Details(int? id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
        

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>()
            {
                new Customer() {Name = "customer 1"},
                new Customer() {Name = "customer 2"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(MovieFormViewModel viewModel) // OR Movie movie
        {
            if (viewModel.Movie.Id == 0)
            {
                viewModel.Movie.AddedDate = DateTime.Now;
                _context.Movies.Add(viewModel.Movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == viewModel.Movie.Id);
                movieInDb.Name = viewModel.Movie.Name;
                movieInDb.ReleaseDate = viewModel.Movie.ReleaseDate;
                movieInDb.NumberInStock = viewModel.Movie.NumberInStock;
                movieInDb.GenreId = viewModel.Movie.GenreId;
                
            }

            _context.SaveChanges();
            return RedirectToAction("Display", "Movies");
        }

    }
}
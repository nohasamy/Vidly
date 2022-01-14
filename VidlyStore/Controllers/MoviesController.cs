﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyStore.Models;
using VidlyStore.ViewModels;

namespace VidlyStore.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Display()
        {
            var movies = GetMovies();
            return View((object)movies);
        }

        public static List<Movie> GetMovies()
        {
            var movies = new List<Movie>()
            {
                new Movie {Id = 1, Name = "Coco"},
                new Movie {Id = 2, Name = "Soul!"}
            };
            return movies;
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
    }
}
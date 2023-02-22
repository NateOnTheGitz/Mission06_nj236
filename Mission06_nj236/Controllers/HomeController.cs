using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission06_nj236.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_nj236.Controllers
{
    public class HomeController : Controller
    {
        private MovieDBContext MovieContext { get; set; }

        //Controller
        public HomeController(MovieDBContext con)
        {
            MovieContext = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FillOutMovieForm ()
        {
            ViewBag.Categories = MovieContext.Categories.ToList();

            return View("MovieForm");
        }

        [HttpPost]
        public IActionResult FillOutMovieForm(MovieInfo MI)
        {
            MovieContext.Add(MI);
            MovieContext.SaveChanges();
            return View("Confirmation", MI);
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var movies = MovieContext.MovieInfos
                .Include(x => x.Category)
                .ToList();

            return View(movies);
        }

    }
}

//This is a change at the end of the controllers page

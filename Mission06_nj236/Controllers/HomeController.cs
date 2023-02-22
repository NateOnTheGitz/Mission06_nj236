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

            return View("MovieForm", new MovieInfo());
        }

        [HttpPost]
        public IActionResult FillOutMovieForm(MovieInfo MI)
        {
            if (ModelState.IsValid)
            {
                MovieContext.Add(MI);
                MovieContext.SaveChanges();
                return View("Confirmation", MI);
            }
            else //If invalid
            {
                ViewBag.Categories = MovieContext.Categories.ToList();
                return View(MI);
            }
            
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

        [HttpGet]
        public IActionResult Edit (int id)
        {
            ViewBag.Categories = MovieContext.Categories.ToList();

            var MovieInfo = MovieContext.MovieInfos.Single(x => x.MovieID == id);

            return View("MovieForm", MovieInfo);
        }

        [HttpPost]
        public IActionResult Edit (MovieInfo edd)
        {
            MovieContext.Update(edd);
            MovieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete (int id)
        {
            var Movie = MovieContext.MovieInfos.Single(x => x.MovieID == id);
            return View(Movie);
        }

        [HttpPost]
        public IActionResult Delete (MovieInfo MI)
        {
            MovieContext.MovieInfos.Remove(MI);
            MovieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }

    }
}

//This is a change at the end of the controllers page

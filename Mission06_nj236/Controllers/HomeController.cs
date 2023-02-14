using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;
        private MovieDBContext MovieContext { get; set; }

        //Controller
        public HomeController(ILogger<HomeController> logger, MovieDBContext con)
        {
            _logger = logger;
            MovieContext = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FillOutMovieForm ()
        {
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

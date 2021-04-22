using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private MyContext _context;

        public MoviesController()
        {
            _context = new MyContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }
        // GET: Movies
        // Movies/Randome

        public ActionResult GetMovies()
        {
            var movies = _context.Movies.ToList();
       
            return View(movies);
        }

        public ActionResult ShowMovieById(int id)
        {

            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);

        }


    } 
}
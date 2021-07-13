using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoService.Models;
using VideoService.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoService.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrEmpty(sortBy))
            {
                sortBy = "Name";
            }

            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };


            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        //Get: Movies/Random
        public ActionResult Random()
        {
            var movies = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };


            var viewModel = new RandomMovieViewModel
            {
                Movies = movies,
                Customers = customers
            };

            return View(viewModel);
            //return new ViewResult();
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        [Route("movies/released/{year}/{month:regex(^\\d{{2}}$):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
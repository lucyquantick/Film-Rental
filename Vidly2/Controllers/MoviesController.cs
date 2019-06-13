using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
//using Vidly.ViewModels;

namespace Vidly2.Controllers
{
	public class MoviesController : Controller
	{
		public ActionResult Index()
		{
			var movies = GetMovies();

			return View(movies);
		}

		private IEnumerable<Movie> GetMovies()
		{
			return new List<Movie>
			{
				new Movie { Id = 1, Name = "Shrek" },
				new Movie { Id = 2, Name = "Winnie the Pooh" }
			};
		}


		// ----------------------Random example-------------------
		// Movies / Random
		/*
		public ActionResult Random()
		{
			// creating an instance of our movie model
			var movie = new Movie() { Name = "Shrek" };

			var customers = new List<Customer>
			{
				new Customer { Name = "Customer 1"},
				new Customer { Name = "Customer 2"}
			};

			return Content("test");

			//var ViewModel = new RandomMovieViewModel
			//{
			//	Movie = movie,
			//	Customers = customers
			//};

			// ways of passing data to the view
			//ViewData["Movie"] = movie;
			//ViewBag.Movie = movie;
			//return View(ViewModel);
		}
		*/


		//-----------------Attribute Routing example-----------------------
		/*
		[Route("movies/released/{year}/{month:regex(\\d{4}:range(1, 12))}")]
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content(year + "/" + month);
		}
		*/

	}
}
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;
using Vidly2.Migrations;
using System.Data.Entity.Validation;

namespace Vidly2.Controllers
{
	public class MoviesController : Controller
	{

		//  Need a Db Context in order to access the DB to get list of movies from the DB
		private ApplicationDbContext _context;

		// Initialise DbContext in the constructor
		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ActionResult New()
		{
			var genres = _context.Genres.ToList();
			var viewModel = new MovieFormViewModel
			{
				//Movie = new Movie(),
				Genres = genres
			};

			return View("MovieForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Movie movie)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new MovieFormViewModel(movie)
				{
			
					Genres = _context.Genres.ToList()
				};
				return View("MovieForm", viewModel);
			}

			if (movie.Id == 0)
			{
				movie.DateAdded = DateTime.Now;
				_context.Movies.Add(movie);
			}
				
			else
			{
				var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

				movieInDb.Name = movie.Name;
				movieInDb.ReleaseDate = movie.ReleaseDate;
				movieInDb.GenreId = movie.GenreId;
				movieInDb.NumberInStock = movie.NumberInStock;
			}

			//_context.Movies.Add(movie);		
			_context.SaveChanges();
		

			return RedirectToAction("Index", "Movies");
		}

		public ActionResult Index()
		{
			//var movies = GetMovies();
			var movies = _context.Movies.Include(m => m.Genre).ToList();

			return View(movies);
		}

		public ActionResult Details(int id)
		{
			var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

			return movie == null ? HttpNotFound() : (ActionResult)View(movie);
		}

		public ActionResult Edit(int id)
		{
			var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

			if (movie == null)
				return HttpNotFound();

			var viewModel = new MovieFormViewModel(movie)
			{
				Genres = _context.Genres.ToList()
			};

			return View("MovieForm", viewModel);
		}

		//private IEnumerable<Movie> GetMovies()
		//{
		//	return new List<Movie>
		//	{
		//		new Movie { Id = 1, Name = "Shrek" },
		//		new Movie { Id = 2, Name = "Winnie the Pooh" }
		//	};
		//}


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
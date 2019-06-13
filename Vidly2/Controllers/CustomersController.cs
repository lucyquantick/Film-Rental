using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;

namespace Vidly2.Controllers
{
	public class CustomersController : Controller
	{

		//  Need a Db Context in order to access the DB to get list of customers from the DB
		private ApplicationDbContext _context;

		// Initialise DbContext in the constructor
		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}

		// DbContext is a disposable object so need to properly dispose of this object
		// To to this override the Dispose method of the base controller class
		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		// Customers / Index
		public ActionResult Index()
		{
			//var customers = GetCustomers();
			var customers = _context.Customers.Include(c => c.MembershipType).ToList();

			return View(customers);
		}

		// Customers / Details
		public ActionResult Details(int id)
		{
			var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

			return customer == null ? HttpNotFound() : (ActionResult)View(customer);
		}

		//private IEnumerable<Customer> GetCustomers()
		//{
		//	return new List<Customer>
		//		{
		//			new Customer { Id = 1, Name = "Lucy" },
		//			new Customer { Id = 2, Name = "Peter" }
		//		};
		//}

	}
}
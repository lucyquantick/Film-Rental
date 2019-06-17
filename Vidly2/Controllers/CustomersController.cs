using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;
using Vidly2.Migrations;

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

		public ActionResult New()
		{
			var membershipTypes = _context.MembershipTypes.ToList();
			var viewModel = new CustomerFormViewModel
			{
				Customer = new Customer(),
				MembershipTypes = membershipTypes
			};
			return View("CustomerForm", viewModel);
		}

		[HttpPost] // ensures this action can only be called by HttpPost and not HttpGet
		[ValidateAntiForgeryToken]
		public ActionResult Save(Customer customer)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new CustomerFormViewModel
				{
					Customer = customer,
					MembershipTypes = _context.MembershipTypes.ToList()
				};
				return View("CustomerForm", viewModel);
			}

			if (customer.Id == 0)
				_context.Customers.Add(customer);
			else
			{
				// to update an Entity we need to get it from the DB first
				// so our DbContext can track changes in that Entity
				// Then we modify various properties then we call SaveChanges()
				var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

				// TryUpdateModel(customerInDb, "",  new string[] { "Name", "Email" });

				customerInDb.Name = customer.Name;
				customerInDb.Birthdate = customer.Birthdate;
				customerInDb.MembershipTypeId = customer.MembershipTypeId;
				customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

				// Mapper.Map(customer, customerInDb);

			}

			//_context.Customers.Add(customer);
			_context.SaveChanges();

			return RedirectToAction("Index", "Customers");
		}

		// Customers / Index
		public ActionResult Index()
		{
			//var customers = _context.Customers.Include(c => c.MembershipType).ToList();

			//return View(customers);
			return View();
		}

		// Customers / Details
		public ActionResult Details(int id)
		{
			var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

			return customer == null ? HttpNotFound() : (ActionResult)View(customer);
		}

		public ActionResult Edit(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customer == null) return HttpNotFound();

			var viewModel = new CustomerFormViewModel
			{
				Customer = customer,
				MembershipTypes = _context.MembershipTypes.ToList()
			};

			return View("CustomerForm", viewModel);
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
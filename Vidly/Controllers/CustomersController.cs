using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.DatabaseResource;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private VidlYDbContext _context;

        public CustomersController()
        {
            _context = new VidlYDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("Customers")]
        public ActionResult Customers()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        [Route("Customers/New")]
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("Form", viewModel);
        }

        [Route("Customers/Edit/{id}")]
        public ActionResult Edit(int Id)
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var customer = _context.Customers.Single(c => c.Id == Id);

            var viewModel = new CustomerFormViewModel(customer)
            {
                MembershipTypes = membershipTypes
            };

            return View("Form", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel(customer)
                {
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("Form", viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var DbCustomerContext = _context.Customers.Single(c => c.Id == customer.Id);
                DbCustomerContext.Name = customer.Name;
                DbCustomerContext.Birthdate = customer.Birthdate;
                DbCustomerContext.MembershipTypeId = customer.MembershipTypeId;
            }

            _context.SaveChanges();

            return RedirectToAction("Customers", "Customers");
        }

        public ActionResult Delete(int Id)
        {
            var customer = _context.Customers.Single(c => c.Id == Id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("Customers", "Customers");
        }
    }
}
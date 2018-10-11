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

        [Route("Customers/Details/{id:range(1,2)}")]
        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.DatabaseResource;
using Vidly.DTO_s;
using AutoMapper;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private VidlyDbContext _context;

        public CustomersController()
        {
            _context = new VidlyDbContext();
            _context.Configuration.ProxyCreationEnabled = false;
        }

        // GET /api/customers
        public IEnumerable<CustomerDTO> GetCustomers(string query = null)
        {
            var  customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customersDTOS = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDTO>);
            return customersDTOS;
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int Id)
        {
            var customer = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer,CustomerDTO>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDTO);
        }

        // PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int Id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDTO,customerInDb);
            

            _context.SaveChanges();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int Id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}

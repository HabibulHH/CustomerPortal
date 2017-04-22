using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerPortal.Models;

namespace CustomerPortal.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext __context;

        public CustomersController()
        {
            __context = new ApplicationDbContext();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return __context.Customers.ToList();
        }

        public Customer GetCustomerById( int id)
        {
            var customer= __context.Customers.SingleOrDefault(c=>c.Id==id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw  new HttpResponseException(HttpStatusCode.BadRequest);
            }
            return customer;
        }

        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDB = __context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDB == null)
            {
                throw  new HttpResponseException(HttpStatusCode.NotFound);
            }

            customerInDB.Name = customer.Name;
            // do other staff
            __context.SaveChanges();
        }
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDB = __context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            
            __context.Customers.Remove(customerInDB);
            __context.SaveChanges();
        }
    }
}

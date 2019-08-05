using CustomerPhoneAPI.Models.Services;
using CustomerDBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerPhoneAPI.Models;
using System.Web.Http.Description;

namespace CustomerPhoneAPI.Controllers
{
    public class CustomerPhoneController : ApiController
    {
        EmployeePhoneService customerService = new EmployeePhoneService();

        // GET api/CustomerPhone
        public IEnumerable<CustomerDetails> Get()
        {
            return customerService.GetCustomers();
        }

        // GET api/CustomerPhone/5
        public List<CustomerPhone> Get(int id)
        {
            return customerService.GetCustomer(id);
        }

        // POST api/CustomerPhone
        [ResponseType(typeof(CustomerDetails))]
        public IHttpActionResult Post(CustomerPhone custPhone)
        {
            CustomerDetails cust = new CustomerDetails();
            cust = customerService.AddPhoneNumberOfCustomer(custPhone);
            return Ok(cust);
        }

        // PUT api/CustomerPhone/5
        [ResponseType(typeof(CustomerDetails))]
        public IHttpActionResult Put(int id, CustomerPhone custPhone)
        {
            CustomerDetails cust = new CustomerDetails();
            cust = customerService.UpdatePhoneNumberOfCustomer(id, custPhone);
            return Ok(cust);
        }

        // DELETE api/CustomerPhone/5
        [ResponseType(typeof(CustomerDetails))]
        public IHttpActionResult Delete(int id)
        {
            CustomerDetails cust = new CustomerDetails();

            if (id == 0)
                return NotFound();

            cust = customerService.DeletePhoneNumberOfCustomer(id);

            return Ok(cust);
        }
    }
}

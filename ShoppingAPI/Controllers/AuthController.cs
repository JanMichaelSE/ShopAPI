using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Core.Entities;
using ShoppingAPI.Infrastructure.Data;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext context;

        public AuthController(DataContext context)
        {
            this.context = context;
        }

        // GET: api/Auth
        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            var customer = context.Customers.ToList();
            return Ok(customer);
        }

        // GET: api/Auth/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Auth
        [HttpPost]
        public ActionResult Post([FromBody] Customer value)
        {

            if(value == null)
            {
                return BadRequest("Sorry value recieved was null");
            }

            context.Customers.AddAsync(value);

            context.SaveChanges();

            return Ok();
        }

        // PUT: api/Auth/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Customer customer)
        {

            var updatedCustomer = context.Customers.Where(c => c.Id == id).FirstOrDefault();

            if(updatedCustomer.Id != id)
            {
                return BadRequest("No mathcing customer in data base");
            }

            updatedCustomer.FirstName = customer.FirstName;
            updatedCustomer.LastName = customer.LastName;
            updatedCustomer.Email = customer.Email;
            updatedCustomer.ReservedDate = customer.ReservedDate;
            updatedCustomer.Section = customer.Section;
            updatedCustomer.GroupSize = customer.GroupSize;
            updatedCustomer.Comment = customer.Comment;

            // Save  changes in data base
            context.SaveChanges();

            return Ok();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using WebAPIStarterData.Models;
using WebAPIBase.Services;

namespace WebAPIStartTests.Tests
{
    [ApiController]
    //[Route("api/[controller]")]
    public class CustomerController: ControllerBase
    {

        //private List<Customer> customers;
        private ICustomerService customerService;

        
        public CustomerController(ICustomerService customerService){
            this.customerService=customerService;
        
        }

        [HttpGet("api/Customer/{id}")]
        public IActionResult GetOne([FromRoute] long id){
            //foreach (Customer customer in this.customers)
            //{
            //    if (customer.Id==id)
            //    {
            //        return Ok(customer);
            //    }
            //}
            //return new NotFoundObjectResult(new {errorMessage="Could not find resource", errorCode=10});
            var result = this.customerService.GetOne(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet ("api/Customer")]
        public IActionResult GetAll(){
            //return Ok(this.customers);
            return Ok(this.customerService.GetAll());

        }

        [HttpPost ("api/Customer")]
        public IActionResult Create([FromBody] Customer newCustomer){
            //newCustomer.Id = customers.Count +1;
            //if(ModelState.IsValid){
            //        this.customers.Add(newCustomer);
            //    foreach (Customer customer in this.customers)
            //    {
            //        if (customer.Id== newCustomer.Id)
            //        {
            //            return CreatedAtAction("GetOne", new {Id = customer});
            //        }
             //   }
            //    return base.StatusCode(500, new {errorMessage="Could not store value"}); 
            //}
           //else{
            //   return base.ValidationProblem();
           //}
           if(ModelState.IsValid){
                 newCustomer = customerService.Add(newCustomer);
            return CreatedAtAction("GetOne", new{ newCustomer.Id}, newCustomer);
      
           }
           return base.ValidationProblem();
        }

        [HttpPut ("api/Customer/{id}")]
        public IActionResult Update([FromRoute] long id, [FromBody] Customer updatedCustomer){
            //foreach (Customer customer in customers)
            //{
            //    if (customer.Id==updatedCustomer.Id)
            //    {
            //        customer.Firstname=updatedCustomer.Firstname;
            //        customer.LastName=updatedCustomer.LastName;
            //        customer.Email=updatedCustomer.Email;
            //    }
            //}
            //return NoContent();
            customerService.Update(updatedCustomer);
            if(customerService.GetOne(updatedCustomer.Id)!=null){
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete ("api/Customer/{id}")]

        public IActionResult Delete([FromRoute] long id){
            //foreach (Customer customer in customers)
            //{
            //    if (customer.Id==id)
            //    {
            //        customers.Remove(customer);
            //        return StatusCode(410);
            //    }
            //}
            //return NotFound();
            Customer deletedCustomer = customerService.GetOne(id);
            if (deletedCustomer==null)
            {
                return NotFound();
            }
            customerService.Delete(deletedCustomer);
            return StatusCode(410);
        }
    }
}
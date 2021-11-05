using ACA.Models.Customer;
using BusinessLogicLayer.Data;
using InterfacesACA.Interfaces;
using Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService<CustomerClient> service;

        public CustomerController(ICustomerService<CustomerClient> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(service.GetAll());
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            try
            {
                return Ok(service.GetById(Id));
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] CustomerAdd customer)
        {
            try
            {
                service.Create(customer.Map<CustomerClient>());
                return Ok();
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            try
            {

                return Ok(service.Delete(Id));
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }


        }
        
        [HttpPut("{Id}")]
        public IActionResult Put([FromRoute] int Id, [FromBody] CustomerAdd form)
        {
            try
            {
                return Ok(service.Update(Id, form.Map<CustomerClient>()));
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
    }
}

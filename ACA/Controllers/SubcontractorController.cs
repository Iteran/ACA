using ACA.Models.Subcontractor;
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
    public class SubcontractorController : ControllerBase
    {
        private readonly ICRUD<SubcontractorClient, int> service;

        public SubcontractorController(ICRUD<SubcontractorClient, int> service)
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
        public IActionResult Post([FromBody] SubcontractorAdd customer)
        {
            try
            {
                service.Create(customer.Map<SubcontractorClient>());
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
        public IActionResult Put([FromRoute] int Id, [FromBody] SubcontractorAdd form) 
        {
            try
            {
                return Ok(service.Update(Id, form.Map<SubcontractorClient>()));
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }

    
    }
}

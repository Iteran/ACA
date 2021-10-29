using ACA.Models.Manufacturing;
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
    public class ManufacturingController : ControllerBase
    {
        private readonly IManufacturingService<ManufacturingClient> service;

        public ManufacturingController(IManufacturingService<ManufacturingClient>service)
        {
            this.service = service;
        }
        [HttpPost]
        public IActionResult Post(AddManufacturing entity)
        {
            try
            {
                service.Create(entity.Map<ManufacturingClient>());
                return Ok();
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(service.GetAll());
            }
            catch (Exception e )
            {

                return Problem(e.Message);
            }
        }
        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute]int Id)
        {
            try
            {
                ManufacturingClient entity = service.GetById(Id).Map<ManufacturingClient>();
                if (entity.Id != 0) return Ok(entity);
                else return BadRequest();
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute]int Id, [FromBody]AddManufacturing body)
        {
            try
            {
                ManufacturingClient m = service.Update(Id, body.Map<ManufacturingClient>()).Map<ManufacturingClient>();
                if (m.Id != 0) return Ok(m);
                else return BadRequest();
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
        [HttpPatch("{Id}")]
        public IActionResult UpdateStatus([FromRoute]int Id,[FromBody]UpdateStatus NewStatus)
        {
            try
            {
                ManufacturingClient m = service.UpdateStatus(Id, NewStatus.NewStatus).Map<ManufacturingClient>();
                if (m.Id != 0) return Ok(m);
                else return BadRequest();
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
                if (service.Delete(Id)) return Ok();
                else return BadRequest();
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
    }
}

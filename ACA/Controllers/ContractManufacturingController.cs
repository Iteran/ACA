using ACA.DTO.ContactManufacturing;
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
    public class ContractManufacturingController : ControllerBase
    {
        private readonly ICRUD<ContractManufacturingClient, int> service;

        public ContractManufacturingController(ICRUD<ContractManufacturingClient,int>service)
        {
            this.service = service;
        }
        [HttpPost]
        public IActionResult Post(AddContractManufacturing entity)
        {
            try
            {
                service.Create(entity.Map<ContractManufacturingClient>());
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
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute]int Id)
        {
            try
            {
                ContractManufacturingDTO Cm = service.GetById(Id).Map<ContractManufacturingDTO>();
                if (Cm.Id != 0) return Ok(Cm);
                else return BadRequest();
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute]int Id,[FromBody]AddContractManufacturing entity)
        {
            try
            {
                ContractManufacturingDTO cm = service.Update(Id,entity.Map<ContractManufacturingClient>()).Map<ContractManufacturingDTO>();
                if (cm.Id != 0) return Ok(cm);
                else return BadRequest();
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute]int Id)
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

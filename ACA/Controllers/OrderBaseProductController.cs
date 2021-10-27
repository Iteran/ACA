using ACA.DTO.OrderBaseProduct;
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
    public class OrderBaseProductController : ControllerBase
    {
        private readonly ICRUD<OrderBaseProductClient, int> service;

        public OrderBaseProductController(ICRUD<OrderBaseProductClient,int> service)
        {
            this.service = service;
        }
        [HttpPost]
        public IActionResult Post([FromBody]OrderBaseProductAdd body)
        {
            try
            {
                service.Create(body.Map<OrderBaseProductClient>());
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
                OrderBaseProductDTO order = service.GetById(Id).Map<OrderBaseProductDTO>();
                if ( order.Id != 0)
                {
                    return Ok(order);
                }
                else
                {
                    return BadRequest();
                }
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
            catch (Exception e )
            {

                return Problem(e.Message);
            }
        }
    }
}

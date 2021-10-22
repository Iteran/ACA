using ACA.DTO.Order;
using BusinessLogicLayer.Data;
using BusinessLogicLayer.Services;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService<OrderClient> _orderServiceBL;
        public OrderController(IOrderService<OrderClient> service)
        {
            _orderServiceBL = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_orderServiceBL.GetAll());
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
                return Ok(_orderServiceBL.GetById(Id));
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody]OrderDTO order)
        {
            try
            {
                _orderServiceBL.Create(order.Map<OrderClient>());
                return Ok();
            }
            catch (Exception e )
            {

                return Problem(e.Message);
            }
        }
        [HttpDelete("{Id")]
        public IActionResult Delete([FromRoute]int Id)
        {
            try
            {

                return Ok(_orderServiceBL.Delete(Id));
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
            

        }
        
    }
}

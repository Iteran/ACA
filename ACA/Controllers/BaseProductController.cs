using ACA.Models.BaseProduct;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mappers;

using BusinessLogicLayer.Data;
using InterfacesACA.Interfaces;

namespace ACA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseProductController : ControllerBase
    {
        private readonly IBaseProductService<BaseProductClient>  _baseProductService;
        public BaseProductController(IBaseProductService<BaseProductClient> service)
        {
            _baseProductService = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_baseProductService.GetAll());
        }
        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute]int Id)
        {
            return Ok(_baseProductService.GetById(Id));
        }
        [HttpPost]
        public IActionResult Post([FromBody]AddBaseProduct product)
        {
            try
            {
                _baseProductService.Create(product.Map<BaseProductClient>());
                return Ok();

            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            
            
        }
        [HttpPut("{Id}")]
        public IActionResult Put([FromRoute] int Id, [FromBody] BaseProductClient ModifiedProduct)
        {
            return Ok(_baseProductService.Update(Id, ModifiedProduct));
        }
        [HttpPatch("Add/{Id}")]
        public IActionResult AddQuantity([FromRoute] int Id, int QuantityAdd)
        {
            _baseProductService.AddQuantity(Id, QuantityAdd);
            return Ok();
        }
        [HttpPatch("Delete/{Id}")]
        
        public IActionResult DeleteQuantity([FromRoute]int Id, int QuantityDel)
        {
            _baseProductService.DeleteQuantity(Id, QuantityDel);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            _baseProductService.Delete(Id);
            return Ok();
        }
    }
}

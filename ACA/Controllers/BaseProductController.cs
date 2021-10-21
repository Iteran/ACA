using ACA.DTO.BaseProduct;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mappers;

using BusinessLogicLayer.Data;

namespace ACA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseProductController : ControllerBase
    {
        private readonly BaseProductServiceBL _baseProductService;
        public BaseProductController(BaseProductServiceBL service)
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
        public IActionResult Post([FromBody]BaseProductDTO product)
        {
            try
            {
                _baseProductService.AddProduct(product.Map<BaseProductClient>());
                return Ok();

            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            
            
        }
        [HttpPut("{Id}")]
        public IActionResult Put([FromRoute] int Id, [FromBody] BaseProductDTO ModifiedProduct)
        {
            return Ok(_baseProductService.Update(Id, ModifiedProduct.Map<BaseProductClient>()));
        }
        [HttpPatch("{Id}")]
        public IActionResult Patch([FromRoute] int Id, int QuantityAdd)
        {
            _baseProductService.AddQuantity(Id, QuantityAdd);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            _baseProductService.DeleteProduct(Id);
            return Ok();
        }
    }
}

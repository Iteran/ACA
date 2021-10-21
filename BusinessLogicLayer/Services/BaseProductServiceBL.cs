using BusinessLogicLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Services;
using Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class BaseProductServiceBL
    {
        private readonly BaseProductService _baseProductService;

        public BaseProductServiceBL(BaseProductService service)
        {
            _baseProductService = service;
        }
        public void AddProduct(BaseProductClient product)
        {
            _baseProductService.AddBaseProduct(product.Map<BaseProduct>());
        }
        public bool DeleteProduct(int Id)
        {
            return _baseProductService.DeleteProduct(Id);
        }
        public IEnumerable<BaseProduct> GetAll()
        {
            return _baseProductService.GetAll();
        }
        public BaseProduct GetById(int Id)
        {
            return _baseProductService.GetById(Id);

        }
        public bool Update(int Id,BaseProductClient product)
        {
            return _baseProductService.Update(Id, product.Map<BaseProduct>());
        }
        public void AddQuantity(int Id,int value)
        {
            _baseProductService.AddQuantity(Id, value);
        }
    }
}

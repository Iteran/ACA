using BusinessLogicLayer.Data;
using DataAccessLayer.Entities;

using InterfacesACA.Interfaces;
using Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class BaseProductServiceBL : IBaseProductService<BaseProductClient>
    {
        private readonly IBaseProductService<BaseProduct> _baseProductService;

        public BaseProductServiceBL(IBaseProductService<BaseProduct> service)
        {
            _baseProductService = service;
        }
        public void Create(BaseProductClient product)
        {
            _baseProductService.Create(product.Map<BaseProduct>());
        }
        public bool Delete(int Id)
        {
            return _baseProductService.Delete(Id);
        }
        public IEnumerable<BaseProductClient> GetAll()
        {
            return _baseProductService.GetAll().Select( c => c.Map<BaseProductClient>());
        }
        public BaseProductClient GetById(int Id)
        {
            return _baseProductService.GetById(Id).Map<BaseProductClient>();

        }
        public BaseProductClient Update(int Id,BaseProductClient product)
        {
            return _baseProductService.Update(Id, product.Map<BaseProduct>()).Map<BaseProductClient>();
        }
        public void AddQuantity(int Id,int value)
        {
            _baseProductService.AddQuantity(Id, value);
        }
        public void DeleteQuantity(int Id, int value)
        {
            _baseProductService.DeleteQuantity(Id, value);
        }
    }
}

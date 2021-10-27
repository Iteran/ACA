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
    public class OrderBaseProductServiceBL : ICRUD<OrderBaseProductClient, int>
    {
        private readonly ICRUD<OrderBaseProduct, int> service;

        public OrderBaseProductServiceBL(ICRUD<OrderBaseProduct,int>service)
        {
            this.service = service;
        }
        public void Create(OrderBaseProductClient Entity)
        {
            service.Create(Entity.Map<OrderBaseProduct>());
        }

        public bool Delete(int Id)
        {
            return service.Delete(Id);
        }

        public IEnumerable<OrderBaseProductClient> GetAll()
        {
            return service.GetAll().Select(o => o.Map<OrderBaseProductClient>());
        }

        public OrderBaseProductClient GetById(int Id)
        {
            return service.GetById(Id).Map<OrderBaseProductClient>();
        }

        public OrderBaseProductClient Update(int Id, OrderBaseProductClient Entity)
        {
            throw new NotImplementedException();
        }
    }
}

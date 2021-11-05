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
    public class CustomerServiceBL : ICustomerService<CustomerClient>
    {
        private readonly ICustomerService<Customers> service;

        public CustomerServiceBL(ICustomerService<Customers> service)
        {
            this.service = service;
        }
        

        public void Create(CustomerClient Entity)
        {
            service.Create(Entity.Map<Customers>());
        }

        public bool Delete(int Id)
        {
            return service.Delete(Id);
        }

        public IEnumerable<CustomerClient> GetAll()
        {
            return service.GetAll().Select(c => c.Map<CustomerClient>());
        }

        public CustomerClient GetById(int Id)
        {
            return service.GetById(Id).Map<CustomerClient>();
        }

        public CustomerClient Update(int Id, CustomerClient Entity)
        {
            return service.Update(Id, Entity.Map<Customers>()).Map<CustomerClient>();
        }
    }
}

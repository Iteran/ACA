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
    public class ContractManufacturingServiceBL : ICRUD<ContractManufacturingClient, int>
    {
        private readonly ICRUD<ContractManufacturing, int> service;

        public ContractManufacturingServiceBL(ICRUD<ContractManufacturing,int>service)
        {
            this.service = service;
        }
        public void Create(ContractManufacturingClient Entity)
        {
            service.Create(Entity.Map<ContractManufacturing>());
        }

        public bool Delete(int Id)
        {
            return service.Delete(Id);
        }

        public IEnumerable<ContractManufacturingClient> GetAll()
        {
            return service.GetAll().Select(cm => cm.Map<ContractManufacturingClient>());
        }

        public ContractManufacturingClient GetById(int Id)
        {
            return service.GetById(Id).Map<ContractManufacturingClient>();
        }

        public ContractManufacturingClient Update(int Id, ContractManufacturingClient Entity)
        {
            return service.Update(Id, Entity.Map<ContractManufacturing>()).Map<ContractManufacturingClient>();
        }
    }
}

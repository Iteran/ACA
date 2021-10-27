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
    public class ManufacturingServiceBL : IManufacturingService<ManufacturingClient>
    {
        private readonly IManufacturingService<Manufacturing> service;

        public ManufacturingServiceBL(IManufacturingService<Manufacturing>_service)
        {
            service = _service;
        }
        public void Create(ManufacturingClient Entity)
        {
            service.Create(Entity.Map<Manufacturing>());
        }

        public bool Delete(int Id)
        {
            return service.Delete(Id);
        }

        public IEnumerable<ManufacturingClient> GetAll()
        {
            return service.GetAll().Select(m => m.Map<ManufacturingClient>());
        }

        public ManufacturingClient GetById(int Id)
        {
            return service.GetById(Id).Map<ManufacturingClient>();
        }

        public ManufacturingClient Update(int Id, ManufacturingClient Entity)
        {
            return service.Update(Id, Entity.Map<Manufacturing>()).Map<ManufacturingClient>();
        }

        public ManufacturingClient UpdateStatus(int Id, string status)
        {
            return service.UpdateStatus(Id, status).Map<ManufacturingClient>();
        }
    }
}

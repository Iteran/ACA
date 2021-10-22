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
    public class SubcontractorServiceBL : ICRUD<SubcontractorClient, int>
    {
        private readonly ICRUD<Subcontractors, int> service;

        public SubcontractorServiceBL(ICRUD<Subcontractors,int> service)
        {
            this.service = service;
        }
        public void Create(SubcontractorClient Entity)
        {
            service.Create(Entity.Map<Subcontractors>());
        }

        public bool Delete(int Id)
        {
            return service.Delete(Id);
        }

        public IEnumerable<SubcontractorClient> GetAll()
        {
            return service.GetAll().Select(c => c.Map<SubcontractorClient>());
        }

        public SubcontractorClient GetById(int Id)
        {
            return service.GetById(Id).Map<SubcontractorClient>();
        }

        public SubcontractorClient Update(int Id, SubcontractorClient Entity)
        {
            return service.Update(Id, Entity.Map<Subcontractors>()).Map<SubcontractorClient>();
        }
    }
}

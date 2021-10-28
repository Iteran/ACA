using ADOLibrary;
using DataAccessLayer.Entities;
using InterfacesACA.Interfaces;
using Mappers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class ContractManufacturingService : ICRUD<ContractManufacturing, int>
    {
        private readonly Connection _co;
        public ContractManufacturingService(IConfiguration config)
        {
            _co = new(SqlClientFactory.Instance, config.GetConnectionString("Default"));
        }
        private ContractManufacturing Convert(IDataRecord reader)
        {
            return reader.MapReader<ContractManufacturing>();
        }
        public void Create(ContractManufacturing Entity)
        {
            Command cmd = new("InsertContractManufacturing",true);
            cmd.MapToCommand(Entity);
            _co.ExecuteNonQuery(cmd);
        }

        public bool Delete(int Id)
        {
            Command cmd = new("Delete From ContractManufacturing where Id = @Id");
            cmd.AddParameter("@Id", Id);
            return _co.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<ContractManufacturing> GetAll()
        {
            Command cmd = new("Select * from ContractManufacturing");
            return _co.ExecuteReader<ContractManufacturing>(cmd, Convert);
        }

        public ContractManufacturing GetById(int Id)
        {
            Command cmd = new("Select * from ContractManufacturing where Id = @Id");
            cmd.AddParameter("@Id", Id);
            return _co.ExecuteReader<ContractManufacturing>(cmd, Convert).FirstOrDefault();
        }

        public ContractManufacturing Update(int Id, ContractManufacturing Entity)
        {
            Command cmd = new("UpdateContractManufacturing", true);
            cmd.MapToCommand(Entity);
            cmd.AddParameter("@Id", Id);
            _co.ExecuteNonQuery(cmd);
            return GetById(Id);
        }
    }
}

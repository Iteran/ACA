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
    public class ManufacturingService : IManufacturingService<Manufacturing>
    {
        private readonly Connection _co;
        public ManufacturingService(IConfiguration config)
        {
            _co = new(SqlClientFactory.Instance, config.GetConnectionString("Default"));
        }
        private Manufacturing Convert(IDataRecord reader)
        {
            return reader.MapReader<Manufacturing>();
        }
        

    
        public void Create(Manufacturing Entity)
        {
            Command cmd = new("InsertManufacturing", true);
            cmd.MapToCommand(Entity);
            _co.ExecuteNonQuery(cmd);
        }

        public bool Delete(int Id)
        {
            Command cmd = new("Delete FROM Manufacturing where Id = @Id");
            cmd.AddParameter("@Id", Id);
            return _co.ExecuteNonQuery(cmd) == 1; 
        }

        public IEnumerable<Manufacturing> GetAll()
        {
            Command cmd = new("Select * from Manufacturing");
            return _co.ExecuteReader<Manufacturing>(cmd, Convert);
        }

        public Manufacturing GetById(int Id)
        {
            Command cmd = new("Select * from Manufacturing where Id = @Id");
            cmd.AddParameter("@Id", Id);
            return _co.ExecuteReader<Manufacturing>(cmd,Convert).FirstOrDefault(); 
        }

        public Manufacturing Update(int Id, Manufacturing Entity)
        {
            Command cmd = new("UpdateManufacturing", true);
            cmd.MapToCommand(Entity);
            cmd.AddParameter("@Id", Id);
            _co.ExecuteNonQuery(cmd);
            return GetById(Id);
        }

        public Manufacturing UpdateStatus(int Id,string status)
        {
            Command cmd = new("Update Manufacturing set Status = @status where Id = @Id");
            cmd.AddParameter("@Id", Id);
            cmd.AddParameter("@status", status);
            _co.ExecuteNonQuery(cmd);
            return GetById(Id);

        }
    }
}

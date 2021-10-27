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
    public class OrderBaseProductService : ICRUD<OrderBaseProduct, int>
    {
        private readonly Connection _co;
        public OrderBaseProductService(IConfiguration config)
        {
            _co = new(SqlClientFactory.Instance, config.GetConnectionString("Default"));
        }
        private OrderBaseProduct Convert(IDataRecord reader) {
            return reader.MapReader<OrderBaseProduct>();
        }
        public void Create(OrderBaseProduct Entity)
        {
            Command cmd = new("InsertOrderBaseProduct", true);
            cmd.MapToCommand(Entity);
            _co.ExecuteNonQuery(cmd);
            
        }

        public bool Delete(int Id)
        {
            Command cmd = new("Delete from OrderBaseProduct where Id = @Id");
            cmd.AddParameter("@Id", Id);
            return _co.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<OrderBaseProduct> GetAll()
        {
            Command cmd = new("Select * from OrderBaseProduct");
            return _co.ExecuteReader<OrderBaseProduct>(cmd, Convert);
        }

        public OrderBaseProduct GetById(int Id)
        {
            Command cmd = new("select * from OrderBaseProduct where Id = @Id");
            cmd.AddParameter("@Id", Id);
            OrderBaseProduct o = _co.ExecuteReader<OrderBaseProduct>(cmd, Convert).FirstOrDefault();
            return o;
        }

        public OrderBaseProduct Update(int Id, OrderBaseProduct Entity)
        {
            throw new NotImplementedException();
        }
    }
}

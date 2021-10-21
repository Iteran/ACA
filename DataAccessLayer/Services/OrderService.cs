using DataAccessLayer.Entities;
using Mappers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADOLibrary;
using System.Transactions;

namespace DataAccessLayer.Services
{
    public class OrderService
    {
        private Connection _co { get; set; }
        public OrderService(IConfiguration config)
        {
            _co = new Connection(SqlClientFactory.Instance, config.GetConnectionString("Default"));
        }
        private Order Convert(IDataRecord reader)
        {
            return reader.MapReader<Order>();
        }
        public IEnumerable<Order> GetAll()
        {
            Command cmd = new("select * from Orders");
            return _co.ExecuteReader<Order>(cmd, Convert);
        }
        public Order GetById(int Id)
        {
            Command cmd = new("select * from Orders where @id = Id");
            cmd.AddParameter("@id", Id);
            return _co.ExecuteReader<Order>(cmd, Convert).FirstOrDefault();
        }
        public void AddOrder(Order order)
        {
            using(TransactionScope scope = new())
            {
                try
                {
                    Command cmd = new("InserOrder", true);
                    cmd.MapToCommand(order);
                    _co.ExecuteNonQuery(cmd);
                    scope.Complete();
                }


                catch (Exception)
                {

                    throw;
                }

            }
        }
        public bool DeleteOrder(int Id)
        {
            Command cmd = new Command("Delete from Orders where Id = @id");
            cmd.AddParameter("@id", Id);
            using (TransactionScope scope = new())
            {

                try
                {

                    _co.ExecuteNonQuery(cmd);
                    scope.Complete();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                    throw;
                }
            }
        }
        public bool Paid(int Id, Order order)
        {
            Order test = GetById(Id);
            if (test == null) return false;
            Command cmd = new Command("Update Orders set IsPaid = 1 where Id = @id");
            cmd.AddParameter("@id", Id);
            _co.ExecuteNonQuery(cmd);
            return true;
        }

    }
}

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
using System.Transactions;

namespace DataAccessLayer.Services
{
    public class CustomerService : ICustomerService<Customers>
    {
        private readonly Connection _co;
        public CustomerService(IConfiguration config)
        {
            _co = new(SqlClientFactory.Instance, config.GetConnectionString("Default"));
        }

        public bool Binding(int IdCustomer, int IdUser)
        {
            Command cmd = new("BindCustomer", true);
            cmd.AddParameter("@customerId", IdCustomer);
            cmd.AddParameter("@userId", IdUser);
            return _co.ExecuteNonQuery(cmd) == 1;
        }

        public Customers Convert(IDataRecord reader)
        {
            return reader.MapReader<Customers>();
        }
        public void Create(Customers Entity)
        {
            Command cmd = new Command("InsertCustomer", true);
            cmd.MapToCommand(Entity);
            _co.ExecuteNonQuery(cmd);
        }

        public bool Delete(int Id)
        {
            
            Command cmd = new("Delete FROM Customers where Id = @Id");
            using (TransactionScope scope = new())
            {
                try
                {

                    cmd.AddParameter("@Id", Id);
                    _co.ExecuteNonQuery(cmd);
                    scope.Complete();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    
                }

            }

        }

        public IEnumerable<Customers> GetAll()
        {
            Command cmd = new("select * from Customers");
            return _co.ExecuteReader<Customers>(cmd, Convert);
        }

        public Customers GetById(int Id)
        {
            Command cmd = new("select * from Customers where Id = @id");
            cmd.AddParameter("@Id", Id);
            return _co.ExecuteReader<Customers>(cmd, Convert).FirstOrDefault();
        }

        public Customers Update(int Id, Customers Entity)
        {
            using (TransactionScope scope = new())
            {
                try
                {
                    Command cmd = new Command("UpdateCustomer",true);
                    cmd.MapToCommand(Entity);
                    cmd.AddParameter("@Id", Id);
                    _co.ExecuteNonQuery(cmd);
                    scope.Complete();
                    return GetById(Id);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}

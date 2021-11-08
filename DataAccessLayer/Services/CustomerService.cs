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

       

        public Customers Convert(IDataRecord reader)
        {
            return reader.MapReader<Customers>();
        }
        public int Create(Customers Entity)
        {
            Command cmd = new Command("InsertCustomer", true);
            cmd.MapToCommand(Entity);
            return (int)_co.ExecuteScalar(cmd);
            
        }

       

        public bool Delete(int Id)
        {
            
            Command cmd = new("DeleteCustomer",true);
            
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
                    Customers result = GetById(Id);
                    scope.Complete();
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        void ICRUD<Customers, int>.Create(Customers Entity)
        {
            throw new NotImplementedException();
        }
    }
}

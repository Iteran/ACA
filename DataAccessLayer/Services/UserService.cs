using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesACA.Interfaces;
using ADOLibrary;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Mappers;
using System.Transactions;

namespace DataAccessLayer.Services
{
    public class UserService : IUserService<Users>
    {
        private readonly Connection _co;
        public UserService(IConfiguration config)
        {
            _co = new(SqlClientFactory.Instance, config.GetConnectionString("Default"));
        }
        public Users Convert(IDataRecord reader) 
        {
            return reader.MapReader<Users>();
        }
        public void Create(Users Entity)
        {
            using (TransactionScope scope = new())
            {
                try
                {
                    Command cmd = new("InserUser", true);
                    cmd.MapToCommand(Entity);
                    _co.ExecuteNonQuery(cmd);
                    scope.Complete();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Delete(int Id)
        {
            using (TransactionScope scope = new())
            {

                try
                {
                    Command cmd = new("Delete FROM Users where Id = @Id");
                    cmd.AddParameter("@Id", Id);
                    return _co.ExecuteNonQuery(cmd) == 1;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public IEnumerable<Users> GetAll()
        {
            Command cmd = new("Select Email from Users");
            return _co.ExecuteReader<Users>(cmd, Convert);
        }

        public Users GetById(int Id)
        {
            Command cmd = new("select * from Users where Id = @Id");
            cmd.AddParameter("@Id", Id);
            return _co.ExecuteReader<Users>(cmd, Convert).FirstOrDefault();
        }

        public bool ModifyPassword(int Id, string NewPwd)
        {
            Command cmd = new("UpdatePassword", true);
            cmd.AddParameter("@Id", Id);
            cmd.AddParameter("@newPwd", NewPwd);
            return _co.ExecuteNonQuery(cmd) == 1;
        }

        public Users Update(int Id, Users Entity)
        {
            Command cmd = new("UpdateUser", true);
            cmd.MapToCommand(Entity);
            cmd.AddParameter("@id", Id);
            _co.ExecuteNonQuery(cmd);
            return GetById(Id);
        }
    }
}

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
                    Command cmd = new("InsertUser", true);
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
                    int rep = _co.ExecuteNonQuery(cmd);
                    scope.Complete();
                    return rep == 1;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public IEnumerable<Users> GetAll()
        {
            Command cmd = new("Select * from V_Users");
            return _co.ExecuteReader<Users>(cmd, Convert);
        }

        public Users GetById(int Id)
        {
            Command cmd = new("select * from V_Users where Id = @Id");
            cmd.AddParameter("@Id", Id);
            return _co.ExecuteReader<Users>(cmd, Convert).FirstOrDefault();
        }

        public Users Login(string email, string password)
        {
            Command cmd = new("LoginUser", true);
            cmd.AddParameter("@email", email);
            cmd.AddParameter("@password", password);
            
            try
            {
                Users u = _co.ExecuteReader<Users>(cmd, Convert).FirstOrDefault();

                return u;
            }
            catch (Exception)
            {

                return null;
            }
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


            cmd.AddParameter("@email", Entity.Email);
            cmd.AddParameter("@id", Id);
            _co.ExecuteNonQuery(cmd);
            return GetById(Id);
        }
    }
}

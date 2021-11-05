using BusinessLogicLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Services;
using InterfacesACA.Interfaces;
using Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class UserServiceBL : IUserService<UserClient>
    {
        private readonly IUserService<Users> service;

        public UserServiceBL(IUserService<Users> service)
        {
            this.service = service;
        }
        public bool Binding(int IdCustomer, int IdUser)
        {
            return service.Binding(IdCustomer, IdUser);
        }
        public void Create(UserClient Entity)
        {
            service.Create(Entity.Map<Users>());
        }

        public bool Delete(int Id)
        {
            return service.Delete(Id);
        }

        public IEnumerable<UserClient> GetAll()
        {
            return service.GetAll().Select(u => u.Map<UserClient>());
        }

        public UserClient GetById(int Id)
        {
            return service.GetById(Id).Map<UserClient>();
        }

        public UserClient Login(string email, string password)
        {
            return service.Login(email, password).Map<UserClient>();
        }

        public bool ModifyPassword(int Id, string NewPwd)
        {
            return service.ModifyPassword(Id, NewPwd);
        }

        public UserClient Update(int Id, UserClient Entity)
        {
            return service.Update(Id, Entity.Map<Users>()).Map<UserClient>();
        }
    }
}

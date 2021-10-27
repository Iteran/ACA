using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesACA.Interfaces
{
    public interface IUserService<T> : ICRUD<T,int>
    {
        public bool ModifyPassword(int Id, string NewPwd);
        public T Login(string email, string password);
    }
}

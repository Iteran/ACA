using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesACA.Interfaces
{
    public interface ICustomerService<T> : ICRUD<T,int>
    {
        public int Create(T entity);
    }
}

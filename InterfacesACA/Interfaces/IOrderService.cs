using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesACA.Interfaces
{
    public interface IOrderService<T> :ICRUD<T,int>
    {
        public bool Paid(int Id, T order);
       
    }
}

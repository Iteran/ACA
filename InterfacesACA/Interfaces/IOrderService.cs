using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesACA.Interfaces
{
    public interface IOrderService<T,TT> :ICRUD<T,int>
    {
        public bool Paid(int Id);
        public IEnumerable<TT> GetDetails(int orderId);


    }
}

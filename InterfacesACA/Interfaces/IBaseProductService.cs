
using System.Collections.Generic;

namespace InterfacesACA.Interfaces
{
    public interface IBaseProductService<T> : ICRUD<T,int>
    {
        void AddQuantity(int Id, int value);
       
    }
}
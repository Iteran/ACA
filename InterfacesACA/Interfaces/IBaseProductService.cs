
using System.Collections.Generic;

namespace InterfacesACA.Interfaces
{
    public interface IBaseProductService<T,TT> : ICRUD<T,int>
    {
        void AddQuantity(int Id, int value);
        public void DeleteQuantity(int Id, int value);
        public TT GetPrice(int Id);
        public TT InsertPrice(int Id, TT product);
        public IEnumerable<TT> GetAllPrice();
    }
}
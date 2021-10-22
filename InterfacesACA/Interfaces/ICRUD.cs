using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesACA.Interfaces
{
    public interface ICRUD<TEntity,TId>
    {
        public void Create(TEntity Entity);
        public IEnumerable<TEntity> GetAll();
        public TEntity GetById(TId Id);
        public TEntity Update(TId Id, TEntity Entity);
        public bool Delete(TId Id);


    }
}

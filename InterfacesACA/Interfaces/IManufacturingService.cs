using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesACA.Interfaces
{
    public interface IManufacturingService<TEntity> : ICRUD<TEntity,int>
    {
        public TEntity UpdateStatus(int Id,string status);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class ComponenEndProduct
    {
        public int Id { get; set; }
        public int BaseProductId { get; set; }
        public int EndProductId { get; set; }
        public int QuantityBaseProduct { get; set; }

    }
}

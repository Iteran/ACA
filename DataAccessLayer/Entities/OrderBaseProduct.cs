using Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class OrderBaseProduct
    {
        [MapIgnore]
        public int Id { get; set; }
        public int BaseProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }

    }
}

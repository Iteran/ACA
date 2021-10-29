using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Data
{
    public class OrderDetailsClient
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public decimal PriceProduct { get; set; }
    }
}

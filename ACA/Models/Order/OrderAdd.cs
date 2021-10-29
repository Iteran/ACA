using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACA.Models.Order
{
    public class OrderAdd
    {
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
        public bool IsPaid { get; set; }
    }
}

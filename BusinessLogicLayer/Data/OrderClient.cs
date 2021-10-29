using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Data
{
    public class OrderClient
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<OrderDetailsClient> orderDetails { get; set; }
        public decimal total { get { return orderDetails?.Select(o => o.PriceProduct * o.Quantity).Sum() ?? 0; } }
        public bool IsPaid { get; set; }
    }
}

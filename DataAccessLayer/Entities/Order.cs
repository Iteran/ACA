using Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Order
    {
        [MapIgnore]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
       
        public bool IsPaid { get; set; }
    }
}

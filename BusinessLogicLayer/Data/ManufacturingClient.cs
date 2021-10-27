using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Data
{
    public class ManufacturingClient
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DeadLine { get; set; }
        public decimal Total { get; set; }
        public decimal DownPayment { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; }
    }
}

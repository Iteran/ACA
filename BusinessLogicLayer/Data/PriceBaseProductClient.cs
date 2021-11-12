using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Data
{
    public class PriceBaseProductClient
    {
        public int Id { get; set; }
        public decimal PriceProduct { get; set; }
        public int BaseProductId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

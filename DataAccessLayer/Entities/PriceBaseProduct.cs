using Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class PriceBaseProduct
    {
        [MapIgnore]
        public int Id { get; set; }
        public decimal PriceProduct { get; set; }
        [MapIgnore]
        public int BaseProductId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? EndDate { get; set; }

    }
}

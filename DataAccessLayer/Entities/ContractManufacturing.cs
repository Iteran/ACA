using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class ContractManufacturing
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ManufacturingId { get; set; }
        public int SubcontractorId { get; set; }
        public decimal SubcontractorCut { get; set; }
    }
}

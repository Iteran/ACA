using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACA.DTO.ContactManufacturing
{
    public class AddContractManufacturing
    {
        public DateTime Date { get; set; }
        public int ManufacturingId { get; set; }
        public int SubcontractorId { get; set; }
        public decimal SubcontractorCut { get; set; }
    }
}

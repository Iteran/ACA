using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACA.Models.BaseProduct
{
    public class PriceProductAdd
    {
        public decimal PriceProduct { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
    }
}

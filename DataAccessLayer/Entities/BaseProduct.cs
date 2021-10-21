﻿using Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class BaseProduct
    {
        [MapIgnore]
        public int Id { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

    }
}

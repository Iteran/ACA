﻿using Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Customers
    {
        [MapIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string BusinessName { get; set; }
        public string PhoneNumber { get; set; }
      

    }
}

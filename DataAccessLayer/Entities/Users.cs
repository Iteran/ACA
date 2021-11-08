using Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Users
    {
        [MapIgnore]
        public int Id { get; set; }
        [MapIgnore]

        public bool IsAdmin { get; set; }
        [ReadIgnore]
        public string Password { get; set; }
        public string Email { get; set; }
        [MapIgnore]
        public int? CustomerId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAPI.Core.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime ReservedDate { get; set; }
        public int Section { get; set; }
        public int GroupSize { get; set; }
        public string Comment { get; set; }

    }
}

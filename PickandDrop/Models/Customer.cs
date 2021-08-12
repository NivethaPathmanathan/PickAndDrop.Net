using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickandDrop.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Email { get; set; }

        public Char Complaint { get; set; }

        public String Status { get; set; }
    }
}

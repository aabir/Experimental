using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostGreBE.Entity
{
    public class Patient
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public float Age { get; set; }
        public string Gender { get; set; }
    }
}

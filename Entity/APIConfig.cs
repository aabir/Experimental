using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostGreBE.Entity
{
    public class APIConfig
    {
        public string QAURL { get; set; }
        public string PreProdURL { get; set; }
        public string ProdURL { get; set; }
        public string Token { get; set; }
    }
}

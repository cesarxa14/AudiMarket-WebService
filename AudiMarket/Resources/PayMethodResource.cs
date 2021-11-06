using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Resources
{
    public class PayMethodResource
    {
        public int IdPayMethod { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Voucher Voucher { get; set; }
    }
}

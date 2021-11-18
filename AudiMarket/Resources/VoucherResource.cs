using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Resources
{
    public class VoucherResource
    {

        public int IdVoucher { get; set; }
        public DateTime CreateDate { get; set; }
        public int IdPaymethod { get; set; }
        public int IdContract { get; set; }
    }
}

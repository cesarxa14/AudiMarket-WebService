using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Models
{
    public class PayMethod
    {
        public int IdPayMethod { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Relationships
        public int VoucherId { get; set; }
        public Voucher Voucher { get; set; }
    }
}
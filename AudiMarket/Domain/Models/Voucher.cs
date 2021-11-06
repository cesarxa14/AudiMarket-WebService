using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Models
{
    public class Voucher
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int IdPayMethod { get; set; }
        public int IdContract { get; set; }

        //Relationships
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AudiMarket.Domain.Models
{
    public partial class Vouchers
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int IdPaymethod { get; set; }
        public int IdContract { get; set; }

        //Relationships
        public int ContractId { get; set; }
        public ContractId ContractId { get; set; }
    }
}
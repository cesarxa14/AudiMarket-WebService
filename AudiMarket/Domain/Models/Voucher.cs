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

        public int PayMethodId { get; set; }

        //Relationships

        public int ContractId { get; set; }

        public Contracts Contracts { get; set; }

    }
}
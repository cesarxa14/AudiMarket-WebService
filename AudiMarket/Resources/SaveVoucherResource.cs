using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Resources
{
    public class SaveVoucherResource
    {

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public int PayMethodId { get; set; }

        [Required]
        public int ContractId { get; set; }

    }
}
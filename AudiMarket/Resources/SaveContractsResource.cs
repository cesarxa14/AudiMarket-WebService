using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Resources
{
    public class SaveContractsResource
    {
        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        [Required]
        public int videoProducerId { get; set; }

        [Required]
        public int musicProducerId { get; set; }
    }
}
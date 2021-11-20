using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Resources
{
    public class SaveVideoProducerResource
    {
        [Required]
        [MaxLength(50)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }

        [Required]
        [MaxLength(8)]
        public string Dni { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string User { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        
    }
}
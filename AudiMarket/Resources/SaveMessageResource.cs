using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Resources
{
    public class SaveMessageResource
    {
        [Required]
        [MaxLength(50)]
        public string Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        [Required]
        [MaxLength(20)]
        public DateTime CreateDate { get; set; }
        
        
        [Required]
        [MaxLength(7)]
        public int IdvProducer { get; set; }
        [Required]
        [MaxLength(7)]
        public int DmProducer { get; set; }

        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Resources
{
    public class SavePlayListResource
    {
        
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public DateTime AddedDate { get; set; }
        
        
        [Required]
        public int MusicProducerId { get; set; }
        
    }
}

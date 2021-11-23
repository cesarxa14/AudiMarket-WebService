using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Resources
{
    public class SaveReviewResource
    {
        [Required]
        public int MusicProducerId { get; set; }
        
        [Required]
        public int VideoProducerId { get; set; }
        
        [Required]
        public double Qualification { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }
        
    }
}
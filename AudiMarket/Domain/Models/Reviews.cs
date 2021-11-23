using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Models
{
    public class Review
    {
        public int Id { get; set; }
        public double Qualification { get; set; }
        public string Description { get; set; }
        public DateTime ReviewDate { get; set; }

        //Relationships
        public int MusicProducerId { get; set; }
        public MusicProducer MusicProducer { get; set; }
        
        public int VideoProducerId { get; set; }
        public VideoProducer VideoProducer { get; set; }
    }
}
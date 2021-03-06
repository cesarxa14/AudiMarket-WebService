using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Models
{
    public class Contracts
    {
        public int Id { get; set; }
        public string Content { get; set; }

        //Relationships
        public int VideoProducerId { get; set; }
        public VideoProducer VideoProducer { get; set; }
        public int MusicProducerId { get; set; }
        public MusicProducer MusicProducer { get; set; }
    }
}
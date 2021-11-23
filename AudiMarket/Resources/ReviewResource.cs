using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Resources
{
    public class ReviewResource
    {
        
        public int Id { get; set; }
        public double Qualification { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public int MusicProducerId { get; set; }
        public MusicProducerResource MusicProducer { get; set; }
        public int VideoProducerId { get; set; }
        public VideoProducerResource VideoProducer { get; set; }
    }
}
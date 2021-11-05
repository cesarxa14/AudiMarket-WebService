using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Resources
{
    public class PublicationResource
    {
        
        public int ProjectId { get; set; }
        public int MusicProducerId { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public MusicProducerResource MusicProducer { get; set; }
    }
}

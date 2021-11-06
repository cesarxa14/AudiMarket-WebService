using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Resources
{
    public class ProjectResource
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Addeddate { get; set; }
        public int MusicProducerId { get; set; }
        public MusicProducerResource MusicProducer { get; set; }
    }
}

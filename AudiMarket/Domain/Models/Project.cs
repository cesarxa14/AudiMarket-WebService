using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Addeddate { get; set; }

        //Relationships
        public int MusicProducerId { get; set; }
        public MusicProducer MusicProducer { get; set; }
    }
}
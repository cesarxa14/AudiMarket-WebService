using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Models
{
    public class PlayList
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }

        //Relationships
        public int MusicProducerId { get; set; }
        public MusicProducer MusicProducer { get; set; }
    }
}
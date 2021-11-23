using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Models
{
    public class MusicProducer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Dni { get; set; }
        public DateTime Entrydate { get; set; }
        public string User { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        //Relationships
        public IList<Publication> Publications { get; set; } = new List<Publication>();
        public IList<Review> Reviews { get; set; } = new List<Review>();
        //public IList<PlayList> PlayLists { get; set; } = new List<PlayList>();

    }
}

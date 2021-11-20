﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        public string Password { get; set; }

        //Relationships
        public IList<Publication> Publications { get; set; } = new List<Publication>();
        //public IList<PlayList> PlayLists { get; set; } = new List<PlayList>();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Models
{
    public class PlayList
    {
        public int Id { get; set; }
        public DateTime Addeddate { get; set; }

        //Relationships
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
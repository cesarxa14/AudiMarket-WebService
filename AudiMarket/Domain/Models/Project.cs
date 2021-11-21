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
        public DateTime AddedDate { get; set; }

        //Relationships
        public int PlayListId { get; set; }
        public PlayList PlayList { get; set; }
    }
} 
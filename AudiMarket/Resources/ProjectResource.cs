using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Resources
{
    public class ProjectResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public int PlayListId { get; set; }
        public PlayListResource PlayList { get; set; }
    }
}
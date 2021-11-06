using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Resources
{
    public class PlayListResource
    {
        public DateTime Addeddate { get; set; }
        public int ProjectId { get; set; }
        public ProjectResource Project { get; set; }
    }
}

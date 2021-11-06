using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Resources
{
    public class SavePlayListResource
    {
        [Required]
        public DateTime Addeddate { get; set; }

        [Required]
        public int ProjectId { get; set; }
    }
}
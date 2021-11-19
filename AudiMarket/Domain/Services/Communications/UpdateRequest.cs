using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services.Communications
{
    public class UpdateRequest
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Dni { get; set; }
        
        public string User { get; set; }
        public string Password { get; set; }
    }
}

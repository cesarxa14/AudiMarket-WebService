using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services.Communications
{
    public class RegisterRequest
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Dni { get; set; }
        [Required]
        public DateTime Entrydate { get; set; }
        [Required]
        public string User { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

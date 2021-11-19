using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services.Communications
{
    public class AuthenticateRequest
    {
        [Required]
        public string User { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Authorization.Handlers.Interfaces
{
    public interface IJwtHandler
    {
        public string GenerateToken(MusicProducer mProducer);
        public int? ValidateToken(string token);
    }
}

using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services.Communications
{
    public class MusicProducerResponse : BaseResponse<MusicProducer>
    {
        public MusicProducerResponse(string message) : base(message)
        {
        }

        public MusicProducerResponse(MusicProducer resource) : base(resource)
        {
        }
    }
}

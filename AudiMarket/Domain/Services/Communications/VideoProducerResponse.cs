using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services.Communications
{
    public class VideoProducerResponse : BaseResponse<VideoProducer>
    {
        public VideoProducerResponse(string message) : base(message)
        {
        }

        public VideoProducerResponse(VideoProducer resource) : base(resource)
        {
        }
    }
}
using AudiMarket.Domain.Models;
using AudiMarket.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services
{
    public interface IVideoProducerService
    {
        Task<IEnumerable<VideoProducer>> GetAll();
        Task<VideoProducer> GetById(int id);
        Task<VideoProducerResponse> SaveVideoProducer(VideoProducer videoProducer);

        Task<VideoProducerResponse> UpdateVideoProducer(int id, VideoProducer videoProducer);

        Task<VideoProducerResponse> DeleteVideoProducer(int id);
    }
}
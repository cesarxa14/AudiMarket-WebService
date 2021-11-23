using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Repositories
{
    public interface IVideoProducerRepository
    {
        Task<IEnumerable<VideoProducer>> GetAll();

        Task AddAsync(VideoProducer videoProducer);

        Task<VideoProducer> FindById(int id);

        void Update(VideoProducer videoProducer);

        void Remove(VideoProducer videoProducer);
    }
}
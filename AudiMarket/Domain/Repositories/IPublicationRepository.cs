using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Repositories
{
    public interface IPublicationRepository
    {
        Task<IEnumerable<Publication>> ListAsync();
        Task AddPublication(Publication publication);

        Task<IEnumerable<Publication>> FindByIdMProducer(int id);

        Task<Publication> FindById(int id);
        Task<IEnumerable<Publication>> FindByMusicProducerId(int MProducerId);

        void Update(Publication publication);
        void Remove(Publication publication);
    }
}

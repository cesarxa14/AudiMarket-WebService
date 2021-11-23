using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Repositories
{
    public interface IMusicProducerRepository
    {
        Task<IEnumerable<MusicProducer>> GetAll();

        Task AddAsync(MusicProducer musicProducer);

        Task<MusicProducer> FindById(int id);

        Task<MusicProducer> FindByUsernameAndPassword(string username, string password);
        Task<MusicProducer> FindByPassword(string password);

        bool ExistsByUsername(string username);

        void Update(MusicProducer musicProducer);

        void Remove(MusicProducer musicProducer);
    }
}

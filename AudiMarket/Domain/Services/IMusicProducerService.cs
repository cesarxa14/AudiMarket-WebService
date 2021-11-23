using AudiMarket.Domain.Models;
using AudiMarket.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services
{
    public interface IMusicProducerService
    {
        Task<IEnumerable<MusicProducer>> GetAll();

        Task<MusicProducerResponse> GetByUsernameAndPassword(string username, string password);
        Task<MusicProducerResponse> SaveMusicProducer(MusicProducer musicProducer);

        Task<MusicProducerResponse> UpdateMusicProducer(int id, MusicProducer musicProducer);

        Task<MusicProducerResponse> DeleteMusicProducer(int id);
    }
}

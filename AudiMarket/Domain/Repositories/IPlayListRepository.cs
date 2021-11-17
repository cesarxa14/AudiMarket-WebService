using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Repositories
{
    public interface IPlayListRepository
    {
        Task<IEnumerable<PlayList>> ListAsync();
        Task AddPlayList(PlayList playList);

        Task<PlayList> FindById(int id);
        Task<IEnumerable<PlayList>> FindByMusicProducerId(int MProducerId);

        void Update(PlayList playList);
        void Remove(PlayList playList);
    }
}
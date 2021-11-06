using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Repositories
{
    public interface IPlayListRepository
    {
        Task<IEnumerable<PlayList>> GetAll();

        Task AddAsync(PlayList playList);

        Task<PlayList> FindById(int id);

        void Update(PlayList playList);
                             
        void Remove(PlayList playList);
    }
}
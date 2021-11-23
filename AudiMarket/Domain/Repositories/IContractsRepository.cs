using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Repositories
{
    public interface IContractsRepository
    {
        Task<IEnumerable<Contracts>> ListAsync();
        Task AddAsync(Contracts contracts);

        Task<IEnumerable<Contracts>> FindByMusicProducerId(int mProducerId);

        Task<Contracts> FindById(int id);

        void Update(Contracts contracts);

        void Remove(Contracts contracts);
    }
}
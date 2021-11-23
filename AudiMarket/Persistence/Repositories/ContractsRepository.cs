using AudiMarket.Domain.Models;
using AudiMarket.Domain.Repositories;
using AudiMarket.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Persistence.Repositories
{
    public class ContractsRepository : BaseRepository, IContractsRepository
    {
        public ContractsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Contracts contracts)
        {
            await _context.Contracts.AddAsync(contracts);
        }

        public async Task<Contracts> FindById(int id)
        {
            return await _context.Contracts.FindAsync(id);
        }

        public async Task<IEnumerable<Contracts>> FindByMusicProducerId(int mProducerId)
        {
            return await _context.Contracts.
                Where(p => p.MusicProducerId == mProducerId)
                .Include(p => p.MusicProducer)
                .ToListAsync();
        }

        public async Task<IEnumerable<Contracts>> ListAsync()
        {
            return await _context.Contracts.ToListAsync();
        }

        public void Remove(Contracts contracts)
        {
            _context.Contracts.Remove(contracts);
        }

        public void Update(Contracts contracts)
        {
            _context.Contracts.Update(contracts);
        }
    }
}
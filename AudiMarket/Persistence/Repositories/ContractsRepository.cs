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

        public async Task AddAsync(Contracts contract)
        {
            await _context.Contracts.AddAsync(contract);
        }

        public async Task<Contracts> FindById(int id)
        {
            return await _context.Contracts.FindAsync(id);
        }

        public async Task<IEnumerable<Contracts>> ListAsync()
        {
            return await _context.Contracts.ToListAsync();
        }

        public void Remove(Contracts contract)
        {
            _context.Contracts.Remove(contract);
        }

        public void Update(Contracts contract)
        {
            _context.Contracts.Update(contract);
        }
    }
}
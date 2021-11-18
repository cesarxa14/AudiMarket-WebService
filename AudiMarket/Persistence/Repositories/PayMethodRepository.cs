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
    public class PayMethodRepository : BaseRepository, IPayMethodRepository
    {
        public PayMethodRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(PayMethod paymethod)
        {
            await _context.PayMethods.AddAsync(paymethod);
        }

        public async Task<PayMethod> FindById(int id)
        {
            return await _context.PayMethods.FindAsync(id);
        }

        public async Task<IEnumerable<PayMethod>> ListAsync()
        {
            return await _context.PayMethods.ToListAsync();
        }

        public void Remove(PayMethod paymethod)
        {
            _context.PayMethods.Remove(paymethod);
        }

        public void Update(PayMethod paymethod)
        {
            _context.PayMethods.Update(paymethod);
        }
    }
}

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
    public class MusicProducerRepository : BaseRepository, IMusicProducerRepository
    {
        public MusicProducerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(MusicProducer musicProducer)
        {
            await _context.MusicProducers.AddAsync(musicProducer);
        }

        public bool ExistsByUsername(string username)
        {
            return _context.MusicProducers.Any(mp => mp.User == username);
        }

        public async Task<MusicProducer> FindById(int id)
        {
            return await _context.MusicProducers.FindAsync(id);
        }

        public async Task<MusicProducer> FindByPassword(string password)
        {
            return await _context.MusicProducers.SingleOrDefaultAsync(mp => mp.Password == password);
        }
        /*
        public async Task<MusicProducer> FindByUsername(string username)
        {
            return await _context.MusicProducers.SingleOrDefaultAsync(mp => mp.User == username);
        }*/

        public async Task<MusicProducer> FindByUsernameAndPassword(string username, string password)
        {
            return await _context.MusicProducers.SingleOrDefaultAsync(mp => mp.User == username && mp.Password == password);
        }

        public async Task<IEnumerable<MusicProducer>> GetAll()
        {
            return await _context.MusicProducers.ToListAsync();
        }

        public async Task<IEnumerable<MusicProducer>> ListAsync()
        {
            return await _context.MusicProducers.ToListAsync();
        }

        public void Remove(MusicProducer musicProducer)
        {
            _context.MusicProducers.Remove(musicProducer);
        }

        public void Update(MusicProducer musicProducer)
        {
            _context.MusicProducers.Update(musicProducer);
        }
    }
}

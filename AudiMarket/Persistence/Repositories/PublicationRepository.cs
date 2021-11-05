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
    public class PublicationRepository : BaseRepository, IPublicationRepository
    {
        public PublicationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddPublication(Publication publication)
        {
            await _context.Publications.AddAsync(publication);
        }

        public async Task<Publication> FindById(int id)
        {
            return await _context.Publications.Include(p => p.MusicProducer)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Publication>> FindByMusicProducerId(int MProducerId)
        {
            return await _context.Publications.
                Where(p => p.MusicProducerId == MProducerId)
                .Include(p => p.MusicProducer).ToListAsync();
        }

        public async Task<IEnumerable<Publication>> ListAsync()
        {
            return await _context.Publications.Include(p => p.MusicProducer).ToListAsync();
        }

        public void Remove(Publication publication)
        {
            _context.Publications.Remove(publication);
        }

        public void Update(Publication publication)
        {
            _context.Publications.Update(publication);
        }
    }
}

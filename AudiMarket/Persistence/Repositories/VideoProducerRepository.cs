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
    public class VideoProducerRepository : BaseRepository, IVideoProducerRepository
    {
        public VideoProducerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(VideoProducer videoProducer)
        {
            await _context.VideoProducers.AddAsync(videoProducer);
        }

        public async Task<VideoProducer> FindById(int id)
        {
            return await _context.VideoProducers.FindAsync(id);
        }

        public async Task<IEnumerable<VideoProducer>> GetAll()
        {
            return await _context.VideoProducers.ToListAsync();
        }

        public async Task<IEnumerable<VideoProducer>> ListAsync()
        {
            return await _context.VideoProducers.ToListAsync();
        }

        public void Remove(VideoProducer videoProducer)
        {
            _context.VideoProducers.Remove(videoProducer);
        }

        public void Update(VideoProducer videoProducer)
        {
            _context.VideoProducers.Update(videoProducer);
        }
    }
}
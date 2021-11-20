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
    public class ReviewRepository : BaseRepository, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddReview(Review review)
        {
            await _context.Reviews.AddAsync(review);
        }

        public async Task<Review> FindById(int id)
        {
            return await _context.Reviews.Include(p => p.MusicProducer)
                .Include(p=>p.VideoProducer)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Review>> FindByMusicProducerId(int mProducerId)
        {
            return await _context.Reviews.
                Where(p => p.MusicProducerId == mProducerId)
                .Include(p => p.MusicProducer)
                .Include(p=>p.VideoProducer).ToListAsync();
        }

        public async Task<IEnumerable<Review>> ListAsync()
        {
            return await _context.Reviews.Include(p => p.MusicProducer).Include(p=>p.VideoProducer).ToListAsync();
        }

        public void Remove(Review review)
        {
            _context.Reviews.Remove(review);
        }

        public void Update(Review review)
        {
            _context.Reviews.Update(review);
        }
    }
}
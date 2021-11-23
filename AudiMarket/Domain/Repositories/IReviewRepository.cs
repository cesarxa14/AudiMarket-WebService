using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Repositories
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> ListAsync();
        Task AddReview(Review review);

        Task<Review> FindById(int id);
        Task<IEnumerable<Review>> FindByMusicProducerId(int mProducerId);

        void Update(Review review);
        void Remove(Review review);
    }
}
using AudiMarket.Domain.Models;
using AudiMarket.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> ListAsync();
        Task<IEnumerable<Review>> ListByMProducerId(int mProducerId);
        Task<ReviewResponse> SaveReview(Review review);
        Task<ReviewResponse> UpdateReview(int id, Review review);
        Task<ReviewResponse> RemoveReview(int id);

    }
}
using AudiMarket.Domain.Models;
using AudiMarket.Domain.Repositories;
using AudiMarket.Domain.Services;
using AudiMarket.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMusicProducerRepository _musicProducerRepository;
        private readonly IVideoProducerRepository _videoProducerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IReviewRepository reviewRepository, IMusicProducerRepository musicProducerRepository, IUnitOfWork unitOfWork, IVideoProducerRepository videoProducerRepository)
        {
            _reviewRepository = reviewRepository;
            _musicProducerRepository = musicProducerRepository;
            _unitOfWork = unitOfWork;
            _videoProducerRepository = videoProducerRepository;
        }

        public async Task<IEnumerable<Review>> ListAsync()
        {
            return await _reviewRepository.ListAsync();
            
        }

        public async Task<IEnumerable<Review>> ListByMProducerId(int mProducerId)
        {
            return await _reviewRepository.FindByMusicProducerId(mProducerId);
            
        }

        public async Task<ReviewResponse> RemoveReview(int id)
        {
            //Validar reviewId
            var existingReview = await _reviewRepository.FindById(id);

            if (existingReview == null)
                return new ReviewResponse("Review not found");

            try
            {
                _reviewRepository.Remove(existingReview);
                await _unitOfWork.CompleteAsync();
                return new ReviewResponse(existingReview);
            }
            catch(Exception e)
            {
                return new ReviewResponse($"An error ocurred while removing the review: {e.Message}");
            }


        }

        public async Task<ReviewResponse> SaveReview(Review review)
        {
            //Validate musicProducerId
            var existingMProducerId = _musicProducerRepository.FindById(review.MusicProducerId);

            if (existingMProducerId == null)
                return new ReviewResponse("Invalid Music Producer");
            
            //Validate videoProducerId
            var existingVProducerId = _videoProducerRepository.FindById(review.VideoProducerId);

            if (existingVProducerId == null)
                return new ReviewResponse("Invalid Video Producer");
            
            try
            {
                await _reviewRepository.AddReview(review);
                await _unitOfWork.CompleteAsync();

                return new ReviewResponse(review);
            }
            catch(Exception e)
            {
                return new ReviewResponse($"An error ocurred while saving the review: {e.Message}");
            }

            


            
        }

        public async Task<ReviewResponse> UpdateReview(int id, Review review)
        {
            //Validar reviewId
            var existingReview = await _reviewRepository.FindById(id);

            if (existingReview == null)
                return new ReviewResponse("Review not found");

            //Validar musicProducerID

            var existingMProducer = await _musicProducerRepository.FindById(review.MusicProducerId);

            if (existingMProducer == null)
                return new ReviewResponse("Music producer not found");
            
            //Validar videoProducerID

            var existingVProducer = await _videoProducerRepository.FindById(review.VideoProducerId);

            if (existingVProducer == null)
                return new ReviewResponse("Video producer not found");


            existingReview.Description = review.Description;
            existingReview.Qualification = review.Qualification;
            existingReview.ReviewDate = review.ReviewDate;

            try
            {
                _reviewRepository.Update(existingReview);
                await _unitOfWork.CompleteAsync();
                return new ReviewResponse(existingReview);
            }
            catch(Exception e)
            {
                return new ReviewResponse($"An error ocurred while updating the review: {e.Message}");
            }
            
        }
    }
}

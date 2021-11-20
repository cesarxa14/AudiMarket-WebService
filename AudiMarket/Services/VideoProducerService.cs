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
    public class VideoProducerService : IVideoProducerService
    {
        private readonly IVideoProducerRepository _videoProducerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VideoProducerService(IVideoProducerRepository videoProducerRepository, IUnitOfWork unitOfWork)
        {
            _videoProducerRepository = videoProducerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VideoProducerResponse> DeleteVideoProducer(int id)
        {
            var existingVideoProducer = await _videoProducerRepository.FindById(id);
            if (existingVideoProducer == null)
                return new VideoProducerResponse("Category not found");

            try
            {
                _videoProducerRepository.Remove(existingVideoProducer);
                await _unitOfWork.CompleteAsync();

                return new VideoProducerResponse(existingVideoProducer);
            }
            catch (Exception e)
            {
                return new VideoProducerResponse($"An error ocurred while deleting the video producer: {e.Message}");
            }
        }

        public async Task<IEnumerable<VideoProducer>> GetAll()
        {
            return await _videoProducerRepository.GetAll();
        }


        public async Task<VideoProducerResponse> SaveVideoProducer(VideoProducer videoProducer)
        {
            try
            {
                await _videoProducerRepository.AddAsync(videoProducer);
                await _unitOfWork.CompleteAsync();

                return new VideoProducerResponse(videoProducer);
            }
            catch (Exception e)
            {
                return new VideoProducerResponse($"An error occured while saving the video producer: {e.Message}");

            }
        }

        public async Task<VideoProducerResponse> UpdateVideoProducer(int id, VideoProducer videoProducer)
        {
            var existingVideoProducer = await _videoProducerRepository.FindById(id);
            if (existingVideoProducer == null)
                return new VideoProducerResponse("VideoProducer not found");

            existingVideoProducer.Firstname = videoProducer.Firstname;
            existingVideoProducer.Lastname = videoProducer.Lastname;
            existingVideoProducer.Dni = videoProducer.Dni;
            existingVideoProducer.Entrydate = videoProducer.Entrydate;
            existingVideoProducer.User = videoProducer.User;
            existingVideoProducer.Password = videoProducer.Password;

            try
            {
                _videoProducerRepository.Update(existingVideoProducer);
                await _unitOfWork.CompleteAsync();

                return new VideoProducerResponse(existingVideoProducer);
            }
            catch (Exception e)
            {
                return new VideoProducerResponse($"An error ocurred while updating the video producer: {e.Message}");
            }
        }

        
    }
}

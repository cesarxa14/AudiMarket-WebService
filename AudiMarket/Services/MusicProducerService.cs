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
    public class MusicProducerService : IMusicProducerService
    {
        private readonly IMusicProducerRepository _musicProducerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MusicProducerService(IMusicProducerRepository musicProducerRepository, IUnitOfWork unitOfWork)
        {
            _musicProducerRepository = musicProducerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<MusicProducerResponse> DeleteMusicProducer(int id)
        {
            var existingMusicProducer = await _musicProducerRepository.FindById(id);
            if (existingMusicProducer == null)
                return new MusicProducerResponse("Category not found");

            try
            {
                _musicProducerRepository.Remove(existingMusicProducer);
                await _unitOfWork.CompleteAsync();

                return new MusicProducerResponse(existingMusicProducer);
            }
            catch (Exception e)
            {
                return new MusicProducerResponse($"An error ocurred while deleting the music producer: {e.Message}");
            }
        }

        public async Task<IEnumerable<MusicProducer>> GetAll()
        {
            return await _musicProducerRepository.GetAll();
        }

        public async Task<MusicProducer> GetByUsernameAndPassword(string username, string password)
        {/*
            try
            {
                var existUser = await _musicProducerRepository.FindByUsernameAndPassword(username, password);
                if(existUser != null)
                {
                    return existUser;
                }

                return null;

            }
            catch (Exception)
            {

            }*/
            return null;
        }

        public async Task<MusicProducerResponse> SaveMusicProducer(MusicProducer musicProducer)
        {
            try
            {
                await _musicProducerRepository.AddAsync(musicProducer);
                await _unitOfWork.CompleteAsync();

                return new MusicProducerResponse(musicProducer);
            }
            catch (Exception e)
            {
                return new MusicProducerResponse($"An error occured while saving the music producer: {e.Message}");

            }
        }

        public async Task<MusicProducerResponse> UpdateMusicProducer(int id, MusicProducer musicProducer)
        {
            var existingMusicProducer = await _musicProducerRepository.FindById(id);
            if (existingMusicProducer == null)
                return new MusicProducerResponse("MusicProducer not found");

            existingMusicProducer.Firstname = musicProducer.Firstname;
            existingMusicProducer.Lastname = musicProducer.Lastname;
            existingMusicProducer.Dni = musicProducer.Dni;
            existingMusicProducer.Entrydate = musicProducer.Entrydate;
            existingMusicProducer.User = musicProducer.User;
            existingMusicProducer.Password = musicProducer.Password;

            try
            {
                _musicProducerRepository.Update(existingMusicProducer);
                await _unitOfWork.CompleteAsync();

                return new MusicProducerResponse(existingMusicProducer);
            }
            catch (Exception e)
            {
                return new MusicProducerResponse($"An error ocurred while updating the music producer: {e.Message}");
            }
        }

        Task<MusicProducerResponse> IMusicProducerService.GetByUsernameAndPassword(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}

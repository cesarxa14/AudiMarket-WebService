using AudiMarket.Authorization.Handlers.Interfaces;
using AudiMarket.Domain.Models;
using AudiMarket.Domain.Repositories;
using AudiMarket.Domain.Services;
using AudiMarket.Domain.Services.Communications;
using AudiMarket.Exceptions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;

namespace AudiMarket.Services
{
    public class MusicProducerService : IMusicProducerService
    {
        
        private readonly IMusicProducerRepository _musicProducerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public MusicProducerService(IMusicProducerRepository musicProducerRepository, IUnitOfWork unitOfWork, IJwtHandler jwtHandler, IMapper mapper)
        {
            _musicProducerRepository = musicProducerRepository;
            _unitOfWork = unitOfWork;
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }

        public async Task<MusicProducer> Authenticate(AuthenticateRequest request)
        {
            var mProducerUser = await _musicProducerRepository.FindByUsernameAndPassword(request.User, request.Password);
            //var mProducerPassowrd = await _musicProducerRepository.FindByPassword(request.Password);

            //validate
            //if (mProducerUser == null || !BCryptNet.Verify(request.Password, mProducerUser.Password))
            //  throw new AppException("username or password is incorrect.");
            if (mProducerUser == null)
                throw new AppException("username or password is incorrect.");

            return mProducerUser;
            //authenticate succesful
            /*var response = _mapper.Map<AuthenticateResponse>(mProducerUser);
            response.Token = _jwtHandler.GenerateToken(mProducerUser);
            return response;*/


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

        public Task<MusicProducer> GetById(int id)
        {
            var mProducer = _musicProducerRepository.FindById(id);
            if (mProducer == null) throw new KeyNotFoundException("User not found");
            return mProducer;
            
        }

        public async Task Register(RegisterRequest request)
        {
            //validate
            if (_musicProducerRepository.ExistsByUsername(request.User))
                throw new AppException($"Username {request.User} is already taken");

            // map request to music producer object
            var mProducer = _mapper.Map<MusicProducer>(request);

            mProducer.Password = BCryptNet.HashPassword(request.Password);

            //save music producer
            try
            {
                await _musicProducerRepository.AddAsync(mProducer);
                await _unitOfWork.CompleteAsync();
            }catch(Exception e)
            {
                throw new AppException($"An error while saving the user: {e.Message}");
            }


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

       
    }
}

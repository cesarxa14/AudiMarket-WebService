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
    public class PlayListService : IPlayListService
    {
        private readonly IPlayListRepository _playListRepository;
        private readonly IMusicProducerRepository _musicProducerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PlayListService(IPlayListRepository playListRepository)
        {
            _playListRepository = playListRepository;
        }

        public async Task<IEnumerable<PlayList>> ListAsync()
        {
            return await _playListRepository.ListAsync();

        }

        public async Task<IEnumerable<PlayList>> ListByMProducerId(int mProducerId)
        {
            return await _playListRepository.FindByMusicProducerId(mProducerId);

        }

        public async Task<PlayListResponse> RemovePlayList(int id)
        {
            //Validar playListId
            var existingPlayList = await _playListRepository.FindById(id);

            if (existingPlayList == null)
                return new PlayListResponse("PlayList not found");

            try
            {
                _playListRepository.Remove(existingPlayList);
                await _unitOfWork.CompleteAsync();
                return new PlayListResponse(existingPlayList);
            }
            catch (Exception e)
            {
                return new PlayListResponse($"An error ocurred while removing the playList: {e.Message}");
            }


        }

        public async Task<PlayListResponse> SavePlayList(PlayList playList)
        {
            //Validate musicaProducerId
            var existingMProducerId = _musicProducerRepository.FindById(playList.Id);

            if (existingMProducerId == null)
                return new PlayListResponse("Invalid Music Producer");


            try
            {
                await _playListRepository.AddPlayList(playList);
                await _unitOfWork.CompleteAsync();

                return new PlayListResponse(playList);
            }
            catch (Exception e)
            {
                return new PlayListResponse($"An error ocurred while saving the playList: {e.Message}");
            }

        }

        public async Task<PlayListResponse> UpdatePlayList(int id, PlayList playList)
        {
            //Validar playListId
            var existingPlayList = await _playListRepository.FindById(playList.Id);

            if (existingPlayList == null)
                return new PlayListResponse("PlayList not found");

            //Validar musicProducerID

            var existingMProducer = await _musicProducerRepository.FindById(playList.MusicProducerId);

            if (existingMProducer == null)
                return new PlayListResponse("Music producer not found");


            existingPlayList.Description = playList.Description;
            existingPlayList.PlayListDate = playList.PlayListDate;

            try
            {
                _playListRepository.Update(existingPlayList);
                await _unitOfWork.CompleteAsync();
                return new PlayListResponse(existingPlayList);
            }
            catch (Exception e)
            {
                return new PlayListResponse($"An error ocurred while updating the playList: {e.Message}");
            }

        }
    }
}
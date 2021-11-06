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
        private readonly IUnitOfWork _unitOfWork;

        public PlayListService(IPlayListRepository playListRepository, IUnitOfWork unitOfWork)
        {
            _playListRepository = playListRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PlayListResponse> DeleteplayList(int id)
        {
            var existingplayList = await _playListRepository.FindById(id);
            if (existingplayList == null)
                return new PlayListResponse("playList not found");

            try
            {
                _playListRepository.Remove(existingplayList);
                await _unitOfWork.CompleteAsync();

                return new PlayListResponse(existingplayList);
            }
            catch (Exception e)
            {
                return new PlayListResponse($"An error ocurred while deleting the playList: {e.Message}");
            }
        }

        public async Task<IEnumerable<playList>> GetAll()
        {
            return await _playListRepository.GetAll();
        }


        public async Task<PlayListResponse> SavePlayList(playList playList)
        {
            try
            {
                await _playListRepository.AddAsync(playList);
                await _unitOfWork.CompleteAsync();

                return new PlayListResponse(playList);
            }
            catch (Exception e)
            {
                return new PlayListResponse($"An error occured while saving the playList: {e.Message}");

            }
        }

        public async Task<PlayListResponse> UpdatePlayList(int id, PlayList playList)
        {
            var existingplayList = await _playListRepository.FindById(id);
            if (existingplayList == null)
                return new PlayListResponse("playList not found");

            existingplayList.Addeddate = playList.Addeddate;

            try
            {
                _playListRepository.Update(existingplayList);
                await _unitOfWork.CompleteAsync();

                return new PlayListResponse(existingplayList);
            }
            catch (Exception e)
            {
                return new PlayListResponse($"An error ocurred while updating the playList: {e.Message}");
            }
        }


    }
}
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
    public class PublicationService : IPublicationService
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IMusicProducerRepository _musicProducerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PublicationService(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        public async Task<IEnumerable<Publication>> ListAsync()
        {
            return await _publicationRepository.ListAsync();
            
        }

        public async Task<IEnumerable<Publication>> ListByMProducerId(int mProducerId)
        {
            return await _publicationRepository.FindByMusicProducerId(mProducerId);
            
        }

        public async Task<PublicationResponse> RemovePublication(int id)
        {
            //Validar publicationId
            var existingPublication = await _publicationRepository.FindById(id);

            if (existingPublication == null)
                return new PublicationResponse("Publication not found");

            try
            {
                _publicationRepository.Remove(existingPublication);
                await _unitOfWork.CompleteAsync();
                return new PublicationResponse(existingPublication);
            }
            catch(Exception e)
            {
                return new PublicationResponse($"An error ocurred while removing the publication: {e.Message}");
            }


        }

        public async Task<PublicationResponse> SavePublication(Publication publication)
        {
            //Validate musicaProducerId
            var existingMProducerId = _musicProducerRepository.FindById(publication.Id);

            if (existingMProducerId == null)
                return new PublicationResponse("Invalid Music Producer");


            try
            {
                await _publicationRepository.AddPublication(publication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(publication);
            }
            catch(Exception e)
            {
                return new PublicationResponse($"An error ocurred while saving the publication: {e.Message}");
            }

            


            
        }

        public async Task<PublicationResponse> UpdatePublication(int id, Publication publication)
        {
            //Validar publicationId
            var existingPublication = await _publicationRepository.FindById(publication.Id);

            if (existingPublication == null)
                return new PublicationResponse("Publication not found");

            //Validar musicProducerID

            var existingMProducer = await _musicProducerRepository.FindById(publication.MusicProducerId);

            if (existingMProducer == null)
                return new PublicationResponse("Music producer not found");


            existingPublication.Description = publication.Description;
            existingPublication.PublicationDate = publication.PublicationDate;

            try
            {
                _publicationRepository.Update(existingPublication);
                await _unitOfWork.CompleteAsync();
                return new PublicationResponse(existingPublication);
            }
            catch(Exception e)
            {
                return new PublicationResponse($"An error ocurred while updating the publication: {e.Message}");
            }
            
        }
    }
}

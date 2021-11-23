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
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MessageService(IMessageRepository messageRepository, IUnitOfWork unitOfWork)
        {
            _messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<MessageResponse> DeleteAsync(int id)
        {
            var existingMessage = await _messageRepository.FindById(id);
            
            if (existingMessage == null)
                return new MessageResponse("Message not found");

            try
            {
                _messageRepository.Remove(existingMessage);
                await _unitOfWork.CompleteAsync();

                return new MessageResponse(existingMessage);
            }
            catch(Exception e)
            {
                return new MessageResponse($"An error ocurred while deleting the message: {e.Message}");
            }
        }

        public async Task<IEnumerable<Message>> ListAsync()
        {
            return await _messageRepository.ListAsync();
            throw new System.NotImplementedException();
        }

        public async Task<MessageResponse> SaveAsync(Message message)
        {
            try
            {
                await _messageRepository.AddAsync(message);
                await _unitOfWork.CompleteAsync();

                return new MessageResponse(message);
            }
            catch(Exception e)
            {
                return new MessageResponse($"An error occured while saving the message: {e.Message}");

            }
        }

        public async Task<MessageResponse> UpdateAsync(int id, Message message)
        {
            var existingMessage = await _messageRepository.FindById(id);
            if (existingMessage == null)
                return new MessageResponse("Message not found");

            existingMessage.Id = message.Id;

            try
            {
                _messageRepository.Update(existingMessage);
                await _unitOfWork.CompleteAsync();

                return new MessageResponse(existingMessage);
            }
            catch(Exception e)
            {
                return new MessageResponse($"An error ocurred while updating the message: {e.Message}");
            }

        }
    }
}
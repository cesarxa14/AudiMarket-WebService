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
    public class PayMethodService : IPayMethodService
    {
        private readonly IPayMethodRepository _payMethodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PayMethodService(IPayMethodRepository payMethodRepository, IUnitOfWork unitOfWork)
        {
            _payMethodRepository = payMethodRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PayMethodResponse> DeleteAsync(int id)
        {
            var existingPayMethod = await _payMethodRepository.FindById(id);
            if (existingPayMethod == null)
                return new PayMethodResponse("Pay Method not found");

            try
            {
                _payMethodRepository.Remove(existingPayMethod);
                await _unitOfWork.CompleteAsync();

                return new PayMethodResponse(existingPayMethod);
            }
            catch (Exception e)
            {
                return new PayMethodResponse($"An error ocurred while deleting the pay method: {e.Message}");
            }
        }

        public async Task<IEnumerable<PayMethod>> ListAsync()
        {
            return await _payMethodRepository.ListAsync();
            throw new System.NotImplementedException();
        }

        public async Task<PayMethodResponse> SaveAsync(PayMethod payMethod)
        {
            try
            {
                await _payMethodRepository.AddAsync(payMethod);
                await _unitOfWork.CompleteAsync();

                return new PayMethodResponse(payMethod);
            }
            catch (Exception e)
            {
                return new PayMethodResponse($"An error occured while saving the pay method: {e.Message}");

            }
        }

        public async Task<PayMethodResponse> UpdateAsync(int id, PayMethod payMethod)
        {
            var existingPayMethod = await _payMethodRepository.FindById(id);
            if (existingPayMethod == null)
                return new PayMethodResponse("Pay Method not found");

            existingPayMethod.Name = payMethod.Name;

            try
            {
                _payMethodRepository.Update(existingPayMethod);
                await _unitOfWork.CompleteAsync();

                return new PayMethodResponse(existingPayMethod);
            }
            catch (Exception e)
            {
                return new PayMethodResponse($"An error ocurred while updating the pay method: {e.Message}");
            }

        }
    }
}

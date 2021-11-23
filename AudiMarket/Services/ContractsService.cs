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
    public class ContractsService : IContractsService
    {
        private readonly IContractsRepository _contractsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContractsService(IContractsRepository contractsRepository, IUnitOfWork unitOfWork)
        {
            _contractsRepository = contractsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ContractsResponse> DeleteAsync(int id)
        {
            var existingContracts = await _contractsRepository.FindById(id);
            
            if (existingContracts == null)
                return new ContractsResponse("Contract not found");

            try
            {
                _contractsRepository.Remove(existingContracts);
                await _unitOfWork.CompleteAsync();

                return new ContractsResponse(existingContracts);
            }
            catch(Exception e)
            {
                return new ContractsResponse($"An error ocurred while deleting the contract: {e.Message}");
            }
        }

        public async Task<IEnumerable<Contracts>> ListAsync()
        {
            return await _contractsRepository.ListAsync();
            throw new System.NotImplementedException();
        }

        public async Task<ContractsResponse> SaveAsync(Contracts contracts)
        {
            try
            {
                await _contractsRepository.AddAsync(contracts);
                await _unitOfWork.CompleteAsync();

                return new ContractsResponse(contracts);
            }
            catch(Exception e)
            {
                return new ContractsResponse($"An error occured while saving the contract: {e.Message}");

            }
        }

        public async Task<ContractsResponse> UpdateAsync(int id, Contracts contracts)
        {
            var existingContracts = await _contractsRepository.FindById(id);
            if (existingContracts == null)
                return new ContractsResponse("Contract not found");

            existingContracts.Id = contracts.Id;

            try
            {
                _contractsRepository.Update(existingContracts);
                await _unitOfWork.CompleteAsync();

                return new ContractsResponse(existingContracts);
            }
            catch(Exception e)
            {
                return new ContractsResponse($"An error ocurred while updating the contract: {e.Message}");
            }

        }
    }
}
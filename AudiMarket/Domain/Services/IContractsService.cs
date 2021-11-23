using AudiMarket.Domain.Models;
using AudiMarket.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services
{
    public interface IContractsService
    {
        Task<IEnumerable<Contracts>> ListAsync();
        Task<ContractsResponse> SaveAsync(Contracts category);

        Task<IEnumerable<Contracts>> ListByMProducerId(int mProducerId);
        
        Task<IEnumerable<Contracts>> ListByVProducerId(int vProducerId);

        Task<ContractsResponse> UpdateAsync(int id, Contracts category);

        Task<ContractsResponse> DeleteAsync(int id);
    }
}
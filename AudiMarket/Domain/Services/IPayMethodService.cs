using AudiMarket.Domain.Models;
using AudiMarket.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services
{
    public interface IPayMethodService
    {
        Task<IEnumerable<PayMethod>> ListAsync();
        Task<PayMethodResponse> SaveAsync(PayMethod payMethop);

        Task<PayMethodResponse> UpdateAsync(int id, PayMethod payMethop);

        Task<PayMethodResponse> DeleteAsync(int id);

    }
}
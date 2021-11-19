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
        Task<CPayMethodResponse> SaveAsync(PayMethod paymethop);

        Task<PayMethodResponse> UpdateAsync(int id, PayMethod paymethop);

        Task<PayMethodResponse> DeleteAsync(int id);

    }
}
using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Repositories
{
    public interface IPayMethodRepository
    {
        Task<IEnumerable<PayMethod>> ListAsync();

        Task AddAsync(PayMethod paymethod);

        Task<PayMethod> FindById(int id);

        void Update(PayMethod paymethod);

        void Remove(PayMethod paymethod);
    }
}
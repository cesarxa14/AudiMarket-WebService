using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Repositories
{
    public interface IVoucherRepository
    {
        Task<IEnumerable<Voucher>> GetAll();

        Task AddAsync(Voucher voucher);

        Task<Voucher> FindById(int id);

        void Update(Voucher voucher);

        void Remove(Voucher voucher);
    }
}

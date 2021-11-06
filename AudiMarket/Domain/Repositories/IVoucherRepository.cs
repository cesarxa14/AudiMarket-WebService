using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Repositories
{
    public interface IVoucherionRepository
    {
        Task<IEnumerable<Voucher>> ListAsync();
        Task AddVoucher(Voucher voucher);

        Task<Vouchern> FindById(int id);
        Task<IEnumerable<Voucher>> FindByContractId(int ContractId);

        void Update(Voucher voucher);
        void Remove(Voucher voucher);
    }
}

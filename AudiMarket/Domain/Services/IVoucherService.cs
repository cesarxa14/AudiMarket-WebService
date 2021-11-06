using AudiMarket.Domain.Models;
using AudiMarket.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services
{
    public interface IVoucherService
    {
        Task<IEnumerable<Voucher>> ListAsync();
        Task<IEnumerable<Voucher>> ListByContractId(int ContractId);
        Task<VoucherResponse> SaveVoucher(Voucher voucher);
        Task<VoucherResponse> UpdateVoucher(int id, Voucher voucher);
        Task<VoucherResponse> RemoveVoucher(int id);
    }
}

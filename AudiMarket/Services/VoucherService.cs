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
    public class VoucherService : IVoucherService
    {
        private readonly IVoucherRepository _voucherRepository;
        private readonly IContractRepository _contractRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VoucherService(IVoucherRepository voucherRepository)
        {
            _voucherRepository = voucherRepository;
        }

        public async Task<IEnumerable<Voucher>> ListAsync()
        {
            return await _voucherRepository.ListAsync();
            
        }

        public async Task<IEnumerable<Voucher>> ListByMProducerId(int contractId)
        {
            return await _voucherRepository.FindByMusicProducerId(contractId);
            
        }

        public async Task<VoucherResponse> RemoveVoucher(int id)
        {
            var existingVoucher = await _voucherRepository.FindById(id);

            if (existingVoucher == null)
                return new voucherResponse("Voucher not found");

            try
            {
                _voucherRepository.Remove(existingVoucher);
                await _unitOfWork.CompleteAsync();
                return new VoucherResponse(existingVoucher);
            }
            catch(Exception e)
            {
                return new VoucherResponse($"An error ocurred while removing the voucher: {e.Message}");
            }


        }

        public async Task<VoucherResponse> SaveVoucher(Voucher voucher)
        {
            var existingContractId = _contractRepository.FindById(voucher.Id);

            if (existingContractId == null)
                return new VoucherResponse("Invalid Contract");


            try
            {
                await _voucherRepository.AddVoucher(voucher);
                await _unitOfWork.CompleteAsync();

                return new VoucherResponse(voucher);
            }
            catch(Exception e)
            {
                return new VoucherResponse($"An error ocurred while saving the voucher: {e.Message}");
            }

            


            
        }
    }
}

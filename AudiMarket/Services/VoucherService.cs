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
        private readonly IUnitOfWork _unitOfWork;

        public VoucherService(IVoucherRepository voucherRepository)
        {
            _voucherRepository = voucherRepository;
        }

        public async Task<IEnumerable<Voucher>> ListAsync()
        {
            return await _voucherRepository.ListAsync();

        }

        public async Task<IEnumerable<Voucher>> ListByContractId(int contractId)
        {
            return await _voucherRepository.FindByContractId(contractId);

        }

        public async Task<voucherResponse> RemoveVoucher(int id)
        {
            var existingVoucher = await _voucherRepository.FindById(id);

            if (existingVoucher == null)
                return new VoucherResponse("Voucher not found");

            try
            {
                _voucherRepository.Remove(existingVoucher);
                await _unitOfWork.CompleteAsync();
                return new VoucherResponse(existingVoucher);
            }
            catch (Exception e)
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
            catch (Exception e)
            {
                return new VoucherResponse($"An error ocurred while saving the voucher: {e.Message}");
            }

        }

        public async Task<VoucherResponse> UpdateVoucher(int id, Voucher voucher)
        {
            var existingVoucher = await _voucherRepository.FindById(voucher.Id);

            if (existingVoucher == null)
                return new VoucherResponse("Voucher not found");


            var existingContract = await _contractRepository.FindById(voucher.ContractId);

            if (existingContract == null)
                return new VoucherResponse("Contract not found");


            existingVoucher.CreateDate = voucher.CreateDate;

            try
            {
                _voucherRepository.Update(existingVoucher);
                await _unitOfWork.CompleteAsync();
                return new VoucherResponse(existingVoucher);
            }
            catch (Exception e)
            {
                return new VoucherResponse($"An error ocurred while updating the voucher: {e.Message}");
            }

        }
    }
}
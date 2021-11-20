using AudiMarket.Domain.Models;
using AudiMarket.Domain.Repositories;
using AudiMarket.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Persistence.Repositories
{
    public class VoucherRepository : BaseRepository, IVoucherRepository
    {
        public VoucherRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddVoucher(Voucher voucher)
        {
            await _context.Vouchers.AddAsync(voucher);
        }

        
        public async Task<Voucher> FindById(int id)
        {
            return await _context.Vouchers.FindAsync(id);
        }
        
        /*
        public async Task<IEnumerable<Voucher>> FindByContractId(int ContractId)
        {
            return await _context.Vouchers.
                Where(p => p.ContractId == ContractId)
                .Include(p => p.MusicProducer).ToListAsync();
        }
        */
        public async Task<IEnumerable<Voucher>> ListAsync()
        {
            return await _context.Vouchers.ToListAsync();
        }

        public void Remove(Voucher voucher)
        {
            _context.Vouchers.Remove(voucher);
        }

        public void Update(Voucher voucher)
        {
            _context.Vouchers.Update(voucher);
        }

        public Task<IEnumerable<Voucher>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Voucher voucher)
        {
            throw new NotImplementedException();
        }
    }
}
using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services.Communications
{
    public class VoucherResponse : BaseResponse<Voucher>
    {
        public VoucherResponse(string message) : base(message)
        {
        }

        public VoucherResponse(Voucher resource) : base(resource)
        {
        }
    }
}
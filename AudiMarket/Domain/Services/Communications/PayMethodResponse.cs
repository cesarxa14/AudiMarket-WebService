using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services.Communications
{
    public class PayMethodResponse : BaseResponse<PayMethod>
    {
        public PayMethodResponse(string message) : base(message)
        {
        }

        public PayMethodResponse(PayMethod resource) : base(resource)
        {
        }
    }
}
using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services.Communications
{
    public class ContractsResponse : BaseResponse<Contracts>
    {
        public ContractsResponse(string message) : base(message)
        {
        }

        public ContractsResponse(Contracts resource) : base(resource)
        {
        }
    }
}
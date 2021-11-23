using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services.Communications
{
    public class ContractsResponse : BaseResponse<Publication>
    {
        public ContractsResponse(string message) : base(message)
        {
        }

        public ContractsResponse(Publication resource) : base(resource)
        {
        }
    }
}
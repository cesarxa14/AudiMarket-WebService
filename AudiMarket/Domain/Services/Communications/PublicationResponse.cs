using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services.Communications
{
    public class PublicationResponse : BaseResponse<Publication>
    {
        public PublicationResponse(string message) : base(message)
        {
        }

        public PublicationResponse(Publication resource) : base(resource)
        {
        }
    }
}

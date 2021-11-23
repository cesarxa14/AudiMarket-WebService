using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services.Communications
{
    public class MessageResponse : BaseResponse<Message>
    {
        public MessageResponse(string message) : base(message)
        {
        }

        public MessageResponse(Message resource) : base(resource)
        {
        }
    }
}
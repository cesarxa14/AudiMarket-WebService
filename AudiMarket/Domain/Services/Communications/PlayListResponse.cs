using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services.Communications
{
    public class PlayListResponse : BaseResponse<PlayList>
    {
        public PlayListResponse(string message) : base(message)
        {
        }

        public PlayListResponse(PlayList resource) : base(resource)
        {
        }
    }
}
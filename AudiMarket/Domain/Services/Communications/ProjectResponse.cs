using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services.Communications
{
    public class ProjectResponse : BaseResponse<Project>
    {
        public ProjectResponse(string message) : base(message)
        {
        }

        public ProjectResponse(Project resource) : base(resource)
        {
        }
    }
}
using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services.Communications
{
    public class CategoryResponse : BaseResponse<Category>
    {
        public CategoryResponse(string message) : base(message)
        {
        }

        public CategoryResponse(Category resource) : base(resource)
        {
        }
    }
}

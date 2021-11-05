using AudiMarket.Domain.Models;
using AudiMarket.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services
{
    public interface IPublicationService
    {
        Task<IEnumerable<Publication>> ListAsync();
        Task<IEnumerable<Publication>> ListByMProducerId(int mProducerId);
        Task<PublicationResponse> SavePublication(Publication publication);
        Task<PublicationResponse> UpdatePublication(int id, Publication publication);
        Task<PublicationResponse> RemovePublication(int id);

    }
}

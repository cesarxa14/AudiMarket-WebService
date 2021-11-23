using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Repositories
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> ListAsync();
        Task AddAsync(Message category);

        Task<Message> FindById(int id);

        void Update(Message category);

        void Remove(Message category);
    }
}
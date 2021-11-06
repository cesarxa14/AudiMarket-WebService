using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAll();

        Task AddAsync(Project project);

        Task<Project> FindById(int id);

        void Update(Project project);

        void Remove(Project project);
    }
}
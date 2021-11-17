using AudiMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> ListAsync();
        Task AddProject(Project project);

        Task<Project> FindById(int id);
        Task<IEnumerable<Project>> FindByPlayListId(int PlayListId);

        void Update(Project project);
        void Remove(Project project);
    }
}
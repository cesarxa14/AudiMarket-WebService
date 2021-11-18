using AudiMarket.Domain.Models;
using AudiMarket.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Domain.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAll();
        
        Task<IEnumerable<Project>> ListByPlayListId(int playListId);
        Task<ProjectResponse> SaveProject(Project project);
        Task<ProjectResponse> UpdateProject(int id, Project project);
        Task<ProjectResponse> RemoveProject(int id);

    }
}
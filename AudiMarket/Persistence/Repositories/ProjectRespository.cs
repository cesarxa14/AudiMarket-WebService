using AudiMarket.Domain.Models;
using AudiMarket.Domain.Repositories;
using AudiMarket.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Persistence.Repositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddProject(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public async Task<Project> FindById(int id)
        {
            return await _context.Projects.Include(p => p.PlayList)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Project>> FindByPlayListId(int PlayListId)
        {
            return await _context.Projects.
                Where(p => p.PlayListId == PlayListId)
                .Include(p => p.PlayList).ToListAsync();
        }

        public async Task<IEnumerable<Project>> ListAsync()
        {
            return await _context.Projects.Include(p => p.PlayList).ToListAsync();
        }

        public void Remove(Project project)
        {
            _context.Projects.Remove(project);
        }

        public void Update(Project project)
        {
            _context.Projects.Update(project);
        }
    }
}
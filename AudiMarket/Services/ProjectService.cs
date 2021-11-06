using AudiMarket.Domain.Models;
using AudiMarket.Domain.Repositories;
using AudiMarket.Domain.Services;
using AudiMarket.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProjectResponse> DeleteProject(int id)
        {
            var existingProject = await _projectRepository.FindById(id);
            if (existingProject == null)
                return new ProjectResponse("Project not found");

            try
            {
                _projectRepository.Remove(existingProject);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(existingProject);
            }
            catch (Exception e)
            {
                return new ProjectResponse($"An error ocurred while deleting the project: {e.Message}");
            }
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _projectRepository.GetAll();
        }


        public async Task<ProjectResponse> SaveProject(Project project)
        {
            try
            {
                await _projectRepository.AddAsync(project);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(project);
            }
            catch (Exception e)
            {
                return new ProjectResponse($"An error occured while saving the project: {e.Message}");

            }
        }

        public async Task<ProjectResponse> UpdateProject(int id, Project project)
        {
            var existingProject = await _projectRepository.FindById(id);
            if (existingProject == null)
                return new ProjectResponse("Project not found");

            existingProject.Name = project.Name;
            existingProject.Description = project.Description;
            existingProject.Addeddate = project.Addeddate;
            
            try
            {
                _projectRepository.Update(existingProject);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(existingProject);
            }
            catch (Exception e)
            {
                return new ProjectResponse($"An error ocurred while updating the project: {e.Message}");
            }
        }


    }
}
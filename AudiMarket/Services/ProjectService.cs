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
        private readonly IPlayListRepository _playListRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IProjectRepository projectRepository, IPlayListRepository playListRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _playListRepository = playListRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _projectRepository.GetAll();
        }

        public async Task<IEnumerable<Project>> ListAsync()
        {
            return await _projectRepository.ListAsync();

        }

        public async Task<IEnumerable<Project>> ListByPlayListId(int playListId)
        {
            return await _projectRepository.FindByPlayListId(playListId);

        }

        public async Task<ProjectResponse> RemoveProject(int id)
        {
            //Validar projectId
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
                return new ProjectResponse($"An error ocurred while removing the project: {e.Message}");
            }


        }

        public async Task<ProjectResponse> SaveProject(Project project)
        {
            //Validate playListId
            var existingplayListId = _playListRepository.FindById(project.Id);

            if (existingplayListId == null)
                return new ProjectResponse("Invalid Play List");


            try
            {
                await _projectRepository.AddProject(project);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(project);
            }
            catch (Exception e)
            {
                return new ProjectResponse($"An error ocurred while saving the project: {e.Message}");
            }





        }

        public async Task<ProjectResponse> UpdateProject(int id, Project project)
        {
            //Validar projectId
            var existingProject = await _projectRepository.FindById(project.Id);

            if (existingProject == null)
                return new ProjectResponse("Project not found");

            //Validar playListID

            var existingplayList = await _playListRepository.FindById(project.PlayListId);

            if (existingplayList == null)
                return new ProjectResponse("Play List not found");


            existingProject.Description = project.Description;
            existingProject.AddedDate = project.AddedDate;

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
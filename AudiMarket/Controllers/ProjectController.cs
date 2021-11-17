using AudiMarket.Domain.Models;
using AudiMarket.Domain.Services;
using using AudiMarket.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Controllers
{
    [Route("/api/v1/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Project>> GetAllProject()
        {
            var projects = await _projectService.GetAll();
            var resources = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectResource>>(projects);
            return projects;
        }

        [HttpPost]
        public async Task<IActionResult> PostProject([FromBody] ProjectResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var project = _mapper.Map<ProjectResource, Project>(resource);
            var result = await _projectService.SaveProject(project);

            if (!result.Success)
                return BadRequest(result.Message);

            var projectResource = _mapper.Map<Project, ProjectResource>(result.Resource);
            return Ok(projectResource);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, [FromBody] ProjectResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var project = _mapper.Map<ProjectResource, Project>(resource);
            var result = await _projectService.UpdateProject(id, project);

            if (!result.Success)
                return BadRequest(result.Message);

            var projectResource = _mapper.Map<Project, projectResource>(result.Resource);
            return Ok(projectResource);

        }

        [HttpGet("{getByPlayListID}")]
        public async Task<IEnumerable<ProjectResource>> GetAllByPlayList(int playListId)
        {
            var projects = await _projectService.ListByPlayListId(playListId);
            var resources = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectResource>>(projects);
            return resources;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _projectService.DeleteProject(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var projectResource = _mapper.Map<Project, ProjectResource>(result.Resource);
            return Ok(projectResource);

        }
    }
}
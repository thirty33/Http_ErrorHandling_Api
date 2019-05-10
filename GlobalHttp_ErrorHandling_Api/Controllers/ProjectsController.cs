using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobalHttp_ErrorHandling_Api.Domain.Services_Interfaces;
using GlobalHttp_ErrorHandling_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlobalHttp_ErrorHandling_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IEnumerable<Project>> getProjects()
        {
            var projects = await _projectService.GetAllProjects();
            return projects;
        }

        [HttpGet("getbyname/{name}")]
        public async Task<IEnumerable<Project>> getProjectsByName(string name)
        {
            var projects = await _projectService.GetProjectsByName(name);
            return projects;
        }
    }
}

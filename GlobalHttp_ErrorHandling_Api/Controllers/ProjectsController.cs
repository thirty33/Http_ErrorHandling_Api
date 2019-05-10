using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobalHttp_ErrorHandling_Api.Domain.Service_Response;
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
        public async Task<ProjectServiceResponse> getProjectsByName(string name)
        {
            try
            {
                var projects = await _projectService.GetProjectsByName(name);
                if (projects == null || projects.Count() == 0)
                    return new ProjectServiceResponse("No se encontraron elementos");
                return new ProjectServiceResponse(projects);
            }
            catch(Exception e)
            {
                return new ProjectServiceResponse("Intenal server Error");
            }
        }

        //Other Implementation
        //[HttpGet("getproduct/{name}")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(500)]
        //public async Task<IActionResult> GetStockItemAsync(string name)
        //{

        //}
    }
}

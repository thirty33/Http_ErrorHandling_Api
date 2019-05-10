using GlobalHttp_ErrorHandling_Api.Domain.Repositories_Interfaces;
using GlobalHttp_ErrorHandling_Api.Domain.Services_Interfaces;
using GlobalHttp_ErrorHandling_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalHttp_ErrorHandling_Api.Services
{
    public class ProjectServices : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectServices(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await _projectRepository.ListAsync();
        }

        public async Task<IEnumerable<Project>> GetProjectsByName(string name)
        {
            return await _projectRepository.FilterByName(name);
        }
    }
}

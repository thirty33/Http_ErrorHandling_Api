using GlobalHttp_ErrorHandling_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalHttp_ErrorHandling_Api.Domain.Services_Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjects();
        Task<IEnumerable<Project>> GetProjectsByName(string name);
    }
}

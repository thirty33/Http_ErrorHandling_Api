using GlobalHttp_ErrorHandling_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalHttp_ErrorHandling_Api.Domain.Repositories_Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> ListAsync();
        Task<IEnumerable<Project>> FilterByName(string name);
    }
}

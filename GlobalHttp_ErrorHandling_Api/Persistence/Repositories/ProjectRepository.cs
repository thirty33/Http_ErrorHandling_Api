using GlobalHttp_ErrorHandling_Api.Domain.Repositories_Interfaces;
using GlobalHttp_ErrorHandling_Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalHttp_ErrorHandling_Api.Persistence.Repositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        //Constructor
        public ProjectRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Project>> ListAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<IEnumerable<Project>> FilterByName(string name)
        {
            return await _context.Projects.Where(p => p.Name == name).ToListAsync();
        }
    }
}

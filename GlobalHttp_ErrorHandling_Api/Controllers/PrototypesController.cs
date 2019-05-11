using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using GlobalHttp_ErrorHandling_Api.Persistence;
using GlobalHttp_ErrorHandling_Api.Models;
using GlobalHttp_ErrorHandling_Api.Domain.Services_Interfaces;
using AutoMapper;

namespace GlobalHttp_ErrorHandling_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrototypesController : ControllerBase
    {
        protected readonly ILogger Logger;
        protected readonly AppDbContext _dbContext;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public PrototypesController(ILogger<PrototypesController> logger, AppDbContext dbContext,
                                    IProjectService projectService, IMapper mapper)
        {
             Logger = logger;
            _dbContext = dbContext;
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet("StockItem/{name}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetStockItemsAsync(string name)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetStockItemsAsync));
            var response = new ListResponse<Project>();
            try
            {
                var projects = await _projectService.GetProjectsByName(name);
                if (projects.Count() == 0)
                    response.Message = "No items in stock";
                else
                {
                    IEnumerable<Project> resource = _mapper.Map<IEnumerable<Project>>(projects);
                    response.Model = resource;
                }
                Logger?.LogInformation("The stock items have been retrieved successfully.");
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
                Logger?.LogCritical("There was an error on '{0}' invocation: {1}", nameof(GetStockItemsAsync), ex);
            }
            return response.ToHttpResponse();
        }
    }
}

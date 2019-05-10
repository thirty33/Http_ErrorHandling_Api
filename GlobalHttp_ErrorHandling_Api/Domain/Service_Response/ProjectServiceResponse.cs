using GlobalHttp_ErrorHandling_Api.Models;
using System.Collections.Generic;

namespace GlobalHttp_ErrorHandling_Api.Domain.Service_Response
{
    public class ProjectServiceResponse : BaseResponse
    {
        public IEnumerable<Project> Projects { get; private set; }

        public ProjectServiceResponse(bool success, string message, IEnumerable<Project> _projects) : base(success, message)
        {
            Projects = _projects;
        }

        public ProjectServiceResponse(IEnumerable<Project> _projects) : this(true, string.Empty, _projects)
        { }

        public ProjectServiceResponse(string message) : this(false, message, null)
        { }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalHttp_ErrorHandling_Api.Domain.Service_Response
{
    /// <summary>
    /// Response Models Interfaces
    /// </summary>
    public interface IResponseModel
    {
        string Message { get; set; }
        bool DidError { get; set; }
        string ErrorMessage { get; set; }
    }

    public interface ISingleResponse<TModel> : IResponseModel 
    {
        TModel Model { get; set; }
    }

    public interface IListResponse<TModel> : IResponseModel
    {
        IEnumerable<TModel> Model { get; set; }
    }

    public interface IPagedResponse<TModel> : IListResponse<TModel>
    {
        int ItemsCount { get; set; }

        double PageCount { get; }
    }
}

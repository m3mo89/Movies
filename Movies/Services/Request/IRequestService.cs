using System;
using System.Threading.Tasks;

namespace Movies.Services.Request
{
    public interface IRequestService
    {
        Task<TResult> GetAsync<TResult>(string uri);
    }
}

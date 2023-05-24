using TaskManager.Shared.Models;

namespace TaskManager.Frontend.Repositories
{
    public interface IRespository
    {
        Task<Response<T>> GetAsync<T>(string url);
    }
}

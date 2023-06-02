using TaskManager.Shared.Models;

namespace TaskManager.Frontend.Repositories
{
    public interface IRepository
    {
        Task<Response<T>> GetAsync<T>(string url);
    }
}

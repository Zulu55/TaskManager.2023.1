using System.Text.Json;
using TaskManager.Shared.Models;

namespace TaskManager.Frontend.Repositories
{
    public class Respository : IRespository
    {
        private readonly HttpClient _httpClient;

        public Respository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response<T>> GetAsync<T>(string url)
        {
            var responseHttp = await _httpClient.GetAsync(url);
            if (!responseHttp.IsSuccessStatusCode)
            {
                return new Response<T>
                {
                    IsSuccess = false,
                    Message = "Fail to get results"
                };
            }

            var responseString = await responseHttp.Content.ReadAsStringAsync();
            var responseJson = JsonSerializer.Deserialize<T>(responseString);
            return new Response<T>
            {
                IsSuccess = true,
                Result = responseJson
            };
        }
    }
}

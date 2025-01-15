using GitHubRepoApp.Domain.Interfaces;
using GitHubRepoApp.Domain.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace GitHubRepoApp.Infrastructure.Services
{
    public class GitHubService : IGitHubService
    {
        private readonly HttpClient _httpClient;

        public GitHubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("GitHubRepoApp", "1.0"));
        }

        public async Task<List<RepositoryUser>> GetUserRepositoriesAsync(string username)
        {
            var url = $"https://api.github.com/users/{username}/repos";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to fetch repositories for user {username}. Status Code: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var repositories = JsonSerializer.Deserialize<List<RepositoryUser>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return repositories ?? new List<RepositoryUser>();
        }
    }
}

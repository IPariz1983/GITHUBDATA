
using GitHubRepoApp.Domain.Models;

namespace GitHubRepoApp.Domain.Interfaces
{
    public interface IGitHubService
    {
        Task<List<RepositoryUser>> GetUserRepositoriesAsync(string username);
    }
}

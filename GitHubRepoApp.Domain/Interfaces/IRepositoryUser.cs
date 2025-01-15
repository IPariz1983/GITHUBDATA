using GitHubRepoApp.Domain.Models;

namespace GitHubRepoApp.Domain.Interfaces
{
    public interface IRepositoryUser
    {
        Task SaveOrUpdateRepositoriesAsync(List<RepositoryUser> repositories);
        Task<List<RepositoryUser>> GetRepositoriesByUsernameAsync(string username);
    }
}

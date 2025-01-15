using GitHubRepoApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GitHubRepoApp.Infrastructure.Data.Repositories
{
    public class RepositoryUser : IRepositoryUser
    {
        private readonly AppDbContext _context;

        public RepositoryUser(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveOrUpdateRepositoriesAsync(List<Domain.Models.RepositoryUser> repositories)
        {
            foreach (var repo in repositories)
            {
                var existingRepo = await _context.Repositories
                    .FirstOrDefaultAsync(r => r.Name == repo.Name && r.Username == repo.Username);

                if (existingRepo == null)
                {
                    await _context.Repositories.AddAsync(repo);
                }
                else
                {
                    existingRepo.Description = repo.Description;
                    existingRepo.Url = repo.Url;
                    existingRepo.CreatedAt = repo.CreatedAt;
                    existingRepo.Stars = repo.Stars;
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<Domain.Models.RepositoryUser>> GetRepositoriesByUsernameAsync(string username)
        {
            return await _context.Repositories
                .Where(r => r.Username == username)
                .OrderByDescending(r => r.Stars)
                .ToListAsync();
        }
    }
}


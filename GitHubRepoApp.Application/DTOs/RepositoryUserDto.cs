namespace GitHubRepoApp.Application.DTOs
{
    public class RepositoryUserDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Url { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public int Stars { get; set; }
        public string Username { get; set; } = null!;
    }
}

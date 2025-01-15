namespace GitHubRepoApp.Domain.Models
{
    public class RepositoryUser
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Url { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public int Stars { get; set; }
        public string Username { get; set; } = null!;
    }
}

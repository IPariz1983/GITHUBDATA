using AutoMapper;
using GitHubRepoApp.Application.DTOs;
using GitHubRepoApp.Domain.Interfaces;

namespace GitHubRepoApp.Application.UseCases
{
    public class GetRepositoriesUseCase
    {
        private readonly IRepositoryUser _repositoryUser;
        private readonly IMapper _mapper; 

        public GetRepositoriesUseCase(IRepositoryUser repositoryRepository, IMapper mapper)
        {
            _repositoryUser = repositoryRepository;
            _mapper = mapper;
        }

        public async Task<List<RepositoryUserDto>> ExecuteAsync(string username)
        {
            try
            {
                var repositories = await _repositoryUser.GetRepositoriesByUsernameAsync(username);

                if (repositories == null || repositories.Count == 0)
                {
                    return new List<RepositoryUserDto>(); // Retorna lista vazia
                }

                // Usa o AutoMapper para mapear a lista de entidades para DTOs
                var repositoriesDto = _mapper.Map<List<RepositoryUserDto>>(repositories);

                return repositoriesDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter repositórios: {ex.Message}");
                throw; // Re-lança a exceção
            }
        }
    }
}
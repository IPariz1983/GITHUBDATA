using AutoMapper;
using GitHubRepoApp.Domain.Interfaces;
using GitHubRepoApp.Domain.Models;

namespace GitHubRepoApp.Application.UseCases
{
    public class SyncRepositoriesUseCase
    {
        private readonly IGitHubService _gitHubService;
        private readonly IRepositoryUser _repositoryRepositoryUser;
        private readonly IMapper _mapper;

        public SyncRepositoriesUseCase(IGitHubService gitHubService, IRepositoryUser repositoryRepository, IMapper mapper)
        {
            _gitHubService = gitHubService;
            _repositoryRepositoryUser = repositoryRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(string username)
        {
            try
            {
                var repositoriesDto = await _gitHubService.GetUserRepositoriesAsync(username);

                if (repositoriesDto != null)
                {
                    var lstRepository = new List<RepositoryUser>();
                    foreach (var repoDto in repositoriesDto)
                    {
                        //Mapeando o nome do usuario para o DTO
                        repoDto.Username= username;

                        var repository = _mapper.Map<RepositoryUser>(repoDto);
                        lstRepository.Add(repository);
                    }
                    await _repositoryRepositoryUser.SaveOrUpdateRepositoriesAsync(lstRepository);
                }
                else
                {
                    //Tratar caso em que não retorna repositórios
                    throw new Exception("Não foram encontrados repositórios para o usuário informado");
                }

            }
            catch (HttpRequestException ex)
            {
                // Tratar erros de requisição HTTP (ex: 404, 500)
                throw new Exception($"Erro ao acessar a API do GitHub: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Tratar outros erros
                throw new Exception($"Erro ao sincronizar repositórios: {ex.Message}");
            }
        }
    }
}

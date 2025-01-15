using GitHubRepoApp.Application.UseCases; // Importe os namespaces dos Use Cases
using Microsoft.AspNetCore.Mvc;

namespace GitHubRepoApp.Controllers
{
    [Route("repos")]
    [ApiController]
    public class RepositoriesController : ControllerBase // Nome do controller mais descritivo
    {
        private readonly SyncRepositoriesUseCase _syncRepositoriesUseCase;
        private readonly GetRepositoriesUseCase _getRepositoriesUseCase;

        public RepositoriesController(SyncRepositoriesUseCase syncRepositoriesUseCase, GetRepositoriesUseCase getRepositoriesUseCase)
        {
            _syncRepositoriesUseCase = syncRepositoriesUseCase;
            _getRepositoriesUseCase = getRepositoriesUseCase;
        }

        [HttpPost("sync/{username}")]
        public async Task<IActionResult> SyncRepositories(string username)
        {
            try
            {
                await _syncRepositoriesUseCase.ExecuteAsync(username);
                return Ok(); // Retorna 200 OK em caso de sucesso
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, $"Internal Server Error: {ex.Message}"); // Retorna 500 com mensagem de erro
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetRepositories(string username)
        {
            try
            {
                var repositories = await _getRepositoriesUseCase.ExecuteAsync(username);
                return Ok(repositories);
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, $"Internal Server Error: {ex.Message}"); // Retorna 500 com mensagem de erro
            }
        }
    }
}
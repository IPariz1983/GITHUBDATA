using AutoMapper;
using GitHubRepoApp.Application.DTOs;
using GitHubRepoApp.Domain.Models;

namespace GitHubRepoApp.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RepositoryUser, RepositoryUserDto>();
            CreateMap<RepositoryUserDto, RepositoryUser>();
        }
    }
}

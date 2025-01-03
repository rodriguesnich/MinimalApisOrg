using MinApiOrg.Api.Domain.Entities;
using MinApiOrg.Api.Infrastructure.Repository;

namespace MinApiOrg.Api.Application.UseCases;

public class GetProjectUseCase
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectUseCase(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public Project? Execute(Guid id)
    {
        return _projectRepository.GetById(id);
    }
}

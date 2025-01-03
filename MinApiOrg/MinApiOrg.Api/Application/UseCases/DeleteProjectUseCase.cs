using MinApiOrg.Api.Infrastructure.Repository;

namespace MinApiOrg.Api.Application.UseCases;

public class DeleteProjectUseCase
{
    private readonly IProjectRepository _projectRepository;

    public DeleteProjectUseCase(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public bool Execute(Guid id)
    {
        var project = _projectRepository.GetById(id);
        if (project == null) return false;

        _projectRepository.Remove(project);
        return true;
    }
}

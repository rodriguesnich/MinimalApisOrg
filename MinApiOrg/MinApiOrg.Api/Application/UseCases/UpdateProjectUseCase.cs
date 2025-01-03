using MinApiOrg.Api.Domain.Entities;
using MinApiOrg.Api.Infrastructure.Repository;

namespace MinApiOrg.Api.Application.UseCases;

public class UpdateProjectUseCase
{
    private readonly IProjectRepository _projectRepository;

    public UpdateProjectUseCase(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public Project? Execute(Guid id, string name, DateTime startDate, DateTime? endDate)
    {
        var project = _projectRepository.GetById(id);
        if (project == null) return null;

        project.Name = name;
        project.StartDate = startDate;
        project.EndDate = endDate;

        _projectRepository.Update(project);
        return project;
    }
}

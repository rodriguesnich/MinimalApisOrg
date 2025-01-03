
using MinApiOrg.Api.Domain.Entities;
using MinApiOrg.Api.Infrastructure.Repository;

namespace MinApiOrg.Api.Application.UseCases;

public class CreateProjectUseCase
{
 private readonly IProjectRepository _projectRepository;

    public CreateProjectUseCase(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public Project Execute(string name, DateTime startDate, DateTime? endDate = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Project name cannot be empty.");

        var project = new Project(name, startDate, endDate);
        _projectRepository.Add(project);
        return project;
    }
}

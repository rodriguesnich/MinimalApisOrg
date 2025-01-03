using System;
using MinApiOrg.Api.Domain.Entities;
using MinApiOrg.Api.Infrastructure.Repository;

namespace MinApiOrg.Api.Application.UseCases;

public class ListProjectUseCase
{
    private readonly IProjectRepository _projectRepository;

    public ListProjectUseCase(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public IEnumerable<Project> Execute()
    {
        return _projectRepository.GetAll();
    }
}

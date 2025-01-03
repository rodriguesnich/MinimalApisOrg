
using MinApiOrg.Api.Domain.Entities;

namespace MinApiOrg.Api.Infrastructure.Repository;

public class InMemoryProjectRepository : IProjectRepository
{
    private readonly List<Project> _projects = new();

    public void Add(Project project) => _projects.Add(project);

    public Project GetById(Guid id) => _projects.FirstOrDefault(p => p.Id == id);

    public void Remove(Project project) => _projects.Remove(project);

    public void Update(Project project)
    {
        var index = _projects.FindIndex(p => p.Id == project.Id);
        if (index >= 0) _projects[index] = project;
    }

    public IEnumerable<Project> GetAll() => _projects;
}

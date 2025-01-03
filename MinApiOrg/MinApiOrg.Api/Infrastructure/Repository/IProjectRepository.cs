
using MinApiOrg.Api.Domain.Entities;

namespace MinApiOrg.Api.Infrastructure.Repository;

public interface IProjectRepository
{
    void Add(Project project);
    Project GetById(Guid id);
    void Remove(Project project);
    void Update(Project project);
    IEnumerable<Project> GetAll();
}

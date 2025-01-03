using Microsoft.EntityFrameworkCore;
using MinApiOrg.Api.Domain.Entities;
using MinApiOrg.Api.Infrastructure.Repository;

namespace MinApiOrg.Api.Infrastructure.Repository;

public class SqliteProjectRepository : IProjectRepository
{
    private readonly ApplicationDbContext _context;

    public SqliteProjectRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Project project)
    {
        _context.Projects.Add(project);
        _context.SaveChanges();
    }

    public Project GetById(Guid id)
    {
        return _context.Projects.FirstOrDefault(p => p.Id == id);
    }

    public void Remove(Project project)
    {
        _context.Projects.Remove(project);
        _context.SaveChanges();
    }

    public void Update(Project project)
    {
        _context.Projects.Update(project);
        _context.SaveChanges();
    }

    public IEnumerable<Project> GetAll()
    {
        return _context.Projects.ToList();
    }
}

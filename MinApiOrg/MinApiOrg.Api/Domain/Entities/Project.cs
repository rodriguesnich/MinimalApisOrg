
namespace MinApiOrg.Api.Domain.Entities;

public class Project
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }

    // Constructor to initialize the project
    public Project(string name, DateTime startDate, DateTime? endDate = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Project name cannot be empty.");

        Id = Guid.NewGuid();
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
    }

    // Method to set the end date
    public void Complete(DateTime endDate)
    {
        EndDate = endDate;
    }
}

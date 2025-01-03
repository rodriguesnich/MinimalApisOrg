namespace MinApiOrg.Api.Domain.Models.Request;

public class UpdateProjectRequest
{
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

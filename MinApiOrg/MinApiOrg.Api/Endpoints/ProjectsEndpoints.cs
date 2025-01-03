
using MinApiOrg.Api.Application.UseCases;
using MinApiOrg.Api.Domain.Models.Request;

namespace MinApiOrg.Api.Endpoints;

public static class ProjectsEndpoints
{
    public static void MapProjectEndPoints(this WebApplication app)
    {
        var projectGroup = app.MapGroup("/project").WithTags("Project").WithOpenApi();

        projectGroup.MapPost("/", async (CreateProjectRequest request, CreateProjectUseCase createProjectUseCase) =>
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Name))
                    return Results.BadRequest("Project name cannot be empty.");

                var project = createProjectUseCase.Execute(request.Name, request.StartDate, request.EndDate);
                
                return Results.Created($"/projects/{project.Id}", project);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });
 
        projectGroup.MapDelete("/{id}", async (Guid id, DeleteProjectUseCase deleteProjectUseCase) =>
        {
            var success = deleteProjectUseCase.Execute(id);
            return success ? Results.NoContent() : Results.NotFound();
        });
    }
}

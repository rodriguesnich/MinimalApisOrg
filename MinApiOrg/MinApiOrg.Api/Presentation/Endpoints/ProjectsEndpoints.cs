using MinApiOrg.Api.Application.UseCases;
using MinApiOrg.Api.Presentation.Dtos.Request;
using MinApiOrg.Api.Presentation.Dtos.Response;

namespace MinApiOrg.Api.Presentation.Endpoints;

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

        projectGroup.MapGet("/", async (ListProjectUseCase listProjectUseCase) =>
        {
            var projects = listProjectUseCase.Execute();
            return Results.Ok(projects.Select(p => new ProjectResponse
            {
                Id = p.Id,
                Name = p.Name,
                StartDate = p.StartDate,
                EndDate = p.EndDate
            }));
        });

        projectGroup.MapGet("/{id}", async (Guid id, GetProjectUseCase getProjectUseCase) =>
        {
            var project = getProjectUseCase.Execute(id);
            if (project == null) return Results.NotFound();

            return Results.Ok(new ProjectResponse
            {
                Id = project.Id,
                Name = project.Name,
                StartDate = project.StartDate,
                EndDate = project.EndDate
            });
        });

        projectGroup.MapPut("/{id}", async (Guid id, UpdateProjectRequest request, UpdateProjectUseCase updateProjectUseCase) =>
                {
                    try
                    {
                        if (string.IsNullOrWhiteSpace(request.Name))
                            return Results.BadRequest("Project name cannot be empty.");

                        var project = updateProjectUseCase.Execute(id, request.Name, request.StartDate, request.EndDate);
                        if (project == null) return Results.NotFound();

                        return Results.Ok(new ProjectResponse
                        {
                            Id = project.Id,
                            Name = project.Name,
                            StartDate = project.StartDate,
                            EndDate = project.EndDate
                        });
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

namespace MinApiOrg.Api.Endpoints;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this WebApplication app)
    {
        var categoryGroup = app.MapGroup("/category").WithTags("Category").WithOpenApi();

        categoryGroup.MapGet("/", () => "List Categories").WithName("ListCategories");
        categoryGroup.MapGet("/{id}", (int id) => $"Get Category by Id: {id}").WithName("GetCategoryById");
        categoryGroup.MapPost("/", () => "Create Category").WithName("CreateCategory");
        categoryGroup.MapPut("/{id}", (int id) => $"Update Category by Id: {id}").WithName("UpdateCategoryById");
        categoryGroup.MapDelete("/{id}", (int id) => $"Delete Category by Id: {id}").WithName("DeleteCategoryById");
    }
}
using MinApiOrg.Api.Application.UseCases;
using MinApiOrg.Api.Presentation.Endpoints;
using MinApiOrg.Api.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProjectRepository, SqliteProjectRepository>();
builder.Services.AddTransient<CreateProjectUseCase>();
builder.Services.AddTransient<UpdateProjectUseCase>();
builder.Services.AddTransient<GetProjectUseCase>();
builder.Services.AddTransient<ListProjectUseCase>();
builder.Services.AddTransient<DeleteProjectUseCase>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapCategoryEndpoints();
app.MapWeatherEndpoints();
app.MapProjectEndPoints();

app.Run();

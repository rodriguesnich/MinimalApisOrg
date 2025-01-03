
using MinApiOrg.Api.Application.UseCases;
using MinApiOrg.Api.Endpoints;
using MinApiOrg.Api.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IProjectRepository, InMemoryProjectRepository>();
builder.Services.AddTransient<CreateProjectUseCase>();
builder.Services.AddTransient<DeleteProjectUseCase>();

var app = builder.Build();

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

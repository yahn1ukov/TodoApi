using TodoApi.Api;
using TodoApi.Api.Middleware;
using TodoApi.Application;
using TodoApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.UseCors(policy => policy
        .AllowCredentials()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("http://localhost:3000"));
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
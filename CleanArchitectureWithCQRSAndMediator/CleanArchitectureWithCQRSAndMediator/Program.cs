using CleanArchitectureWithCQRSAndMediator.Applcation;
using CleanArchitectureWithCQRSAndMediator.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Initialze layers

builder.Services.AddApplicationService();
builder.Services.AddInfrastructureService(builder.Configuration);

#endregion

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

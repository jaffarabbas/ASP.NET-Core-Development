using GenericRepositoryPatternApi.Models;
using GenericRepositoryPatternApi.Repository;
using GenericRepositoryPatternApi.Repository.UOW;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

#region database initialization

// database configuration
builder.Services.AddDbContext<DbJewelsiteContext>(options =>
{

    options.UseSqlServer(builder.Configuration.GetConnectionString("connection"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

#endregion 

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

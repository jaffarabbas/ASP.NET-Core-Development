using SalesOrderApi.Models;
using Microsoft.EntityFrameworkCore;
using SalesOrderApi.Repository;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Sales_DBContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("connection"));
});

//implementing interfaces
builder.Services.AddTransient<ICustomerRepository,CustomerRespository>();
builder.Services.AddTransient<IInvoiceRepository,InvoiceRepository>();
var autoMapper = new MapperConfiguration(item=>item.AddProfile(new MappingProfile()));
IMapper mapper = autoMapper.CreateMapper();
builder.Services.AddSingleton(mapper);
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


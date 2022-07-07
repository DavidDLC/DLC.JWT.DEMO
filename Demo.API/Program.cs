using JWT.Business.Contracts;
using JWT.Models.Data;
using JWT.Repository.Contracts;
using JWT.Repository.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container

// DI for Repository
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

// DI for business Service
builder.Services.AddScoped<IUserManagementService,IUserManagementService>();

//EF SQL configuration
builder.Services.AddDbContext<JWTAuthenticationContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

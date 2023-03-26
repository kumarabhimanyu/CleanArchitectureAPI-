using CleanArchitectureAPI.Domain.Data;
using CleanArchitectureAPI.Domain.Models;
using CleanArchitectureAPI.Repository.IRepository;
using CleanArchitectureAPI.Repository.Repository;
using CleanArchitectureAPI.Service.ICustomServices;
using CleanArchitectureAPI.Service.Models;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.CustomServices;

var builder = WebApplication.CreateBuilder(args);

//Sql Dependency Injection
builder.Services.AddDbContext<CleanArchitectureAPIDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inject Service Dependency Modified
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICustomService<StudentServiceModel>, StudentService>();
builder.Services.AddScoped<ICustomService<Teacher>, TeacherService>();

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

using CleanArchitectureAPI.API.Extensions;
using CleanArchitectureAPI.Domain.Data;
using CleanArchitectureAPI.Repository.IRepository;
using CleanArchitectureAPI.Repository.Repository;
using CleanArchitectureAPI.Service.ICustomServices;
using CleanArchitectureAPI.Service.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ServiceLayer.CustomServices;
using ILogger = Serilog.ILogger;

var builder = WebApplication.CreateBuilder(args);

//Sql Dependency Injection
builder.Services.AddDbContext<CleanArchitectureAPIDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

// Add services to the container. - ToDo, is there a better way to add mapper
builder.Services.AddAutoMapper(typeof(StudentService));
builder.Services.AddAutoMapper(typeof(TeacherService));

builder.Host.UseSerilog((context, configuration) 
    => configuration.ReadFrom.Configuration(context.Configuration));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inject Service Dependency Modified
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICustomService<StudentServiceModel>, StudentService>();
builder.Services.AddScoped<ICustomService<TeacherServiceModel>, TeacherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
var logger = app.Services.GetRequiredService<ILogger>();
//app.ConfigureExceptionHandler(logger);

app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using JWTLoginAPI;
using JWTLoginAPI.Interface;
using JWTLoginAPI.Models;
using JWTLoginAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddLog4Net(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Log4Net.config"));
// Add services to the container.

builder.Services.AddControllers();
Config.ConfigureServices(builder.Services);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BootcampContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDBConnection"));

});
var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();
app.MapControllers();
app.UseCors("JWTLoginCors");
app.Run();

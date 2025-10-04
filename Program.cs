using Microsoft.EntityFrameworkCore;
using ChallengeAPI.Models;
using ChallengeAPI.Interfaces;
using ChallengeAPI.Services;
using ChallengeAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MetadadosDeImagemContext>(opt =>
    opt.UseInMemoryDatabase("MetadadosDeImagemList"));

builder.Services.AddScoped<IMetadadosDeImagemService, MetadadosDeImagemService>();
builder.Services.AddScoped<IMetadadosDeImagemRepository, MetadadosDeImagemRepository>();

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

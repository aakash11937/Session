
using Session1.Repository.InterfaceRepo;
using Session1.Repository.implementation;
using SessionOne.Middleware;
using Microsoft.EntityFrameworkCore;
using System;
using Persistence_Layer;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddLogging();

// Add services to the container.

//builder.Services.AddScoped<ISessionOne, SessionOne>();
builder.Services.AddScoped<ISessionOne,SessionOneRepository >();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseGlobalExceptionHandlercs();
app.MapControllers();

app.Run();

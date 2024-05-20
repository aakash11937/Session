using ApplicationLayer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Persistence_Layer;
using Serilog;
using SessionTwo.Repository.Implimentaion;
using SessionTwo.Repository.Interface;
using SessionTwo.SwaggerHelper;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerVersionedApiExplorer();


//configure Serilog at the entry point of our Application
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IEmployeeServies, EmployeeServies>();                    // Assuming EmployeeServies implements IEmployeeServies


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
// Add AutoMapper 
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddApplicationServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
builder.Services.AddApplicationServices();
builder.Services.AddSwaggerVersionedApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
IApiVersionDescriptionProvider provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
       options =>
       {
           foreach (var description in provider.ApiVersionDescriptions)
           {
               options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
           }
       });
}




//configure Serilog at the entry point of our Application



app.UseHttpsRedirection();

app.UseAuthorization();
app.UseSerilogRequestLogging();

app.MapControllers();

app.Run();

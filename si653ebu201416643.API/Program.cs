using si653ebu201416643.API.Painting.Domain.Repositories;
using si653ebu201416643.API.Painting.Domain.Services;
using si653ebu201416643.API.Painting.Persistence.Repositories;
using si653ebu201416643.API.Painting.Services;

using si653ebu201416643.API.Training.Domain.Repositories;
using si653ebu201416643.API.Training.Domain.Services;
using si653ebu201416643.API.Training.Persistence.Repositories;
using si653ebu201416643.API.Training.Services;

using si653ebu201416643.API.Shared.Domain.Repositories;
using si653ebu201416643.API.Shared.Persistence.Contexts;
using si653ebu201416643.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
    {
        // Add API Documentation Information
        
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "MAGnet Authors API",
            Description = "MAGnet Authors RESTful API",
            TermsOfService = new Uri("https://magnet-authors.com/tos"),
            Contact = new OpenApiContact
            {
                Name = "magnet.studio",
                Url = new Uri("https://magnet.studio")
            },
            License = new OpenApiLicense
            {
                Name = "MAGnet Authors Resources License",
                Url = new Uri("https://magnet-authors.com/license")
            }
        });
        options.EnableAnnotations();
    });

// Add Database Connection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Database Connection with Standard Level for Information and Errors

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));

// Add lowercase routes

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Shared Injection Configuration

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Authors Injection Configuration

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

// AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(si653ebu201416643.API.Painting.Mapping.ModelToResourceProfile),
    typeof(si653ebu201416643.API.Painting.Mapping.ResourceToModelProfile),
    typeof(si653ebu201416643.API.Training.Mapping.ModelToResourceProfile),
    typeof(si653ebu201416643.API.Training.Mapping.ResourceToModelProfile));


var app = builder.Build();

// Validation for ensuring Database Objects are created

using (var scope = app.Services.CreateScope())

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("v1/swagger.json", "v1");
            options.RoutePrefix = "swagger";
        });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
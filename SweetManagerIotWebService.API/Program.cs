using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;
using SweetManagerIotWebService.API.Shared.Domain.Repositories;
using SweetManagerIotWebService.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using SweetManagerIotWebService.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerIotWebService.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using System.Data;
using SweetManagerIotWebService.API.Inventory.Application.Internal.CommandServices;
using SweetManagerIotWebService.API.Inventory.Application.Internal.QueryServices;
using SweetManagerIotWebService.API.Inventory.Domain.Repositories;
using SweetManagerIotWebService.API.Inventory.Domain.Services;
using SweetManagerIotWebService.API.Inventory.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Database Configuration
// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("SweetManager");

builder.Services.AddTransient<IDbConnection>(db => new MySqlConnection(connectionString));

var connectionStringFromEnvironment = Environment.GetEnvironmentVariable("SweetManagerDbConnection");

if (connectionStringFromEnvironment != null)
{
    connectionString = connectionStringFromEnvironment;
}

// Configure Database Context and Logging Levels
builder.Services.AddDbContext<SweetManagerContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
    });

#endregion

#region OPENAPI Configuration
// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "Sweet Manager API",
                Version = "v1",
                Description = "Sweet Manager API",
                TermsOfService = new Uri("https://acme-learning.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "Sweet Manager Studios",
                    Email = "contact@swm.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer", Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            }
        });
    });

#endregion

builder.Services.AddHttpContextAccessor();

#region Dependency Injection

// IAM Bounded context


// Reservations bounded context


// Commerce Bounded context


// Inventory Bounded Context
builder.Services.AddScoped<ISupplyRepository, SupplyRepository>(); 
builder.Services.AddScoped<ISupplyCommandService, SupplyCommandService>();
builder.Services.AddScoped<ISupplyQueryService, SupplyQueryService>();

builder.Services.AddScoped<ISupplyRequestRepository, SupplyRequestRepository>();
builder.Services.AddScoped<ISupplyRequestCommandService, SupplyRequestCommandService>();
builder.Services.AddScoped<ISupplyRequestQueryService, SupplyRequestQueryService>();
// Communication Bounded context



// Organizational Management Bounded context



// Shared Bounded context
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion

#region JWT Configuration

// In progress

#endregion

var app = builder.Build();

#region Ensure Database Created (COMPILE AppDbContext)
// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<SweetManagerContext>();
    context.Database.EnsureCreated();
}

#endregion

#region Run DatabaseInitializer
using (var scope = app.Services.CreateScope())
{
    // In progress
}
#endregion

// Configuration cors
app.UseCors(
    b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
);

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
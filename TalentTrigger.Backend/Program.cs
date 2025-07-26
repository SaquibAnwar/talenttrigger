using Microsoft.EntityFrameworkCore;
using Hangfire;
using Hangfire.PostgreSql;
using TalentTrigger.Backend.Data;
using TalentTrigger.Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register ApplicationDbContext with PostgreSQL (only if connection string is available)
var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (!string.IsNullOrEmpty(dbConnectionString))
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(dbConnectionString));
}

// Configure Hangfire with PostgreSQL (only if connection string is available)
// Temporarily disabled to test database connection
/*
var hangfireConnectionString = builder.Configuration.GetSection("Hangfire:ConnectionString").Value;
if (!string.IsNullOrEmpty(hangfireConnectionString))
{
    builder.Services.AddHangfire(config =>
        config.UsePostgreSqlStorage(options =>
            options.UseNpgsqlConnection(hangfireConnectionString)));
    
    // Add Hangfire server
    builder.Services.AddHangfireServer();
}
*/

// Register background services (as backup)
builder.Services.AddHostedService<JobScrapingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable Hangfire dashboard (only if Hangfire is configured)
// Temporarily disabled to test database connection
/*
if (!string.IsNullOrEmpty(builder.Configuration.GetSection("Hangfire:ConnectionString").Value))
{
    app.UseHangfireDashboard();
}
*/

app.UseAuthorization();

app.MapControllers();

app.Run();

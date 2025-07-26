using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TalentTrigger.Backend.Services;

public class JobScrapingService : BackgroundService
{
    private readonly ILogger<JobScrapingService> _logger;
    private readonly IServiceProvider _serviceProvider;

    public JobScrapingService(ILogger<JobScrapingService> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Job Scraping Service is starting.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _logger.LogInformation("Running job scraping task at: {time}", DateTimeOffset.Now);
                
                // TODO: Implement actual job scraping logic here
                // For now, just log that we would scrape jobs
                await Task.Delay(TimeSpan.FromMinutes(15), stoppingToken); // Run every 15 minutes
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Job Scraping Service is stopping.");
                break;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while running job scraping task.");
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken); // Wait 1 minute before retrying
            }
        }
    }
} 
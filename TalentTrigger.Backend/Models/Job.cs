using System.ComponentModel.DataAnnotations;

namespace TalentTrigger.Backend.Models;

public class Job
{
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string CompanyName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(500)]
    public string Title { get; set; } = string.Empty;
    
    [MaxLength(200)]
    public string? Location { get; set; }
    
    public int? ExperienceRequired { get; set; }
    
    [Required]
    [MaxLength(1000)]
    public string Url { get; set; } = string.Empty;
    
    public DateTime? PostedAt { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
} 
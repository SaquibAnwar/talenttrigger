using System.ComponentModel.DataAnnotations;

namespace TalentTrigger.Backend.Models;

public class Watch
{
    public Guid Id { get; set; }
    
    [Required]
    public Guid UserId { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string CompanyName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(200)]
    public string RoleKeyword { get; set; } = string.Empty;
    
    public int? MinYoE { get; set; }
    
    public int? MaxYoE { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
} 
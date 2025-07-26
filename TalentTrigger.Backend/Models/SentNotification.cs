using System.ComponentModel.DataAnnotations;

namespace TalentTrigger.Backend.Models;

public class SentNotification
{
    public Guid Id { get; set; }
    
    [Required]
    public Guid UserId { get; set; }
    
    [Required]
    public Guid JobId { get; set; }
    
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public Watch? Watch { get; set; }
    public Job? Job { get; set; }
} 
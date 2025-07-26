using Microsoft.EntityFrameworkCore;
using TalentTrigger.Backend.Models;

namespace TalentTrigger.Backend.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Watch> Watches { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<SentNotification> SentNotifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Watch entity
        modelBuilder.Entity<Watch>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CompanyName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.RoleKeyword).IsRequired().HasMaxLength(200);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        // Configure Job entity
        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CompanyName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.Url).IsRequired().HasMaxLength(1000);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        // Configure SentNotification entity
        modelBuilder.Entity<SentNotification>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.SentAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            
            // Configure relationships
            entity.HasOne(e => e.Job)
                  .WithMany()
                  .HasForeignKey(e => e.JobId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
} 
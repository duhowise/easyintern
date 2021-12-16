using EasyIntern.Model;
using Microsoft.EntityFrameworkCore;

namespace EasyIntern.Context;

public class InternContext:DbContext
{
    public InternContext(DbContextOptions<InternContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            var dateTimeProps = entity.GetProperties()
                .Where(p => p.PropertyInfo?.PropertyType == typeof(string));
            foreach (var prop in dateTimeProps)
            {
                modelBuilder.Entity(entity.Name).Property(prop.Name).HasMaxLength(35);
            }

        }

        modelBuilder.Entity<InternshipAdvertisement>(entity =>
        {
            entity.OwnsOne(x => x.InternshipPeriod);
            entity.Property(x => x.Description).HasMaxLength(5000);
        });

        modelBuilder.Entity<Internship>(entity =>
        {
            entity.HasMany(x => x.Applications);
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Intern> Interns { get; set; }
    public DbSet<Internship> Internships { get; set; }
    public DbSet<InternshipAdvertisement> InternshipAdvertisements { get; set; }
    public DbSet<Organisation> Organisations { get; set; }
    public DbSet<InternshipApplication> InternshipApplications { get; set; }
    public DbSet<Position> InternshipPositions { get; set; }
}
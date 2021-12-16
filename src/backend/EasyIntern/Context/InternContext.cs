using EasyIntern.Model;
using Microsoft.EntityFrameworkCore;

namespace EasyIntern.Context;

public class InternContext:DbContext
{
    public InternContext(DbContextOptions<InternContext> options):base(options)
    {
        
    }
    public DbSet<Intern> Interns { get; set; }
    public DbSet<Internship> Internships { get; set; }
    public DbSet<InternshipAdvertisement> InternshipAdvertisements { get; set; }
    public DbSet<Organisation> Organisations { get; set; }
    public DbSet<InternshipApplication> InternshipApplications { get; set; }
    public DbSet<Position> InternshipPositions { get; set; }
}
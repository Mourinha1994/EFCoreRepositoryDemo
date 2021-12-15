using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}

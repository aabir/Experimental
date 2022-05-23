using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PostGreBE.Entity;

namespace PostGreBE.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> patients { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Tutorial> Tutorials { get; set; }
        public DbSet<Monster> Monsters { get; set; }

    }
}

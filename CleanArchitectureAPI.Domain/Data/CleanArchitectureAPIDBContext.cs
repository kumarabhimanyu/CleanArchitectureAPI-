using CleanArchitectureAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureAPI.Domain.Data
{
    public class CleanArchitectureAPIDBContext : DbContext
    {
        public CleanArchitectureAPIDBContext(DbContextOptions<CleanArchitectureAPIDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public CleanArchitectureAPIDBContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=KELLGGNLPTP1078\SQLEXPRESS;Database=CleanArchitectureAPI;Trusted_Connection=True;TrustServerCertificate=True;");

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using VotingAppApi.Model;

namespace VotingAppApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vote>()
                .HasIndex(v => v.VoterId)
                .IsUnique(); // one vote per voter

            base.OnModelCreating(modelBuilder);
        }
    }

}

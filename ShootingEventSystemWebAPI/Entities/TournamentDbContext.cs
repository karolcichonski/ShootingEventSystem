using Microsoft.EntityFrameworkCore;

namespace ShootingEventSystemWebAPI.Entities
{
    public class TournamentDbContext:DbContext
    {
        private string _connectionString =
            "Server=(localdb)\\MSSQLLocalDB;Database=TournamentDb;Trusted_Connection=True;";
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Arbiter> Arbiters { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Competitor> Competitors { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(r => r.Street)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Club>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<Competition>()
                .Property(r=>r.Name)
                .IsRequired();
            
            modelBuilder.Entity<Result>()
                .Property(r => r.Score)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Result>()
                .Property(r => r.PenaltyPoints)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Competition>()
                .Property(c => c.MaxScore)
                .HasPrecision(6, 2);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}

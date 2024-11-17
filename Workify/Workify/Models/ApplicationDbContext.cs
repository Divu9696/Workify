using Microsoft.EntityFrameworkCore;
namespace Workify.Models
{
    public class ApplicationDbContext : DbContext
    {
        

           public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var configSection = configBuilder.GetSection("ConnectionStrings");
            var conStr = configSection["ConStr"] ?? null;

            optionsBuilder.UseSqlServer(conStr);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobListing> JobListings { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<SearchHistory> SearchHistories { get; set; }

       
            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User to Employer/JobSeeker
            modelBuilder.Entity<User>()
                .HasOne(u => u.Employer)
                .WithOne(e => e.User)
                .HasForeignKey<Employer>(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(u => u.JobSeeker)
                .WithOne(js => js.User)
                .HasForeignKey<JobSeeker>(js => js.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // JobSeeker to Resume, Application, SearchHistory
            modelBuilder.Entity<JobSeeker>()
                .HasMany(js => js.Resumes)
                .WithOne(r => r.JobSeeker)
                .HasForeignKey(r => r.SeekerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JobSeeker>()
                .HasMany(js => js.Applications)
                .WithOne(a => a.JobSeeker)
                .HasForeignKey(a => a.SeekerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JobSeeker>()
                .HasMany(js => js.SearchHistories)
                .WithOne(sh => sh.JobSeeker)
                .HasForeignKey(sh => sh.SeekerId)
                .OnDelete(DeleteBehavior.Cascade);
                
            // Employer to Company (One-to-Many)
            modelBuilder.Entity<Employer>()
                .HasMany(e => e.Companies)
                .WithOne(c => c.Employer)
                .HasForeignKey(c => c.EmployerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Company to JobListing (One-to-Many)
            modelBuilder.Entity<Company>()
                .HasMany(c => c.JobListings)
                .WithOne(jl => jl.Company)
                .HasForeignKey(jl => jl.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // JobListing to Application (One-to-Many)
            modelBuilder.Entity<JobListing>()
                .HasMany(jl => jl.Applications)
                .WithOne(a => a.JobListing)
                .HasForeignKey(a => a.JobListingId)
                .OnDelete(DeleteBehavior.Cascade);


            // Composite Key for SearchHistory (if applicable)
            modelBuilder.Entity<SearchHistory>()
                .HasKey(sh => new { sh.SeekerId, sh.Timestamp });

            // Indexing for unique and frequently searched columns
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Company>()
                .HasIndex(c => c.CompanyName);

            modelBuilder.Entity<JobListing>()
                .HasIndex(jl => jl.Title);

           
        }

    }
}
    
    


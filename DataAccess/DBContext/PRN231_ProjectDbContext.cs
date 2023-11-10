using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.Models
{
    public partial class PRN231_ProjectDbContext : DbContext
    {
        public PRN231_ProjectDbContext()
        {
        }

        public PRN231_ProjectDbContext(DbContextOptions<PRN231_ProjectDbContext> options) 
            : base(options) 
        { 
        }

        public DbSet<Employer> Employers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplicant> JobApplicants { get; set; }
        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<RatingsAndReviews> RatingsAndReviews { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<SavedJobs> SavedJobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                optionsBuilder.UseSqlServer(config.GetConnectionString("DbConnect"));
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace ISStudyAbroad2023.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Thought> Thoughts { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<CityActivity> CityActivities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Quote> Quotes { get; set; }
    }
}

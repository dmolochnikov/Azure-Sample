using System.Data.Entity;

namespace BookStore.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public BookContext(): base("BookContext")
        {
            Database.SetInitializer(new BookDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .Map(t => t.MapLeftKey("CourseId")
                    .MapRightKey("StudentId")
                    .ToTable("CourseStudent"));
        }
    }
}
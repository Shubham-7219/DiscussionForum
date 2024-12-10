using DiscussionForum.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiscussionForum.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Question>()
                .HasOne(q => q.User)
                .WithMany()
                .HasForeignKey(q => q.User_Id)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Answer>()
            .HasOne(a => a.User) // Each Answer has one User
            .WithMany() // User can have many Answers
            .HasForeignKey(a => a.User_Id) // Foreign key is User_Id in the Answer table
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete when the User is deleted

            // Define the relationship between Answer and Question
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question) // Each Answer has one Question
                .WithMany(q => q.Answers) // Question can have many Answers
                .HasForeignKey(a => a.Question_Id) // Foreign key is Question_Id in the Answer table
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}

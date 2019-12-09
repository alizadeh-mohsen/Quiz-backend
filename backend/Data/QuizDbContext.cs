using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }
        public DbSet<Question> Questions { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace testTask.Models
{
    public class MailDbContext : DbContext
    {
        public MailDbContext(DbContextOptions<MailDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Mail> Mail { get; set; }
    }
}

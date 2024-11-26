using GithubActionsDemoApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace GithubActionsDemoApp
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People => Set<Person>();
    }
}

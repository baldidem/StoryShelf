using Microsoft.EntityFrameworkCore;
using StoryShelfApi.Domain;

namespace StoryShelfApi.Context
{
    public class StoryShelfDbContext : DbContext, IStoryShelfDbContext
    {
        public StoryShelfDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}

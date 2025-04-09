using Microsoft.EntityFrameworkCore;
using StoryShelfApi.Domain;

namespace StoryShelfApi.Context
{
    public class StoryShelfDbContext : DbContext
    {
        public StoryShelfDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
    }
}

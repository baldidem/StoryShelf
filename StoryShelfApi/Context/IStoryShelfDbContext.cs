using Microsoft.EntityFrameworkCore;
using StoryShelfApi.Domain;

namespace StoryShelfApi.Context
{
    public interface IStoryShelfDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        int SaveChanges();
    }
}

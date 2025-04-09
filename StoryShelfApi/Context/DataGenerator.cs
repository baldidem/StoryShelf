using Microsoft.EntityFrameworkCore;
using StoryShelfApi.Domain;

namespace StoryShelfApi.Context
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StoryShelfDbContext(serviceProvider.GetRequiredService<DbContextOptions<StoryShelfDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    }
                    );

                context.Books.AddRange(
                    new Book
                    {
                        Title = "Lean Startup",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        Title = "Herland",
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 05, 23)
                    },
                     new Book
                     {
                         Title = "Dune",
                         GenreId = 2,
                         PageCount = 1000,
                         PublishDate = new DateTime(2003, 10, 05)
                     }

                    );
                context.SaveChanges();

            }
        }

    }
}

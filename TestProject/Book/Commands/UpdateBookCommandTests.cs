using StoryShelfApi.Impl.Cqrs;
using StoryShelfApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Book.Commands
{
    public class UpdateBookCommandTests
    {
        [Fact]
        public void Constructor_Should_Set_Properties()
        {
            // Arrange
            var id = 10;
            var book = new BookRequest { Title = "Sample Book", GenreId = 2 };

            // Act
            var command = new UpdateBookCommand(id, book);

            // Assert
            Assert.Equal(id, command.id);
            Assert.Equal(book, command.book);
        }
    }
}

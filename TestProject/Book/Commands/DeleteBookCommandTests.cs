using StoryShelfApi.Impl.Cqrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Book.Commands
{
    public class DeleteBookCommandTests
    {
        [Fact]
        public void Constructor_Should_Set_Id()
        {
            // Arrange
            var id = 5;

            // Act
            var command = new DeleteBookCommand(id);

            // Assert
            Assert.Equal(id, command.id);
        }
    }
}

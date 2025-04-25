using StoryShelfApi.Impl.Cqrs;

namespace TestProject.Book.Queries
{
    public class GetBookByIdQueryTests
    {
        [Fact]
        public void Constructor_Should_Set_Id()
        {
            // Arrange
            var id = 3;

            // Act
            var query = new GetBookByIdQuery(id);

            // Assert
            Assert.Equal(id, query.id);
        }
    }
}

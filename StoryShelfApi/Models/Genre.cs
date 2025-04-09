namespace StoryShelfApi.Models
{
    public class GenreRequest
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
    public class GenreResponse
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}

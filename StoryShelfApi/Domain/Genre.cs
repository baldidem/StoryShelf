﻿namespace StoryShelfApi.Domain
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
        public List<Book> Books { get; set; }
    }
}

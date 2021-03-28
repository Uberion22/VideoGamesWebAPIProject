using System;

namespace VideoGamesWebAPIProject.Models
{
    public class VideoGamesFilterQueryOptions
    {
        public string Title { get; set; }

        public VideoGameGenre Genre { get; set; }

        public DateTime ReleseDate { get; set; }

        public decimal Price { get; set; }

        public VideogamePlatform Platform { get; set; } 
    }
}

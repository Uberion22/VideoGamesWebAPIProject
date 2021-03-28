using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoGamesWebAPIProject.Models
{
    public class VideoGame
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название игры  не может быть пустым")]
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public int Price { get; set; }

        public VideogamePlatform Platform { get; set; }

        public IEnumerable<VideoGameGenre> Genre { get; set; } 
        
        public DateTime ReleaseDate { get; set; }

        public string DeveloperStudio { get; set; }
    }
}

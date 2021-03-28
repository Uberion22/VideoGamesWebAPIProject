using Microsoft.EntityFrameworkCore;

namespace VideoGamesWebAPIProject.Models
{
    public class VideoGamesContext: DbContext
    {
        public DbSet<VideoGame> VideoGames { get; set; }
        public VideoGamesContext(DbContextOptions<VideoGamesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

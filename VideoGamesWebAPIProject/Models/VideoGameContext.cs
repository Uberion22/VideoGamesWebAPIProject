using Microsoft.EntityFrameworkCore;
using VideoGamesWebAPIProject.BusinessLogic;

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var IntValueConverter = new VideoGameGenreListToStringConverter();

            modelBuilder
                .Entity<VideoGame>()
                .Property(e => e.Genre)
                .HasConversion(IntValueConverter);
        }
    }
}

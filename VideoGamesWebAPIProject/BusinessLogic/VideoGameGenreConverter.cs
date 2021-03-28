using VideoGamesWebAPIProject.Models;

namespace VideoGamesWebAPIProject.BusinessLogic
{
    public static class VideoGameGenreConverter
    {
        public static VideoGameGenre ConvertToGenre(this string value)
        {
            try
            {
                return value switch
                {
                    "Action" => VideoGameGenre.Action,
                    "Adventure" => VideoGameGenre.Adventure,
                    "Fighting" => VideoGameGenre.Fighting,
                    "HackAndSlash" => VideoGameGenre.HackAndSlash,
                    "Platform" => VideoGameGenre.Platform,
                    "Puzzle" => VideoGameGenre.Puzzle,
                    "RPG" => VideoGameGenre.RPG,
                    "Sports" => VideoGameGenre.Sports,
                    "Stealth" => VideoGameGenre.Stealth,
                    _ => VideoGameGenre.Strategy,
                };
            }
            catch
            {
                return VideoGameGenre.Strategy;
            }
        }
    }

}


namespace VideoGamesWebAPIProject.Models
{
    public enum VideoGameGenre
    {
        Action = 1,
        Adventure,
        Fighting,
        HackAndSlash,
        Platform,
        Puzzle,
        RPG,
        Sports,
        Stealth,
        Strategy
    }

    public enum VideogamePlatform
    {
        XboxOneSeriesX = 1,
        PlayStation5,
        PC,
        NindendoSwitch,
        Android,
        Other,
    }
    public enum ResponseStatusMessages
    {
        Done = 1,
        ItemNotFound,
    }
}

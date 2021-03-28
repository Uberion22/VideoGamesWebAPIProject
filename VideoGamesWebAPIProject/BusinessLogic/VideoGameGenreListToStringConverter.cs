using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;
using System.Linq;
using VideoGamesWebAPIProject.Models;

namespace VideoGamesWebAPIProject.BusinessLogic
{

    public class VideoGameGenreListToStringConverter : ValueConverter<IEnumerable<VideoGameGenre>, string>
    {
        public VideoGameGenreListToStringConverter()
            : base(le => ListToString(le), (s => StringToList(s)))
        {

        }
        public static string ListToString(IEnumerable<VideoGameGenre> value)
        {
            if (value == null || value.Count() == 0)
            {
                return null;
            }
            string result = "";
            foreach (var val in value)
            {
                result += val + ",";
            }

            return result;
        }
        public static IEnumerable<VideoGameGenre> StringToList(string value)
        {
            if (value == null || value == string.Empty)
            {
                return null;
            }
            var result = new List<VideoGameGenre>();
            var temp = value.Split(",");
            foreach (var val in temp)
            {
                if (val != "")
                {
                    result.Add(val.ConvertToGenre());
                }
            }

            return result;
        }
    }
}

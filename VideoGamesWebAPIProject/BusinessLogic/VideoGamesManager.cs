using System.Linq;
using VideoGamesWebAPIProject.Models;
using VideoGamesWebAPIProject.Repository;

namespace VideoGamesWebAPIProject.BusinessLogic
{
    public class VideoGamesManager
    {
        private readonly IRepository<VideoGame> _repository;

        public VideoGamesManager(IRepository<VideoGame> repository)
        {
            _repository = repository;
        }

        public IQueryable<VideoGame> GetVideoGamesList()
        {
            return _repository.GetVideoGamesList();
        }

        public VideoGame GetVideoGameById(int id)
        {
            return _repository.GetVideoGameById(id);
        }

        /// <summary>
        ///Вернуть список видеоигрудовлетворяющих устовиям поиска хранящихся в соответствующийх полях объекта класса FilterOptions  
        /// </summary>
        /// <param name="filter">экземпляр класса содержащий параметры фильрации</param>
        /// <returns> Возвращает список видеоигр удовлетворяющих условиям поиска,
        /// хранящихся в соответствующийх полях объекта класса FilterOptions</returns>
        public IQueryable<VideoGame> GetGamesWithFilter(VideoGamesFilterQueryOptions filter)
        {
            var videoGames = GetVideoGamesList();
            if(filter.Title != null)
            {
                videoGames = videoGames.Where(p => p.Title.Contains(filter.Title));
            };
            if(filter.Genre > 0)
            {
                videoGames = videoGames.Where(p => p.Genre == filter.Genre);
            };
            if (filter.Price > 0)
            {
                videoGames = videoGames.Where(p => p.Price <= filter.Price);
            };
            if (filter.Platform > 0)
            {
                videoGames = videoGames.Where(p => p.Platform == filter.Platform);
            };

            return videoGames;
        }

        public string AddVideoGame(VideoGame videoGame)
        {
            _repository.Create(videoGame);

            return "Added!";
        }

        public string EditVIdeoGame(VideoGame videoGame)
        {
            var status =_repository.Edit(videoGame);

            return status;
        }

        public string DeleteVideoGame(int id)
        {
            var status = _repository.Delete(id);

            return status;
        }

    }
}

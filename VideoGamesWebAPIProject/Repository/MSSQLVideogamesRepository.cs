using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using VideoGamesWebAPIProject.Models;

namespace VideoGamesWebAPIProject.Repository
{
    public class MSSQLVideogamesRepository: IRepository<VideoGame>
    {
        private readonly VideoGamesContext _db;
        private bool _disposed = false;

        public MSSQLVideogamesRepository(VideoGamesContext videoGamesContext)
        {
            _db = videoGamesContext;
        }

        public IQueryable<VideoGame> GetVideoGamesList()
        {
            return _db.VideoGames;
        }

        public void Create(VideoGame videoGame)
        {
            _db.VideoGames.Add(videoGame);
            Save();
        }

        public ResponseStatusMessages  Edit(VideoGame videoGame)
        {
            try
            {
                _db.Entry(videoGame).State = EntityState.Modified;
                Save();
                return ResponseStatusMessages.Done;
            }
            catch
            {
                return ResponseStatusMessages.ItemNotFound;
            }
        }

        public ResponseStatusMessages Delete(int id)
        {
            VideoGame videoGame = _db.VideoGames.Find(id);
            if (videoGame != null)
            {
                _db.VideoGames.Remove(videoGame);
                Save();

                return ResponseStatusMessages.Done;
            }

            return ResponseStatusMessages.ItemNotFound;
        }

        public VideoGame GetVideoGameById(int id)
        {
            return _db.VideoGames.Find(id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using VideoGamesWebAPIProject.Models;

namespace VideoGamesWebAPIProject.Repository
{
    public class MSSQLVideogamesRepository: IRepository<VideoGame>
    {
        private readonly VideoGamesContext db;
        private bool disposed = false;

        public MSSQLVideogamesRepository(VideoGamesContext videoGamesContext)
        {
            db = videoGamesContext;
        }

        public IQueryable<VideoGame> GetVideoGamesList()
        {
            return db.VideoGames;
        }

        public void Create(VideoGame videoGame)
        {
            db.VideoGames.Add(videoGame);
            Save();
        }

        public string  Edit(VideoGame videoGame)
        {
            try
            {
                db.Entry(videoGame).State = EntityState.Modified;
                Save();
                return $"Id {videoGame.Id} Updated! ";
            }
            catch
            {
                return $"Id {videoGame.Id} Not Found!";
            }
        }

        public string Delete(int id)
        {
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame != null)
            {
                db.VideoGames.Remove(videoGame);
                Save();

                return $"Id {videoGame.Id} Deleted!";
            }

            return $"Id {id} Not Found!";
        }

        public VideoGame GetVideoGameById(int id)
        {
            return db.VideoGames.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

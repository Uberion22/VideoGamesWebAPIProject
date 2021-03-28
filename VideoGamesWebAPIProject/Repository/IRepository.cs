using System;
using System.Linq;
using VideoGamesWebAPIProject.Models;

namespace VideoGamesWebAPIProject.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetVideoGamesList();

        T GetVideoGameById(int id);

        void Create(T item);

        ResponseStatusMessages Edit(T item);

        ResponseStatusMessages Delete(int id);

        void Save();
    }
}
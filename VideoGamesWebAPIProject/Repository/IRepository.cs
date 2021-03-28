using System;
using System.Linq;

namespace VideoGamesWebAPIProject.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetVideoGamesList();

        T GetVideoGameById(int id);

        void Create(T item);

        string Edit(T item);

        string Delete(int id);

        void Save();
    }
}
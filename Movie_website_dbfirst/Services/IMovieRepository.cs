using Microsoft.AspNetCore.Mvc.Rendering;
using Movie_website_dbfirst.Models;

namespace Movie_website_dbfirst.Services
{
    public interface IMovieRepository<T>
    {

        Task<List<T>> GetAll();
        Task<T> GetById(Guid? id);
        void Add(T t);
        void Update(T t);
        public Task<T> UpdateViewById(Guid? id);
        void Delete(Guid id);
        public SelectList GenresList();
        public SelectList ActorList();
        public SelectList ProducerList();
        public SelectList DirectorList();
        public SelectList EpsiodeList();

    }
}

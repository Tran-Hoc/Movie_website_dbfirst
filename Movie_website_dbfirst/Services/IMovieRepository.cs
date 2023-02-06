using Microsoft.AspNetCore.Mvc.Rendering;
using Movie_website_dbfirst.Models;

namespace Movie_website_dbfirst.Services
{
    public interface IMovieRepository
    {

        Task<List<MovieVM>> GetAll();
        Task<MovieVM> GetById(int? id);
        void Add(MovieVM movieVM);
        void Update(MovieVM movieVM);
        void Delete(int? id);
        public SelectList GenresList();
        public SelectList ActorList();
        public SelectList ProducerList();
        public SelectList DirectorList();
        public SelectList EpsiodeList();

    }
}

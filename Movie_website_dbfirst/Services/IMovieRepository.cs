using Movie_website_dbfirst.Models;

namespace Movie_website_dbfirst.Services
{
    public interface IMovieRepository
    {
        Task<List<MovieVM>> GetAll();
        MovieVM GetById(int id);
        MovieVM Add(MovieVM movieVM);
        MovieVM Update(MovieVM movieVM);
        MovieVM Delete(int id);
    }
}

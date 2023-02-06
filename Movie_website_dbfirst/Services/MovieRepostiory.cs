using Microsoft.EntityFrameworkCore;
using Movie_website_dbfirst.Data;
using Movie_website_dbfirst.DataConext;
using Movie_website_dbfirst.Models;

namespace Movie_website_dbfirst.Services
{
    public class MovieRepostiory : IMovieRepository
    {
        private MovieDbFirstContext _context;

        public MovieRepostiory(MovieDbFirstContext context) { _context = context; }

        public MovieVM Add(MovieVM movieVM)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MovieVM>> GetAll()
        {
         
            var vv = await _context.Movies.ToListAsync();
            List<MovieVM> movieVM = new List<MovieVM>();
            foreach (Movie v in vv)
            {
                MovieVM vm = new MovieVM
                {
                    ID = v.Id,
                    Name = v.NameMovie
                };
                movieVM.Add(vm);
            };
            return movieVM;
        }

        public MovieVM GetById(int id)
        {
            throw new NotImplementedException();
        }

        public MovieVM Update(MovieVM movieVM)
        {
            throw new NotImplementedException();
        }
        public MovieVM Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

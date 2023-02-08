using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie_website_dbfirst.Data;
using Movie_website_dbfirst.DataContext;
using Movie_website_dbfirst.Models;

namespace Movie_website_dbfirst.Services
{
    public class MovieRepostiory : IMovieRepository
    {
        private MovieDbFirstContext _context;


        public MovieRepostiory(MovieDbFirstContext context) { _context = context; }

        public void Add(MovieVM movieVM)
        {
            // add dung  honw
            //
            if (_context.Movies != null)
            {
                Movie movie = new Movie
                {
                    NameMovie = movieVM.NameMovie,
                    ReleaseDate = movieVM.ReleaseDate,
                    Title = movieVM.Title,
                    ImgPath = movieVM.ImgPath,
                    MoviePath = movieVM.ImgPath,
                };
                GenreOfMovie genreOfMovie = new GenreOfMovie
                {
                    //GenreId = 
                };
                _context.Add(movie);
                _context.SaveChanges();

            }

            //if (ModelState.IsValid)
            //{
            //    _context.Add(movieVM);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}

            //var movieVM = await _context.Movies
            //    .FirstOrDefaultAsync(m => m.Id == id);
            // lay tu bang chung cua quan he nhieu nhieu 

            //List<Genre> genres = _context.Genres.FromSql($"Select Name from genre").ToList();
            //List<Actor> actors = _context.Actors.FromSql($"Select p.Name from actor a, Person p where a.PersonId = p.Id").ToList();
            //List<Producer> producers = _context.Producers.FromSql($"Select p.Name from Producer pr, Person p where pr.PersonId = p.Id").ToList();
            //List<Director> directors = _context.Directors.FromSql($"Select p.Name from Director d, Person p where d.PersonId = p.Id").ToList();

            //if (movieVM == null)
            //{
            //    return null;
            //}
            //var movieVM = new MovieVM
            //{
            //    Id = movieVM.Id,
            //    NameMovie = movieVM.NameMovie,
            //    Title = movieVM.Title,
            //    ReleaseDate = movieVM.ReleaseDate,
            //    AvgRating = movieVM.AvgRating,
            //    ImgPath = movieVM.ImgPath,
            //    MoviePath = movieVM.MoviePath,
            //    Actors = actors,
            //    Producers = producers,
            //    Directors = directors,
            //    Genres = genres
            //};
            //return movieVM;
        }

        public void Delete(int? id)
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
                    Id = v.Id,
                    NameMovie = v.NameMovie
                };
                movieVM.Add(vm);
            };
            return movieVM;
        }
        public async Task<MovieVM> GetById(int? id)
        {

            // add dung  honw
            //
            if (id == null || _context.Movies == null)
            {
                return null;
            }

            var movies = await _context.Movies
             .FirstOrDefaultAsync(m => m.Id == id);

            if (movies == null)
            {
                return null;
            }

            // lay tu bang chung cua quan he nhieu nhieu 

            var genres = new SelectList(_context.Genres.FromSql($"Select Name from genre").ToList());
            var actors = new SelectList(_context.Actors.FromSql($"Select p.Name from actor a, Person p where a.PersonId = p.Id").ToList());
            var producers = new SelectList(_context.Producers.FromSql($"Select p.Name from Producer pr, Person p where pr.PersonId = p.Id").ToList());
            var directors = new SelectList(_context.Directors.FromSql($"Select p.Name from Director d, Person p where d.PersonId = p.Id").ToList());

            var movieVM = new MovieVM
            {
                Id = movies.Id,
                NameMovie = movies.NameMovie,
                Title = movies.Title,
                ReleaseDate = movies.ReleaseDate,
                AvgRating = movies.AvgRating,
                ImgPath = movies.ImgPath,
                MoviePath = movies.MoviePath,
                //Actors = actors,
                //Producers = producers,
                //Directors = directors,
                //Genres = genres
            };
            return movieVM;

        }

        public void Update(MovieVM movieVM)
        {
            throw new NotImplementedException();
        }
        public SelectList GenresList()
        {
            var olist = from a in _context.Genres select new { Id = a.Id, Name = a.Name };
            var list = new SelectList(olist, "Id", "Name");
            return list;
        }

        public SelectList ActorList()
        {
            var olist = from actor in _context.Actors join per in _context.People on actor.PersonId equals per.Id select new { Id = actor.Id, Name = per.Name };
            var actors = new SelectList(olist, "Id", "Name");
        
            return actors;
        }
        public SelectList ProducerList()
        {
            var olist = from a in _context.Producers join per in _context.People on a.PersonId equals per.Id select new { Id = a.Id, Name = per.Name };
            var list = new SelectList(olist, "Id", "Name");
            return list;
        }
        public SelectList DirectorList()
        {
            var olist = from a in _context.Directors join per in _context.People on a.PersonId equals per.Id select new { Id = a.Id, Name = per.Name };
            var list = new SelectList(olist, "Id", "Name");
            return list;
        }

        public SelectList EpsiodeList()
        {
            var olist = from a in _context.Episodes select new { Id = a.Id, Name = a.NameEp };
            var list = new SelectList(olist, "Id", "Name");
            return list;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie_website_dbfirst.Data;
using Movie_website_dbfirst.DataContext;
using Movie_website_dbfirst.Models;
using System;

namespace Movie_website_dbfirst.Services
{
    public class MovieRepostiory : IMovieRepository<MovieVM>
    {
        private MovieDbFirstContext _context;


        public MovieRepostiory(MovieDbFirstContext context) { _context = context; }


        private string SaveFile(IFormFile file, Guid id, int typ)
        {
            string path = "";


            if (typ == 1)
            {
                string imgpath = "wwwroot\\\\Files\\\\Images";
                path = Path.Combine(Directory.GetCurrentDirectory(), imgpath);
            }
            else
            {
                string videopath = "wwwroot\\Files\\Video";
                path = Path.Combine(Directory.GetCurrentDirectory(), videopath);

            }

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            //get file extension
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileName = id + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);
            if (File.Exists(fileNameWithPath))
            {
                File.Delete(fileNameWithPath);
            }

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(stream);
            }
            return fileName;


        }

        public void Add(MovieVM movieVM)
        {
            if (_context.Movies != null)
            {
                //string filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(pvm.Picture.FileName));
                //pvm.Picture.SaveAs(Server.MapPath(filePath));

                /*
                 * create movie and acted, directed : idmovie create by guid() in c# data type in sql is uniqueidentifier, 
                 * 
                 * table with 2 primary key and also is foregin key* 

                 */

                Movie movie = new Movie
                {
                    Id = Guid.NewGuid(),
                    NameMovie = movieVM.NameMovie,
                    ReleaseDate = movieVM.ReleaseDate,
                    Title = movieVM.Title,
                };
                try
                {
                    movie.ImgPath = SaveFile(movieVM.image, movie.Id, 1);
                    movie.MoviePath = SaveFile(movieVM.vidoe, movie.Id, 2);
                }
                catch
                {
                    throw;
                }

                _context.Add(movie);

                // lay du lieu trong movieVM lấy id của movie 
                foreach (var m in movieVM.Genres)
                {
                    GenreOfMovie genreOfMovie = new GenreOfMovie
                    {
                        GenreId = m,
                        MovieId = movie.Id,//guid
                    };
                    _context.Add(genreOfMovie);
                }
                foreach (var p in movieVM.Producers)
                {
                    Produced produced = new Produced
                    {
                        ProducerId = p,
                        MovieId = movie.Id
                    };
                    //pros.Add();
                    _context.Add(produced);
                }

                foreach (var a in movieVM.Actors)
                {
                    Acted act = new Acted
                    {
                        ActorId = a,
                        MovieId = movie.Id
                    };
                    //acted.Add();
                    _context.Add(act);
                }

                foreach (var d in movieVM.Directors)
                {
                    Directed dir = new Directed
                    {
                        DirectorId = d,
                        MovieId = movie.Id
                    };
                    _context.Add(dir);
                }

                int numEp = _context.EpisodeOfs.Where(e => e.EpisodeId == movieVM.Episodes).Count();

                EpisodeOf episodeOf = new EpisodeOf
                {
                    EpisodeId = movieVM.Episodes,
                    MovieId = movie.Id,
                    NumEp = numEp + 1
                };

                _context.Add(episodeOf);
                _context.SaveChanges();
            }
        }


        public void DeleteRelationShip(Guid id)
        {

            var movieRelationShip = _context.Directeds.Where(e => e.MovieId == id);
            if (movieRelationShip.Any())
            {
                _context.Directeds.RemoveRange(movieRelationShip);
            }

            var generRelationShip = _context.GenreOfMovies.Where(e => e.MovieId == id);
            if (movieRelationShip.Any())
            {
                _context.GenreOfMovies.RemoveRange(generRelationShip);
            }


            var producedRelationShip = _context.Produceds.Where(e => e.MovieId == id);
            if (movieRelationShip.Any())
            {
                _context.Produceds.RemoveRange(producedRelationShip);
            }

            var actedRelationShip = _context.Acteds.Where(e => e.MovieId == id);
            if (movieRelationShip.Any())
            {
                _context.Acteds.RemoveRange(actedRelationShip);
            }

            var epsisodeOf = _context.EpisodeOfs.Where(e => e.MovieId == id).FirstOrDefault();
            if (epsisodeOf != null)
            {
                _context.EpisodeOfs.Remove(epsisodeOf);
            }
            _context.SaveChanges();

        }
        public void Delete(Guid id)
        {
            DeleteRelationShip(id);
            DeleteFile(id, 1);
            DeleteFile(id, 2);

            var movie = _context.Movies.Where(e => e.Id == id).FirstOrDefault();
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }

        }
        public void DeleteFile(Guid id, int typ)
        {
            string path = "";

            string fileName = "";
            if (typ == 1)
            {
                string imgpath = "wwwroot\\\\Files\\\\Images";
                path = Path.Combine(Directory.GetCurrentDirectory(), imgpath);
                fileName = _context.Movies.Where(e => e.Id == id).FirstOrDefault().ImgPath;
            }
            else
            {
                string videopath = "wwwroot\\Files\\Video";
                path = Path.Combine(Directory.GetCurrentDirectory(), videopath);
                fileName = _context.Movies.Where(e => e.Id == id).FirstOrDefault().ImgPath;

            }

            //get file extension
            //FileInfo fileInfo = new FileInfo(file.FileName);
            //string fileName = _context.Movies.Where(e =>e.Id == id).FirstOrDefault().ImgPath;

            string fileNameWithPath = Path.Combine(path, fileName);
            if (File.Exists(fileNameWithPath))
            {
                File.Delete(fileNameWithPath);
            }

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

        // for details
        public async Task<MovieVM> GetById(Guid? id)
        {
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


            MovieVM movievm = new MovieCVM
            {
                Id = movies.Id,
                NameMovie = movies.NameMovie,
                Title = movies.Title,
                ReleaseDate = movies.ReleaseDate,
                AvgRating = movies.AvgRating,
                ImgPath = "~/Files/Images/" + movies.ImgPath,
                MoviePath = "~/Files/Video/" + movies.MoviePath,
                Actors = ActorList(movies.Id),
                Producers = ProducerList(movies.Id),
                Directors = DirectorList(movies.Id),
                Genres = GenresList(movies.Id),
                Episodes = EpisodeList(movies.Id)
            };

            return movievm;

        }
        public async Task<MovieVM> UpdateViewById(Guid? id)
        {
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

            MovieVM movievm = new MovieVM
            {
                Id = movies.Id,
                NameMovie = movies.NameMovie,
                Title = movies.Title,
                ReleaseDate = movies.ReleaseDate,
                AvgRating = movies.AvgRating,
                ImgPath = movies.ImgPath,
                MoviePath = movies.MoviePath,
                Actors = ActorListId(movies.Id),
                Producers = ProducerListId(movies.Id),
                Directors = DirectorListId(movies.Id),
                Genres = GenresListId(movies.Id),
                Episodes = EpisodeListID(movies.Id)
            };

            return movievm;
        }

        public void Update(MovieVM movieVM)
        {
            if (_context.Movies != null)
            {

                /*
                 *    string filePath = pvm.PicturePath;
                          if (pvm.Picture != null)
                           {
                              filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(pvm.Picture.FileName));
                              pvm.Picture.SaveAs(Server.MapPath(filePath));
                 * */

                /*
                 * create movie and acted, directed : idmovie create by guid() in c# data type in sql is uniqueidentifier, 
                 * 
                 * table with 2 primary key and also is foregin key
                 */

                DeleteRelationShip(movieVM.Id);

                if (movieVM.image != null && movieVM.vidoe != null)
                {
                    // var id = movieVM.Id;
                    // AddorUpdate(movieVM, 3);
                    Movie movie = new Movie
                    {
                        Id = movieVM.Id,
                        NameMovie = movieVM.NameMovie,
                        ReleaseDate = movieVM.ReleaseDate,
                        Title = movieVM.Title,
                    };
                    try
                    {
                        // delete old file

                        movie.ImgPath = SaveFile(movieVM.image, movieVM.Id, 1);
                        movie.MoviePath = SaveFile(movieVM.vidoe, movieVM.Id, 2);

                    }
                    catch
                    {
                        throw;
                    }

                    _context.Entry(movie).State = EntityState.Modified;
                    _context.SaveChanges();
                    InsertTableRelation(movieVM);

                }
                else if (movieVM.image == null && movieVM.vidoe == null)
                {
                    Movie movie = new Movie
                    {
                        Id = movieVM.Id,
                        NameMovie = movieVM.NameMovie,
                        ReleaseDate = movieVM.ReleaseDate,
                        Title = movieVM.Title,
                    };
                    try
                    {
                        movie.ImgPath = movieVM.ImgPath;
                        movie.MoviePath = movieVM.MoviePath;
                    }
                    catch
                    {
                        throw;
                    }
                    _context.Entry(movie).State = EntityState.Modified;
                    _context.SaveChanges();
                    InsertTableRelation(movieVM);
                }
                else if (movieVM.image != null) /// update for image
                {
                    Movie movie = new Movie
                    {
                        Id = movieVM.Id,
                        NameMovie = movieVM.NameMovie,
                        ReleaseDate = movieVM.ReleaseDate,
                        Title = movieVM.Title,
                    };
                    try
                    {
                        movie.ImgPath = SaveFile(movieVM.image, movieVM.Id, 1);
                        movie.MoviePath = movieVM.MoviePath;
                    }
                    catch
                    {
                        throw;
                    }

                    _context.Entry(movie).State = EntityState.Modified;
                    _context.SaveChanges();
                    InsertTableRelation(movieVM);

                }
                else if (movieVM.vidoe != null)
                {
                    Movie movie = new Movie
                    {
                        Id = movieVM.Id,
                        NameMovie = movieVM.NameMovie,
                        ReleaseDate = movieVM.ReleaseDate,
                        Title = movieVM.Title,
                    };

                    try
                    {
                        movie.MoviePath = SaveFile(movieVM.vidoe, movieVM.Id, 2);
                        movie.ImgPath = movieVM.ImgPath;
                    }
                    catch
                    {
                        throw;
                    }

                    _context.Entry(movie).State = EntityState.Modified;
                    _context.SaveChanges();
                    InsertTableRelation(movieVM);

                }

            }
        }

        private void InsertTableRelation(MovieVM movieVM)
        {
            // lay du lieu trong movieVM lấy id của movie 
            foreach (var m in movieVM.Genres)
            {
                GenreOfMovie genreOfMovie = new GenreOfMovie
                {
                    GenreId = m,
                    MovieId = movieVM.Id,//guid
                };
                _context.Add(genreOfMovie);
            }
            foreach (var p in movieVM.Producers)
            {
                Produced produced = new Produced
                {
                    ProducerId = p,
                    MovieId = movieVM.Id
                };
                //pros.Add();
                _context.Add(produced);
            }

            foreach (var a in movieVM.Actors)
            {
                Acted act = new Acted
                {
                    ActorId = a,
                    MovieId = movieVM.Id
                };
                //acted.Add();
                _context.Add(act);
            }

            foreach (var d in movieVM.Directors)
            {
                Directed dir = new Directed
                {
                    DirectorId = d,
                    MovieId = movieVM.Id
                };
                _context.Add(dir);
            }

            int numEp = _context.EpisodeOfs.Where(e => e.EpisodeId == movieVM.Episodes).Count();

            EpisodeOf episodeOf = new EpisodeOf
            {
                EpisodeId = movieVM.Episodes,
                MovieId = movieVM.Id,
                NumEp = numEp + 1
            };

            _context.Add(episodeOf);
            _context.SaveChanges();
        }

        public List<string> GenresList(Guid? id)
        {

            var list = (from gom in _context.GenreOfMovies
                        join gen in _context.Genres on gom.GenreId equals gen.Id
                        where gom.MovieId == id
                        select gen.Name
                        ).ToList();
            return list;
        }


        public List<string> ActorList(Guid? id)
        {

            var list = (from gom in _context.Acteds
                        join gen in _context.Actors on gom.ActorId equals gen.Id
                        where gom.MovieId == id
                        select gen.Name
                        ).ToList();
            return list;
        }
        public List<string> ProducerList(Guid? id)
        {

            var list = (from gom in _context.Produceds
                        join gen in _context.Producers on gom.ProducerId equals gen.Id
                        where gom.MovieId == id
                        select gen.Name
                        ).ToList();
            return list;
        }
        public List<string> DirectorList(Guid? id)
        {

            var list = (from gom in _context.Directeds
                        join gen in _context.Directors on gom.DirectorId equals gen.Id
                        where gom.MovieId == id
                        select gen.Name
                        ).ToList();
            return list;
        }
        public string EpisodeList(Guid? id)
        {
            var list = (from gom in _context.EpisodeOfs
                        join gen in _context.Episodes on gom.EpisodeId equals gen.Id
                        where gom.MovieId == id
                        select gen.NameEp
                        ).FirstOrDefault();
            return list;
        }
        public List<Guid> GenresListId(Guid? id)
        {

            var list = (from gom in _context.GenreOfMovies
                        join gen in _context.Genres on gom.GenreId equals gen.Id
                        where gom.MovieId == id
                        select gen.Id
                        ).ToList();
            return list;
        }
        public List<Guid> ActorListId(Guid? id)
        {

            var list = (from gom in _context.Acteds
                        join gen in _context.Actors on gom.ActorId equals gen.Id
                        where gom.MovieId == id
                        select gen.Id
                        ).ToList();
            return list;
        }

        public List<Guid> ProducerListId(Guid? id)
        {

            var list = (from gom in _context.Produceds
                        join gen in _context.Producers on gom.ProducerId equals gen.Id
                        where gom.MovieId == id
                        select gen.Id
                        ).ToList();
            return list;
        }

        public List<Guid> DirectorListId(Guid? id)
        {

            var list = (from gom in _context.Directeds
                        join gen in _context.Directors on gom.DirectorId equals gen.Id
                        where gom.MovieId == id
                        select gen.Id
                        ).ToList();
            return list;
        }

        public Guid EpisodeListID(Guid? id)
        {
            var list = (from gom in _context.EpisodeOfs
                        join gen in _context.Episodes on gom.EpisodeId equals gen.Id
                        where gom.MovieId == id
                        select gen.Id
                        ).FirstOrDefault();
            return list;
        }

        public SelectList GenresList()
        {
            //var olist = from a in _context.Genres select new { Id = a.Id, Name = a.Name };
            var list = new SelectList(_context.Genres, "Id", "Name");
            return list;
        }

        public SelectList ActorList()
        {
            // var olist = from actor in _context.Actors select new { Id = actor.Id, Name = actor.Name };
            var actors = new SelectList(_context.Actors, "Id", "Name");

            return actors;
        }
        public SelectList ProducerList()
        {
            //  var olist = from a in _context.Producers select new { Id = a.Id, Name = a.Name };
            var list = new SelectList(_context.Producers, "Id", "Name");
            return list;
        }
        public SelectList DirectorList()
        {
            //var olist = from a in _context.Directors select new { Id = a.Id, Name = a.Name };
            var list = new SelectList(_context.Directors, "Id", "Name");
            return list;
        }

        public SelectList EpsiodeList()
        {
            //var olist = from a in _context.Episodes select new { Id = a.Id, Name = a.NameEp };
            var list = new SelectList(_context.Episodes, "Id", "NameEp");
            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie_website_dbfirst.DataContext;
using Movie_website_dbfirst.Models;
using Movie_website_dbfirst.Services;

namespace Movie_website_dbfirst.Controllers
{
    public class MoviesController : Controller
    {
        //  private readonly MovieDbFirstContext _context;
        private readonly IMovieRepository<MovieVM> _context;
        //   public static List<MovieVM> movies = new List<MovieVM>();
        //     private MovieRepostiory _movie;
        public MoviesController(IMovieRepository<MovieVM> context)

        {
            _context = context;

        }
        // GET: MovieVMs
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _context.GetAll());
            }
            catch
            {
                return BadRequest();
            }
            //return View(await _context.MovieVM.ToListAsync());
        }

      

        //GET: MovieVMs/Create
        public IActionResult Create()
        {

            ViewBag.actorList = _context.ActorList();
            ViewBag.directorlist = _context.DirectorList();
            ViewBag.producerlist = _context.ProducerList();
            ViewBag.genrelist = _context.GenresList();
            ViewBag.episodelist = _context.EpsiodeList();
            return View();
        }

        // POST: MovieVMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // 1GB
        [RequestFormLimits(MultipartBodyLengthLimit = 1073741824)]
        public async Task<IActionResult> Create(MovieVM movieVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieVM);
                return RedirectToAction(nameof(Index));

            }
            ViewBag.actorList = _context.ActorList();
            ViewBag.directorlist = _context.DirectorList();
            ViewBag.producerlist = _context.ProducerList();
            ViewBag.genrelist = _context.GenresList();
            ViewBag.episodelist = _context.EpsiodeList();

            return View(movieVM);
        }

        // GET: MovieVMs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                MovieCVM movieVM = (MovieCVM)await _context.GetById(id);
                if (movieVM == null)
                {
                    return NotFound();
                }

                ViewData["Actors"] = string.Join(", ", movieVM.Actors);
                ViewData["Directors"] = string.Join(", ", movieVM.Directors);
                ViewData["Producers"] = string.Join(", ", movieVM.Producers);
                ViewData["Genres"] = string.Join(", ", movieVM.Genres);

                return View(movieVM);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        // GET: MovieVMs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                MovieVM movieVM = await _context.UpdateViewById(id);
                if (movieVM == null)
                {
                    return NotFound();
                }
                ViewBag.actorList = _context.ActorList();
                ViewBag.directorlist = _context.DirectorList();
                ViewBag.producerlist = _context.ProducerList();
                ViewBag.genrelist = _context.GenresList();
                ViewBag.episodelist = _context.EpsiodeList();

                return View(movieVM);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        // POST: MovieVMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MovieVM movieVM)
        {
            if (ModelState.IsValid)
            {
                _context.Update(movieVM);
                return RedirectToAction(nameof(Index));

            }
            ViewBag.actorList = _context.ActorList();
            ViewBag.directorlist = _context.DirectorList();
            ViewBag.producerlist = _context.ProducerList();
            ViewBag.genrelist = _context.GenresList();
            ViewBag.episodelist = _context.EpsiodeList();

            return View(movieVM);

        }

        // GET: MovieVMs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                MovieCVM movieVM = (MovieCVM)await _context.GetById(id);
                if (movieVM == null)
                {
                    return NotFound();
                }

                ViewData["Actors"] = string.Join(", ", movieVM.Actors);
                ViewData["Directors"] = string.Join(", ", movieVM.Directors);
                ViewData["Producers"] = string.Join(", ", movieVM.Producers);
                ViewData["Genres"] = string.Join(", ", movieVM.Genres);

                return View(movieVM);
            }
            catch (Exception e)
            {
                throw e;
            }
            //if (id == null || _context.MovieVM == null)
            //{
            //    return NotFound();
            //}

            //var movieVM = await _context.MovieVM
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (movieVM == null)
            //{
            //    return NotFound();
            //}

            //return View(movieVM);
        }

        // POST: MovieVMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            _context.Delete(id);

            //Product product = db.Products.Find(id);
            //string file_name = product.PicturePath;
            //string path = Server.MapPath(file_name);
            //FileInfo file = new FileInfo(path);
            //if (file.Exists)
            //{
            //    file.Delete();
            //}
            //db.Products.Remove(product);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            //if (_context.MovieVM == null)
            //{
            //    return Problem("Entity set 'MovieDbFirstContext.MovieVM'  is null.");
            //}
            //var movieVM = await _context.MovieVM.FindAsync(id);
            //if (movieVM != null)
            //{
            //    _context.MovieVM.Remove(movieVM);
            //}

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool MovieVMExists(int id)
        //{
        //  return _context.MovieVM.Any(e => e.ID == id);
        //}
    }
}
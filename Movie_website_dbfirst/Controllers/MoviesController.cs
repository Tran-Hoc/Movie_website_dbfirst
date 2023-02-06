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
        private readonly IMovieRepository _context;
        //   public static List<MovieVM> movies = new List<MovieVM>();
   //     private MovieRepostiory _movie;
        public MoviesController(IMovieRepository context)

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

        // GET: MovieVMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movieVM = _context.GetById(id);
            if (movieVM == null)
            {
                return NotFound();
            }

            return View(movieVM);
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
        public async Task<IActionResult> Create([Bind("ID,Name")] MovieVM movieVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //try
            //{

            //}
            //if (ModelState.IsValid)
            //{
            //    _context.Add(movieVM);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            return View(movieVM);
        }

        //// GET: MovieVMs/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.MovieVM == null)
        //    {
        //        return NotFound();
        //    }

        //    var movieVM = await _context.MovieVM.FindAsync(id);
        //    if (movieVM == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(movieVM);
        //}

        //// POST: MovieVMs/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] MovieVM movieVM)
        //{
        //    if (id != movieVM.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(movieVM);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!MovieVMExists(movieVM.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(movieVM);
        //}

        //// GET: MovieVMs/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.MovieVM == null)
        //    {
        //        return NotFound();
        //    }

        //    var movieVM = await _context.MovieVM
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (movieVM == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(movieVM);
        //}

        //// POST: MovieVMs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.MovieVM == null)
        //    {
        //        return Problem("Entity set 'MovieDbFirstContext.MovieVM'  is null.");
        //    }
        //    var movieVM = await _context.MovieVM.FindAsync(id);
        //    if (movieVM != null)
        //    {
        //        _context.MovieVM.Remove(movieVM);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool MovieVMExists(int id)
        //{
        //  return _context.MovieVM.Any(e => e.ID == id);
        //}
    }
}

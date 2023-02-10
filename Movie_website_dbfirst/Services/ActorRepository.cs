using Microsoft.EntityFrameworkCore;
using Movie_website_dbfirst.Data;
using Movie_website_dbfirst.DataContext;
using System;

namespace Movie_website_dbfirst.Services
{
    public class ActorRepository : ICRUD<Actor>
    {
        private MovieDbFirstContext _context;
        public void Add(Actor t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid? id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Actor>> GetAll()
        {
            var a = await _context.Actors.ToListAsync();
            return a;
            
        }

        public Actor GetById(Guid? id)
        {
            var a = _context.Actors.FirstOrDefault(x => x.Id == id);
           return (a == null) ? null : a;
        }

        public bool Update(Actor t)
        {
            //try
            //{
            //     _context.Update(t);
            //     _context.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ActorExists(t.Id))
            //    {
            //        return null;
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            //return RedirectToAction(nameof(Index));
            return false;
        }

        bool ICRUD<Actor>.Delete(Guid? id)
        {
            throw new NotImplementedException();
        }

        private bool IsExists(Guid id)
        {
            return _context.Actors.Any(e => e.Id == id);
        }

        bool ICRUD<Actor>.IsExists(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

using Movie_website_dbfirst.Models;

namespace Movie_website_dbfirst.Services
{
    public interface ICRUD<T>
    {
        Task<List<T>> GetAll();
        T GetById(Guid? id);
        void Add(T t);
        bool Update(T t);
        bool Delete(Guid? id);
        bool IsExists(Guid id);
    }
}

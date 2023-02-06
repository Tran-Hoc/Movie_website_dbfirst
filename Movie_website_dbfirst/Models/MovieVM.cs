using Movie_website_dbfirst.Data;

namespace Movie_website_dbfirst.Models
{
    public class MovieVM
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public List<Genre> genres { get;} 

    }
}

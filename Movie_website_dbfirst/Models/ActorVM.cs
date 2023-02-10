using Microsoft.AspNetCore.Mvc.Rendering;
using Movie_website_dbfirst.Data;

namespace Movie_website_dbfirst.Models
{


    public class ActorVM
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public DateTime? DateOfBirht { get; set; }

        public byte? Gender { get; set; }

        public string gendesss { get; set; }
    }
}

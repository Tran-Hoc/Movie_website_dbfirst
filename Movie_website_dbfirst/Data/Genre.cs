using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Movie_website_dbfirst.Data;

[Table("Genre")]
public partial class Genre
{
    [Key]
    public int Id { get; set; }

    [StringLength(500)]
    public string? Name { get; set; }

    [InverseProperty("Genre")]
    public virtual ICollection<GenreOfMovie> GenreOfMovies { get; } = new List<GenreOfMovie>();
}

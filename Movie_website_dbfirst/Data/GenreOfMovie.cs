using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Movie_website_dbfirst.Data;

[Table("GenreOfMovie")]
public partial class GenreOfMovie
{
    [Key]
    public int Id { get; set; }

    public Guid MovieId { get; set; }

    public Guid GenreId { get; set; }

    [ForeignKey("GenreId")]
    [InverseProperty("GenreOfMovies")]
    public virtual Genre Genre { get; set; } = null!;

    [ForeignKey("MovieId")]
    [InverseProperty("GenreOfMovies")]
    public virtual Movie Movie { get; set; } = null!;
}

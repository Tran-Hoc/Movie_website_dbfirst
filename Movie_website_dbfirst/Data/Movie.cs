using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Movie_website_dbfirst.Data;

[Table("Movie")]
public partial class Movie
{
    [Key]
    public int Id { get; set; }

    public string? NameMovie { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReleaseDate { get; set; }

    public string? Title { get; set; }

    [Column("Avg_rating")]
    public double? AvgRating { get; set; }

    [InverseProperty("Movie")]
    public virtual ICollection<Acted> Acteds { get; } = new List<Acted>();

    [InverseProperty("Movie")]
    public virtual ICollection<Directed> Directeds { get; } = new List<Directed>();

    [InverseProperty("Movie")]
    public virtual ICollection<EpisodeOf> EpisodeOfs { get; } = new List<EpisodeOf>();

    [InverseProperty("Movie")]
    public virtual ICollection<GenreOfMovie> GenreOfMovies { get; } = new List<GenreOfMovie>();

    [InverseProperty("Movie")]
    public virtual ICollection<MonthlyRevenue> MonthlyRevenues { get; } = new List<MonthlyRevenue>();

    [InverseProperty("Movie")]
    public virtual ICollection<Produced> Produceds { get; } = new List<Produced>();

    [InverseProperty("Movie")]
    public virtual ICollection<Rate> Rates { get; } = new List<Rate>();
}

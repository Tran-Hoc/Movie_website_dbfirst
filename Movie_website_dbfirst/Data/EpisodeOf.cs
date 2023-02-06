using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Movie_website_dbfirst.Data;

[Table("EpisodeOf")]
public partial class EpisodeOf
{
    [Key]
    public int Id { get; set; }

    public int MovieId { get; set; }

    public int EpisodeId { get; set; }

    [Column("Num_ep")]
    public int? NumEp { get; set; }

    [ForeignKey("EpisodeId")]
    [InverseProperty("EpisodeOfs")]
    public virtual Episode Episode { get; set; } = null!;

    [ForeignKey("MovieId")]
    [InverseProperty("EpisodeOfs")]
    public virtual Movie Movie { get; set; } = null!;
}

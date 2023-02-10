using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Movie_website_dbfirst.Data;

[Table("Rate")]
public partial class Rate
{
    [Key]
    public int Id { get; set; }

    [Column("Num_rate")]
    public byte? NumRate { get; set; }

    [Column("verbal_rate")]
    public string? VerbalRate { get; set; }

    public Guid MovieId { get; set; }

    public Guid UserId { get; set; }

    [ForeignKey("MovieId")]
    [InverseProperty("Rates")]
    public virtual Movie Movie { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Rates")]
    public virtual AccUser User { get; set; } = null!;
}

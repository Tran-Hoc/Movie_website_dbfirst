using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Movie_website_dbfirst.Data;

[Table("Directed")]
public partial class Directed
{
    [Key]
    public int Id { get; set; }

    public int MovieId { get; set; }

    public int DirectorId { get; set; }

    [ForeignKey("DirectorId")]
    [InverseProperty("Directeds")]
    public virtual Director Director { get; set; } = null!;

    [ForeignKey("MovieId")]
    [InverseProperty("Directeds")]
    public virtual Movie Movie { get; set; } = null!;
}

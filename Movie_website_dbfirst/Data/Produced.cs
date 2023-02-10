using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Movie_website_dbfirst.Data;

[Table("Produced")]
public partial class Produced
{
    [Key]
    public int Id { get; set; }

    public Guid MovieId { get; set; }

    public Guid ProducerId { get; set; }

    [ForeignKey("MovieId")]
    [InverseProperty("Produceds")]
    public virtual Movie Movie { get; set; } = null!;

    [ForeignKey("ProducerId")]
    [InverseProperty("Produceds")]
    public virtual Producer Producer { get; set; } = null!;
}

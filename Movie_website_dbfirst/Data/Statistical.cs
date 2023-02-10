using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Movie_website_dbfirst.Data;

[Table("Statistical")]
public partial class Statistical
{
    [Key]
    public int Id { get; set; }

    public Guid? UserId { get; set; }

    public Guid? MovieId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeVisit { get; set; }

    public double? TimeView { get; set; }

    [ForeignKey("MovieId")]
    [InverseProperty("Statisticals")]
    public virtual Movie? Movie { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Statisticals")]
    public virtual AccUser? User { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Movie_website_dbfirst.Data;

[Table("Acted")]
public partial class Acted
{
    [Key]
    public int Id { get; set; }

    public byte? Roles { get; set; }

    public Guid MovieId { get; set; }

    public Guid ActorId { get; set; }

    [ForeignKey("ActorId")]
    [InverseProperty("Acteds")]
    public virtual Actor Actor { get; set; } = null!;

    [ForeignKey("MovieId")]
    [InverseProperty("Acteds")]
    public virtual Movie Movie { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Movie_website_dbfirst.Data;

[Table("Actor")]
public partial class Actor
{
    [Key]
    public int Id { get; set; }

    public int PersonId { get; set; }

    [InverseProperty("Actor")]
    public virtual ICollection<Acted> Acteds { get; } = new List<Acted>();

    [ForeignKey("PersonId")]
    [InverseProperty("Actors")]
    public virtual Person Person { get; set; } = null!;
}

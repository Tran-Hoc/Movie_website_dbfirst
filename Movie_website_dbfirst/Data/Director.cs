using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Movie_website_dbfirst.Data;

[Table("Director")]
public partial class Director
{
    [Key]
    public Guid Id { get; set; }

    public string? Name { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateOfBirht { get; set; }

    public byte? Gender { get; set; }

    [InverseProperty("Director")]
    public virtual ICollection<Directed> Directeds { get; } = new List<Directed>();
}

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
    public Guid Id { get; set; }

    public string? Name { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateOfBirht { get; set; }

    public byte? Gender { get; set; }

    [InverseProperty("Actor")]
    public virtual ICollection<Acted> Acteds { get; } = new List<Acted>();
}

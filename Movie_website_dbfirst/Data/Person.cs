using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Movie_website_dbfirst.Data;

[Table("Person")]
public partial class Person
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateOfBirht { get; set; }

    public byte? Gender { get; set; }

    [InverseProperty("Person")]
    public virtual ICollection<AccUser> AccUsers { get; } = new List<AccUser>();

    [InverseProperty("Person")]
    public virtual ICollection<Actor> Actors { get; } = new List<Actor>();

    [InverseProperty("Person")]
    public virtual ICollection<Director> Directors { get; } = new List<Director>();

    [InverseProperty("Person")]
    public virtual ICollection<Producer> Producers { get; } = new List<Producer>();
}

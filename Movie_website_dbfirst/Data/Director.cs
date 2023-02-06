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
    public int Id { get; set; }

    public int PersonId { get; set; }

    [InverseProperty("Director")]
    public virtual ICollection<Directed> Directeds { get; } = new List<Directed>();

    [ForeignKey("PersonId")]
    [InverseProperty("Directors")]
    public virtual Person Person { get; set; } = null!;
}

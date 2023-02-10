using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Movie_website_dbfirst.Data;

[Table("AccUser")]
public partial class AccUser
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(100)]
    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateOfBirht { get; set; }

    public byte? Gender { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Rate> Rates { get; } = new List<Rate>();

    [InverseProperty("User")]
    public virtual ICollection<Statistical> Statisticals { get; } = new List<Statistical>();
}

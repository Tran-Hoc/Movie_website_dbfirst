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
    public int Id { get; set; }

    [StringLength(100)]
    public string? UserName { get; set; }

    public string? Password { get; set; }

    public int PersonId { get; set; }

    [ForeignKey("PersonId")]
    [InverseProperty("AccUsers")]
    public virtual Person Person { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Rate> Rates { get; } = new List<Rate>();
}

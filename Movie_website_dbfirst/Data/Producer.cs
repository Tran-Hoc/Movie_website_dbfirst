using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Movie_website_dbfirst.Data;

[Table("Producer")]
public partial class Producer
{
    [Key]
    public Guid Id { get; set; }

    public string? Name { get; set; }

    [InverseProperty("Producer")]
    public virtual ICollection<Produced> Produceds { get; } = new List<Produced>();
}

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
    public int Id { get; set; }

    public int PersonId { get; set; }

    [ForeignKey("PersonId")]
    [InverseProperty("Producers")]
    public virtual Person Person { get; set; } = null!;

    [InverseProperty("Producer")]
    public virtual ICollection<Produced> Produceds { get; } = new List<Produced>();
}

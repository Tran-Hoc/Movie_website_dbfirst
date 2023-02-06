using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Movie_website_dbfirst.Data;

[Table("Episode")]
public partial class Episode
{
    [Key]
    public int Id { get; set; }

    public string? NameEp { get; set; }

    [InverseProperty("Episode")]
    public virtual ICollection<EpisodeOf> EpisodeOfs { get; } = new List<EpisodeOf>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Movie_website_dbfirst.Data;

[Table("Monthly_revenue")]
public partial class MonthlyRevenue
{
    [Key]
    public int Id { get; set; }

    [Column("income", TypeName = "money")]
    public decimal? Income { get; set; }

    [Column("arg_rating")]
    public double? ArgRating { get; set; }

    [Column("Time_year_month", TypeName = "datetime")]
    public DateTime? TimeYearMonth { get; set; }

    public int MovieId { get; set; }

    [ForeignKey("MovieId")]
    [InverseProperty("MonthlyRevenues")]
    public virtual Movie Movie { get; set; } = null!;
}

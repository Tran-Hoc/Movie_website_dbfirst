using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Movie_website_dbfirst.Data;

namespace Movie_website_dbfirst.DataContext;

public partial class MovieDbFirstContext : DbContext
{
    public MovieDbFirstContext()
    {
    }

    public MovieDbFirstContext(DbContextOptions<MovieDbFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccUser> AccUsers { get; set; }

    public virtual DbSet<Acted> Acteds { get; set; }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Directed> Directeds { get; set; }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Episode> Episodes { get; set; }

    public virtual DbSet<EpisodeOf> EpisodeOfs { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<GenreOfMovie> GenreOfMovies { get; set; }

    public virtual DbSet<MonthlyRevenue> MonthlyRevenues { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Produced> Produceds { get; set; }

    public virtual DbSet<Producer> Producers { get; set; }

    public virtual DbSet<Rate> Rates { get; set; }

    public virtual DbSet<Statistical> Statisticals { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-7MRL7G7\\SQLEXPRESS;Initial Catalog=Movie_DbFirst;Integrated Security=True; TrustServerCertificate=True; User ID=sa;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccUser__3214EC073F5BBA84");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Acted>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Acted__3214EC0787C8513E");

            entity.HasOne(d => d.Actor).WithMany(p => p.Acteds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Acted_Actor");

            entity.HasOne(d => d.Movie).WithMany(p => p.Acteds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Acted_Movie");
        });

        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Actor__3214EC07775FA4F9");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Directed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Directed__3214EC0765ECA2D4");

            entity.HasOne(d => d.Director).WithMany(p => p.Directeds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Directed_Director");

            entity.HasOne(d => d.Movie).WithMany(p => p.Directeds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Directed_Movie");
        });

        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Director__3214EC070A732799");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Episode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Episode__3214EC07DEF5DC32");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<EpisodeOf>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EpisodeO__3214EC07E8578D95");

            entity.HasOne(d => d.Episode).WithMany(p => p.EpisodeOfs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_EpisodeOf_Episode");

            entity.HasOne(d => d.Movie).WithMany(p => p.EpisodeOfs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_EpisodeOf_Movie");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genre__3214EC07B75F8C3E");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<GenreOfMovie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GenreOfM__3214EC07A4EA60EB");

            entity.HasOne(d => d.Genre).WithMany(p => p.GenreOfMovies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_GenreOf_Genre");

            entity.HasOne(d => d.Movie).WithMany(p => p.GenreOfMovies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_GenreOf_Movie");
        });

        modelBuilder.Entity<MonthlyRevenue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Monthly___3214EC07E129CC60");

            entity.HasOne(d => d.Movie).WithMany(p => p.MonthlyRevenues)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Monreve_Movie");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movie__3214EC078957F0AF");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Produced>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produced__3214EC0734439713");

            entity.HasOne(d => d.Movie).WithMany(p => p.Produceds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Produced_Movie");

            entity.HasOne(d => d.Producer).WithMany(p => p.Produceds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Produced_Producer");
        });

        modelBuilder.Entity<Producer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producer__3214EC07A29C23EE");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Rate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rate__3214EC07791F5D52");

            entity.HasOne(d => d.Movie).WithMany(p => p.Rates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Rate_Movieforeign");

            entity.HasOne(d => d.User).WithMany(p => p.Rates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Rate_AccUser");
        });

        modelBuilder.Entity<Statistical>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Statisti__3214EC07E59E0D9E");

            entity.HasOne(d => d.Movie).WithMany(p => p.Statisticals).HasConstraintName("Fk_Statistical_Movie");

            entity.HasOne(d => d.User).WithMany(p => p.Statisticals).HasConstraintName("Fk_Statistical_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

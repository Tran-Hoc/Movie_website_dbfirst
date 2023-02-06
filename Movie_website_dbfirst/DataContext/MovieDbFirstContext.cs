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

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Produced> Produceds { get; set; }

    public virtual DbSet<Producer> Producers { get; set; }

    public virtual DbSet<Rate> Rates { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-7MRL7G7\\SQLEXPRESS;Initial Catalog=Movie_DbFirst;Integrated Security=True; TrustServerCertificate=True; User ID=sa;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccUser__3214EC07FCEE7B4B");

            entity.HasOne(d => d.Person).WithMany(p => p.AccUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_AccUser_Person");
        });

        modelBuilder.Entity<Acted>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Acted__3214EC0722DC9E3E");

            entity.HasOne(d => d.Actor).WithMany(p => p.Acteds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Acted_Actor");

            entity.HasOne(d => d.Movie).WithMany(p => p.Acteds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Acted_Movie");
        });

        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Actor__3214EC0783AF267F");

            entity.HasOne(d => d.Person).WithMany(p => p.Actors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Actor_Person");
        });

        modelBuilder.Entity<Directed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Directed__3214EC07A318D59C");

            entity.HasOne(d => d.Director).WithMany(p => p.Directeds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Directed_Director");

            entity.HasOne(d => d.Movie).WithMany(p => p.Directeds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Directed_Movie");
        });

        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Director__3214EC0794DD3B27");

            entity.HasOne(d => d.Person).WithMany(p => p.Directors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Director_Person");
        });

        modelBuilder.Entity<Episode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Episode__3214EC07BCD28D98");
        });

        modelBuilder.Entity<EpisodeOf>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EpisodeO__3214EC07AD93FD88");

            entity.HasOne(d => d.Episode).WithMany(p => p.EpisodeOfs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_EpisodeOf_Episode");

            entity.HasOne(d => d.Movie).WithMany(p => p.EpisodeOfs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_EpisodeOf_Movie");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genre__3214EC073E918B1F");
        });

        modelBuilder.Entity<GenreOfMovie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GenreOfM__3214EC07FE74CD8C");

            entity.HasOne(d => d.Genre).WithMany(p => p.GenreOfMovies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_GenreOf_Genre");

            entity.HasOne(d => d.Movie).WithMany(p => p.GenreOfMovies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_GenreOf_Movie");
        });

        modelBuilder.Entity<MonthlyRevenue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Monthly___3214EC074F8490AC");

            entity.HasOne(d => d.Movie).WithMany(p => p.MonthlyRevenues)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Monreve_Movie");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movie__3214EC0728BB59B0");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Person__3214EC0715D88644");
        });

        modelBuilder.Entity<Produced>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produced__3214EC07BB4CE628");

            entity.HasOne(d => d.Movie).WithMany(p => p.Produceds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Produced_Movie");

            entity.HasOne(d => d.Producer).WithMany(p => p.Produceds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Produced_Producer");
        });

        modelBuilder.Entity<Producer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producer__3214EC07AE2A9EFB");

            entity.HasOne(d => d.Person).WithMany(p => p.Producers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Producer_Person");
        });

        modelBuilder.Entity<Rate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rate__3214EC074FB6B88A");

            entity.HasOne(d => d.Movie).WithMany(p => p.Rates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Rate_Movieforeign");

            entity.HasOne(d => d.User).WithMany(p => p.Rates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Rate_AccUser");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

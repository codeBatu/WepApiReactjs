using System;
using BookStoreEntites.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookOperaions.BookContext
{
    public partial class bookContext : DbContext
    {
        public bookContext()
        {
        }

        public bookContext(DbContextOptions<bookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Books> Booktables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
     optionsBuilder.UseSqlServer("Server=.;Database=book;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Books>(entity =>
            {
                entity.ToTable("booktable");

                entity.Property(e => e.PublicDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Title).HasMaxLength(128);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

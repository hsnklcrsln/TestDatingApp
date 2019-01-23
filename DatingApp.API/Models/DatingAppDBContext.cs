using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatingApp.API.Models
{
    public partial class DatingAppDBContext : DbContext
    {
        public DatingAppDBContext()
        {
        }

        public DatingAppDBContext(DbContextOptions<DatingAppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Values> Values { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB; Database=DatingAppDB; Trusted_Connection=True; MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Photo)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Photo_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(10);

                entity.Property(e => e.Country).HasMaxLength(10);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.Interests).HasMaxLength(10);

                entity.Property(e => e.KnownAs).HasMaxLength(10);

                entity.Property(e => e.LastActiveDate).HasColumnType("datetime");

                entity.Property(e => e.LookingFor).HasMaxLength(10);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Values>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(10);
            });
        }
    }
}

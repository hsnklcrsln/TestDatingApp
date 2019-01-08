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
            modelBuilder.Entity<User>(entity =>
            {
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

using System;
using APIMares.Authentication;
//using MaresAPI.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MaresAPI.Models
{
    public class MaresAPIContext : IdentityDbContext<ApplicationUser> {

        public MaresAPIContext(DbContextOptions<MaresAPIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


        public virtual DbSet<Beach> Beaches { get; set; }
        public virtual DbSet<County> Counties { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Tide> Tides { get; set; }
    }
}

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MaresAPI;Trusted_Connection=True;");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

//            modelBuilder.Entity<Beach>(entity =>
//            {
//                entity.ToTable("Beach");

//                entity.Property(e => e.Id).ValueGeneratedNever();

//                entity.Property(e => e.BeachName)
//                    .IsRequired()
//                    .HasMaxLength(255)
//                    .IsUnicode(false)
//                    .HasColumnName("Beach_Name");

//                entity.Property(e => e.CountyId).HasColumnName("County_Id");

//                entity.HasOne(d => d.County)
//                    .WithMany(p => p.Beaches)
//                    .HasForeignKey(d => d.CountyId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK__Beach__County_Id__2F10007B");
//            });

//            modelBuilder.Entity<County>(entity =>
//            {
//                entity.ToTable("County");

//                entity.Property(e => e.Id).ValueGeneratedNever();

//                entity.Property(e => e.CountyName)
//                    .IsRequired()
//                    .HasMaxLength(255)
//                    .IsUnicode(false)
//                    .HasColumnName("County_Name");

//                entity.Property(e => e.LocationId).HasColumnName("Location_Id");

//                entity.HasOne(d => d.Location)
//                    .WithMany(p => p.Counties)
//                    .HasForeignKey(d => d.LocationId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK__County__Location__2C3393D0");
//            });

//            modelBuilder.Entity<Location>(entity =>
//            {
//                entity.ToTable("Location");

//                entity.Property(e => e.Id).ValueGeneratedNever();

//                entity.Property(e => e.Description)
//                    .IsRequired()
//                    .HasMaxLength(255)
//                    .IsUnicode(false);

//                entity.Property(e => e.Location1)
//                    .IsRequired()
//                    .HasMaxLength(255)
//                    .IsUnicode(false)
//                    .HasColumnName("Location");

//                entity.Property(e => e.Name)
//                    .IsRequired()
//                    .HasMaxLength(255)
//                    .IsUnicode(false);
//            });

//            modelBuilder.Entity<Tide>(entity =>
//            {
//                entity.Property(e => e.Id).ValueGeneratedNever();

//                entity.Property(e => e.BeachId).HasColumnName("Beach_Id");

//                entity.Property(e => e.Day).HasColumnType("date");

//                entity.Property(e => e.Height).HasColumnType("decimal(10, 3)");

//                entity.Property(e => e.TideType)
//                    .IsRequired()
//                    .HasMaxLength(255)
//                    .IsUnicode(false)
//                    .HasColumnName("Tide_Type");

//                entity.Property(e => e.Time)
//                    .IsRequired()
//                    .IsRowVersion()
//                    .IsConcurrencyToken();

//                entity.HasOne(d => d.Beach)
//                    .WithMany(p => p.Tides)
//                    .HasForeignKey(d => d.BeachId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK__Tides__Beach_Id__31EC6D26");
//            });

//            modelBuilder.Entity<UserApi>(entity =>
//            {
//                entity.ToTable("User_API");

//                entity.Property(e => e.Id).ValueGeneratedNever();

//                entity.Property(e => e.CreatedAt)
//                    .HasColumnType("datetime")
//                    .HasColumnName("Created_At");

//                entity.Property(e => e.Email)
//                    .IsRequired()
//                    .HasMaxLength(255)
//                    .IsUnicode(false);

//                entity.Property(e => e.Name)
//                    .IsRequired()
//                    .HasMaxLength(255)
//                    .IsUnicode(false);

//                entity.Property(e => e.Password)
//                    .IsRequired()
//                    .HasMaxLength(255)
//                    .IsUnicode(false);
//            });

//            modelBuilder.Entity<UserRole>(entity =>
//            {
//                entity.ToTable("User_Role");

//                entity.Property(e => e.Id).ValueGeneratedNever();

//                entity.Property(e => e.CreatedAt)
//                    .HasColumnType("datetime")
//                    .HasColumnName("Created_At");

//                entity.Property(e => e.Name)
//                    .IsRequired()
//                    .HasMaxLength(255)
//                    .IsUnicode(false);

//                entity.Property(e => e.Role)
//                    .IsRequired()
//                    .HasMaxLength(255)
//                    .IsUnicode(false);

//                entity.Property(e => e.UserId).HasColumnName("User_Id");

//                entity.HasOne(d => d.User)
//                    .WithMany(p => p.UserRoles)
//                    .HasForeignKey(d => d.UserId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK__User_Role__User___276EDEB3");
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}

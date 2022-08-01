using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CabBookingSystem.Models
{
    public partial class CabBookingContext : DbContext
    {
        public CabBookingContext()
        {
        }

        public CabBookingContext(DbContextOptions<CabBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Cab> Cab { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Distance> Distance { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<Location> Location { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=USHYDMALSOWMYA8\\SQLEXPRESS;Database=CabBooking;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Admin__536C85E5110EFF44");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Bookingid).ValueGeneratedNever();

                entity.Property(e => e.Cabid)
                    .HasColumnName("cabid")
                    .HasMaxLength(23)
                    .IsUnicode(false);

                entity.Property(e => e.Fare).HasColumnName("fare");

                entity.Property(e => e.Mobileno).HasColumnName("mobileno");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TotalFare).HasColumnType("money");

                entity.HasOne(d => d.Cab)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.Cabid)
                    .HasConstraintName("FK__Booking__cabid__1ED998B2");

                entity.HasOne(d => d.Distance)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.DistanceId)
                    .HasConstraintName("FK__Booking__Distanc__1FCDBCEB");

                entity.HasOne(d => d.MobilenoNavigation)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.Mobileno)
                    .HasConstraintName("FK__Booking__mobilen__1DE57479");
            });

            modelBuilder.Entity<Cab>(entity =>
            {
                entity.HasKey(e => e.CabId)
                    .HasName("PK__Cab__66AC416D84BEC9CD");

                entity.Property(e => e.CabId)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasComputedColumnSql("('C00'+CONVERT([varchar](20),[Id]))");

                entity.Property(e => e.Cabname)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cabtype)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fareperkm).HasColumnName("fareperkm");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.CurrentLocationNavigation)
                    .WithMany(p => p.Cab)
                    .HasForeignKey(d => d.CurrentLocation)
                    .HasConstraintName("FK__Cab__CurrentLoca__164452B1");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Mobile)
                    .HasName("PK__Customer__6FAE0783999F6589");

                entity.Property(e => e.Mobile).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Distance>(entity =>
            {
                entity.HasOne(d => d.FromLocationNavigation)
                    .WithMany(p => p.DistanceFromLocationNavigation)
                    .HasForeignKey(d => d.FromLocation)
                    .HasConstraintName("FK__Distance__FromLo__1273C1CD");

                entity.HasOne(d => d.ToLocationNavigation)
                    .WithMany(p => p.DistanceToLocationNavigation)
                    .HasForeignKey(d => d.ToLocation)
                    .HasConstraintName("FK__Distance__ToLoca__1367E606");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasKey(e => e.Mobile)
                    .HasName("PK__Driver__A32E2E1D944530E1");

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cabid)
                    .HasColumnName("cabid")
                    .HasMaxLength(23)
                    .IsUnicode(false);

                entity.Property(e => e.Licenseno)
                    .HasColumnName("licenseno")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cab)
                    .WithMany(p => p.Driver)
                    .HasForeignKey(d => d.Cabid)
                    .HasConstraintName("FK__Driver__cabid__1B0907CE");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

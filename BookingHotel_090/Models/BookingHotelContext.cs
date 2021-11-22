using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookingHotel_090.Models
{
    public partial class BookingHotelContext : DbContext
    {
        public BookingHotelContext()
        {
        }

        public BookingHotelContext(DbContextOptions<BookingHotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Petuga> Petugas { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Transaksi> Transaksis { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.ToTable("Customer");

                entity.Property(e => e.IdCustomer)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Customer");

                entity.Property(e => e.JenisKelamin)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Jenis_Kelamin");

                entity.Property(e => e.NamaCustomer)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Customer");

                entity.Property(e => e.NoHp)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("No_Hp");
            });

            modelBuilder.Entity<Petuga>(entity =>
            {
                entity.HasKey(e => e.IdPetugas);

                entity.Property(e => e.IdPetugas)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Petugas");

                entity.Property(e => e.NamaPetugas)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Petugas");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.IdRoom);

                entity.ToTable("Room");

                entity.Property(e => e.IdRoom)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Room");

                entity.Property(e => e.NamaRoom)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Room");

                entity.Property(e => e.TypeRoom)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Type_Room");
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi)
                    .HasName("PK_Transaksi_1");

                entity.ToTable("Transaksi");

                entity.Property(e => e.IdTransaksi)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Transaksi");

                entity.Property(e => e.IdCustomer).HasColumnName("Id_Customer");

                entity.Property(e => e.IdPetugas).HasColumnName("Id_Petugas");

                entity.Property(e => e.IdRoom).HasColumnName("Id_Room");

                entity.Property(e => e.TotalTransaksi)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Total_Transaksi");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaksi_Customer");

                entity.HasOne(d => d.IdPetugasNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdPetugas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaksi_Petugas");

                entity.HasOne(d => d.IdRoomNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdRoom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaksi_Room");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

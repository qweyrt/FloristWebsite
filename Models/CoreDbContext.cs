using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FloristWebsite.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bouquets> Bouquets { get; set; }
        public virtual DbSet<BouquetsMessages> BouquetsMessages { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Recipients> Recipients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ADMIN\\SQLEXPRESS;Database=FLORIST;User id=sa;Password=123456789;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bouquets>(entity =>
            {
                entity.ToTable("BOUQUETS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BouquetMessageId).HasColumnName("BOUQUET_MESSAGE_ID");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(250);

                entity.Property(e => e.Price).HasColumnName("PRICE");

                entity.Property(e => e.RecipientId).HasColumnName("RECIPIENT_ID");

                entity.HasOne(d => d.BouquetMessage)
                    .WithMany(p => p.Bouquets)
                    .HasForeignKey(d => d.BouquetMessageId)
                    .HasConstraintName("FK__BOUQUETS__BOUQUE__182C9B23");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bouquets)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__BOUQUETS__CUSTOM__164452B1");

                entity.HasOne(d => d.Recipient)
                    .WithMany(p => p.Bouquets)
                    .HasForeignKey(d => d.RecipientId)
                    .HasConstraintName("FK__BOUQUETS__RECIPI__173876EA");
            });

            modelBuilder.Entity<BouquetsMessages>(entity =>
            {
                entity.ToTable("BOUQUETS_MESSAGES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Message)
                    .HasColumnName("MESSAGE")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("CUSTOMERS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(4000);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("DATE_OF_BIRTH")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(250);

                entity.Property(e => e.Gender)
                    .HasColumnName("GENDER")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(250);

                entity.Property(e => e.PhoneNumber).HasColumnName("PHONE_NUMBER");
            });

            modelBuilder.Entity<Recipients>(entity =>
            {
                entity.ToTable("RECIPIENTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(4000);

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(250);

                entity.Property(e => e.PhoneNumber).HasColumnName("PHONE_NUMBER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

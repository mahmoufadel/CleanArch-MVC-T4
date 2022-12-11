using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Entities;

namespace Persistence.Context
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<AddressStatus> AddressStatuses { get; set; } = null!;
        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookLanguage> BookLanguages { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<CustOrder> CustOrders { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; } = null!;
        public virtual DbSet<OrderHistory> OrderHistories { get; set; } = null!;
        public virtual DbSet<OrderLine> OrderLines { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<Publisher> Publishers { get; set; } = null!;
        public virtual DbSet<ShippingMethod> ShippingMethods { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=SqlServerDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId).ValueGeneratedNever();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("fk_addr_ctry");
            });

            modelBuilder.Entity<AddressStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("pk_addr_status");

                entity.Property(e => e.StatusId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.AuthorId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookId).ValueGeneratedNever();

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("fk_book_lang");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublisherId)
                    .HasConstraintName("fk_book_pub");

                entity.HasMany(d => d.Authors)
                    .WithMany(p => p.Books)
                    .UsingEntity<Dictionary<string, object>>(
                        "BookAuthor",
                        l => l.HasOne<Author>().WithMany().HasForeignKey("AuthorId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_ba_author"),
                        r => r.HasOne<Book>().WithMany().HasForeignKey("BookId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_ba_book"),
                        j =>
                        {
                            j.HasKey("BookId", "AuthorId").HasName("pk_bookauthor");

                            j.ToTable("book_author");

                            j.IndexerProperty<int>("BookId").HasColumnName("book_id");

                            j.IndexerProperty<int>("AuthorId").HasColumnName("author_id");
                        });
            });

            modelBuilder.Entity<BookLanguage>(entity =>
            {
                entity.HasKey(e => e.LanguageId)
                    .HasName("pk_language");

                entity.Property(e => e.LanguageId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId).ValueGeneratedNever();
            });

            modelBuilder.Entity<CustOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("pk_custorder");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_order_cust");

                entity.HasOne(d => d.DestAddress)
                    .WithMany(p => p.CustOrders)
                    .HasForeignKey(d => d.DestAddressId)
                    .HasConstraintName("fk_order_addr");

                entity.HasOne(d => d.ShippingMethod)
                    .WithMany(p => p.CustOrders)
                    .HasForeignKey(d => d.ShippingMethodId)
                    .HasConstraintName("fk_order_ship");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).ValueGeneratedNever();
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.AddressId })
                    .HasName("pk_custaddr");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ca_addr");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ca_cust");
            });

            modelBuilder.Entity<OrderHistory>(entity =>
            {
                entity.HasKey(e => e.HistoryId)
                    .HasName("pk_orderhist");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderHistories)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("fk_oh_order");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.OrderHistories)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_oh_status");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasKey(e => e.LineId)
                    .HasName("pk_orderline");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("fk_ol_book");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("fk_ol_order");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("pk_orderstatus");

                entity.Property(e => e.StatusId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.Property(e => e.PublisherId).ValueGeneratedNever();
            });

            modelBuilder.Entity<ShippingMethod>(entity =>
            {
                entity.HasKey(e => e.MethodId)
                    .HasName("pk_shipmethod");

                entity.Property(e => e.MethodId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

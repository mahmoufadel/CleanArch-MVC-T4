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

        public virtual DbSet<CollectionType> CollectionTypes { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Expense> Expenses { get; set; } = null!;
        public virtual DbSet<ExpenseAssignee> ExpenseAssignees { get; set; } = null!;
        public virtual DbSet<ExpenseSubtype> ExpenseSubtypes { get; set; } = null!;
        public virtual DbSet<ExpenseType> ExpenseTypes { get; set; } = null!;
        public virtual DbSet<Valuetype> Valuetypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.; Database=RIS.FinancialInvestment; User Id=sa;Password=yourStrong(!)Password;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CollectionType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.HasOne(d => d.CollectiontypeLkp)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.CollectiontypeLkpId)
                    .HasConstraintName("fk_CollectionType_lkp_id");

                entity.HasOne(d => d.CountryLkp)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.CountryLkpId)
                    .HasConstraintName("fk_country_lkp_id");
            });

            modelBuilder.Entity<ExpenseSubtype>(entity =>
            {
                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.ExpenseSubtypes)
                    .HasForeignKey(d => d.ExpenseId)
                    .HasConstraintName("fk_expense_id");

                entity.HasOne(d => d.ValuetypeLkp)
                    .WithMany(p => p.ExpenseSubtypes)
                    .HasForeignKey(d => d.ValuetypeLkpId)
                    .HasConstraintName("fk_valuetype_lkp_id");
            });

            modelBuilder.Entity<ExpenseType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Valuetype>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

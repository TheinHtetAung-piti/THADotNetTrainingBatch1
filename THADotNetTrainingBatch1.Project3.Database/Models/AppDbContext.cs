using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace THADotNetTrainingBatch1.Project3.Database.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblTranscation> TblTranscations { get; set; }

    public virtual DbSet<TblWallet> TblWallets { get; set; }

    public virtual DbSet<TblWalletHistory> TblWalletHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=MiniWallet;User Id=sa;Password=sa@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblTranscation>(entity =>
        {
            entity.HasKey(e => e.TranscationId);

            entity.ToTable("Tbl_Transcation");

            entity.Property(e => e.TranscationId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Amount).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.FromMobileNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ToMobileNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TranscationNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TransctationDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblWallet>(entity =>
        {
            entity.HasKey(e => e.WalletId);

            entity.ToTable("Tbl_Wallet");

            entity.Property(e => e.Balance).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WalletUserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblWalletHistory>(entity =>
        {
            entity.HasKey(e => e.WalletHistroyId);

            entity.ToTable("Tbl_WalletHistory");

            entity.Property(e => e.Amount).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TranscationType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace THADotNetTrainingBatch1.Assi.Database.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBlog> TblBlogs { get; set; }

    public virtual DbSet<TblBlogDetail> TblBlogDetails { get; set; }

    public virtual DbSet<TblBlogHeader> TblBlogHeaders { get; set; }

    public virtual DbSet<TblCategory> TblCategories { get; set; }

    public virtual DbSet<TblHomework> TblHomeworks { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("Tbl_Blog");

            entity.Property(e => e.BlogAuthor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BlogContent)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BlogTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblBlogDetail>(entity =>
        {
            entity.HasKey(e => e.BlogDetailId);

            entity.ToTable("Tbl_BlogDetail");

            entity.Property(e => e.BlogContent)
                .HasMaxLength(500)
                .IsFixedLength();
        });

        modelBuilder.Entity<TblBlogHeader>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("Tbl_BlogHeader");

            entity.Property(e => e.BlogTitle)
                .HasMaxLength(150)
                .IsFixedLength();
        });

        modelBuilder.Entity<TblCategory>(entity =>
        {
            entity.ToTable("Tbl_Category");

            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.CategoryCode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblHomework>(entity =>
        {
            entity.HasKey(e => e.No);

            entity.ToTable("Tbl_Homework");

            entity.Property(e => e.GitHubRepoLink)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.GitHubUserName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("Tbl_Product");

            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDateTime).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.ToTable("Tbl_user");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

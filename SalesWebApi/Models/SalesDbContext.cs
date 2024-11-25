using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SalesWebApi.Models;

public partial class SalesDbContext : DbContext
{
    public SalesDbContext()
    {
    }

    public SalesDbContext(DbContextOptions<SalesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Sale> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=EE043\\SQLEXPRESS;User Id=sa;Password=Kdoddy_285;Database=SalesDB;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sale>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Months)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

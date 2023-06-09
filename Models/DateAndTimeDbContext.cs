using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dateandtime.Models;

public partial class DateAndTimeDbContext : DbContext
{
    public DateAndTimeDbContext()
    {
    }

    public DateAndTimeDbContext(DbContextOptions<DateAndTimeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DateTable> DateTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DateTimeConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DateTable>(entity =>
        {
            entity.ToTable("dateTable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstDate).IsUnicode(false);
            entity.Property(e => e.SecondDate).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

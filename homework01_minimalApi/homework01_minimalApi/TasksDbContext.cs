using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace homework01_minimalApi;

public partial class TasksDbContext : DbContext
{
    public TasksDbContext()
    {
    }

    public TasksDbContext(DbContextOptions<TasksDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ToDoTask> ToDoTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDoTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ToDoTask__3213E83FDB7A417C");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Due).HasColumnName("due");
            entity.Property(e => e.IsDone).HasColumnName("isDone");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

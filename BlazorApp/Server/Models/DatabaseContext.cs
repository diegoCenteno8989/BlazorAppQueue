using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Models
{
    //public partial class DatabaseContext:DbContext
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<User> Users { get; set; } = null!;
        public DbSet<Persona> Persona { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>(entity =>
        //    {
        //        entity.ToTable("userdetails");
        //        entity.Property(e => e.Userid).HasColumnName("Userid");
        //        entity.Property(e => e.Username)
        //            .HasMaxLength(100)
        //            .IsUnicode(false);
        //        entity.Property(e => e.Address)
        //            .HasMaxLength(500)
        //            .IsUnicode(false);
        //        entity.Property(e => e.Cellnumber)
        //            .HasMaxLength(50)
        //            .IsUnicode(false);
        //        entity.Property(e => e.Emailid)
        //            .HasMaxLength(50)
        //            .IsUnicode(false);
        //    });
        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

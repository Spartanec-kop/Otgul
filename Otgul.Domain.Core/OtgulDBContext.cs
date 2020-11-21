using Microsoft.EntityFrameworkCore;
using Otgul.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.DataBase
{
    public class OtgulDBContext : DbContext
    {
        public OtgulDBContext(DbContextOptions<OtgulDBContext> options)
            : base(options)
        {
        }
        public DbSet<Otdel> Otdel { get; set; }
        public DbSet<Guide> Guide { get; set; }
        public DbSet<Department> Department { get; set; }
        
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentGroup>()
                .HasKey(t => new { t.StudentId, t.GroupId });

            modelBuilder.Entity<StudentGroup>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentGroups)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentGroup>()
                .HasOne(sc => sc.Group)
                .WithMany(c => c.StudentGroups)
                .HasForeignKey(sc => sc.GroupId);
        }*/
    }
}

using Microsoft.EntityFrameworkCore;
using Otgul.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.DataBase.Repository
{
    public class OtgulDBContext : DbContext
    {
        public OtgulDBContext(DbContextOptions<OtgulDBContext> options)
            : base(options)
        {
        }
        public DbSet<Otdel> Otdels { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<OtgulRecord> Otgul { get; set; }
        public DbSet<Right> Rights { get; set; }
        public DbSet<RoleRights> RoleRights { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRights> UserRights { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserRights>()
               .HasKey(t => new { t.RightId, t.UserId });

            modelBuilder.Entity<UserRights>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.UserRights)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<UserRights>()
                .HasOne(sc => sc.Right)
                .WithMany(c => c.UserRights)
                .HasForeignKey(sc => sc.RightId);


            modelBuilder.Entity<RoleRights>()
               .HasKey(t => new { t.RightId, t.RoleId });

            modelBuilder.Entity<RoleRights>()
                .HasOne(sc => sc.Right)
                .WithMany(s => s.RoleRights)
                .HasForeignKey(sc => sc.RightId);

            modelBuilder.Entity<RoleRights>()
                .HasOne(sc => sc.Role)
                .WithMany(c => c.RoleRights)
                .HasForeignKey(sc => sc.RoleId);
        }
    }
}

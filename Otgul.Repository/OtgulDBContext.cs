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
        public DbSet<OtgulRecord> OtgulRecords { get; set; }
        public DbSet<Right> Rights { get; set; }
        public DbSet<RoleRight> RoleRights { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRight> UserRights { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserRight>()
               .HasKey(t => new { t.RightId, t.UserId });

            modelBuilder.Entity<UserRight>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.UserRights)
                .HasForeignKey(sc => sc.UserId);
            /* убрал обравтные ссылки, посмотрим что получится
            modelBuilder.Entity<UserRights>()
                .HasOne(sc => sc.Right)
                .WithMany(c => c.UserRights)
                .HasForeignKey(sc => sc.RightId);

            */
            modelBuilder.Entity<RoleRight>()
               .HasKey(t => new { t.RightId, t.RoleId });
            /* убрал обравтные ссылки, посмотрим что получится
            modelBuilder.Entity<RoleRights>()
                .HasOne(sc => sc.Right)
                .WithMany(s => s.RoleRights)
                .HasForeignKey(sc => sc.RightId);
            */
            modelBuilder.Entity<RoleRight>()
                .HasOne(sc => sc.Role)
                .WithMany(c => c.RoleRights)
                .HasForeignKey(sc => sc.RoleId);
        }
    }
}

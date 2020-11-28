using Microsoft.EntityFrameworkCore;
using Otguls.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otguls.DataBase
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
        public DbSet<Models.Otgul> Otguls { get; set; }
        public DbSet<Right> Rights { get; set; }
        public DbSet<RightRole> RightRole { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRights> UserRights { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserRights>()
               .HasKey(t => new { t.RightsId, t.UserId });

            modelBuilder.Entity<UserRights>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.UserRights)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<UserRights>()
                .HasOne(sc => sc.Right)
                .WithMany(c => c.UserRights)
                .HasForeignKey(sc => sc.RightsId);


            modelBuilder.Entity<RightRole>()
               .HasKey(t => new { t.RightId, t.RoleId });

            modelBuilder.Entity<RightRole>()
                .HasOne(sc => sc.Rights)
                .WithMany(s => s.RightRoles)
                .HasForeignKey(sc => sc.RightId);

            modelBuilder.Entity<RightRole>()
                .HasOne(sc => sc.Roles)
                .WithMany(c => c.RightRoles)
                .HasForeignKey(sc => sc.RoleId);
        }
    }
}

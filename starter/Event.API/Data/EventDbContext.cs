using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.API.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Event.API.Data
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<WorkShop> WorkShops { get; set; }
        public DbSet<EventUser> EventUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<WorkshopUser>().HasKey(t => new { t.WorkshopId, t.EventUserId });

            builder.Entity<WorkshopUser>()
                .HasOne(w => w.WorkShop)
                .WithMany(wu => wu.WorkshopUsers)
                .HasForeignKey(w => w.WorkshopId);

            builder.Entity<WorkshopUser>()
                .HasOne(u => u.EventUser)
                .WithMany(wu => wu.WorkshopUsers)
                .HasForeignKey(pt => pt.EventUserId);

            base.OnModelCreating(builder);
        }
    }
}

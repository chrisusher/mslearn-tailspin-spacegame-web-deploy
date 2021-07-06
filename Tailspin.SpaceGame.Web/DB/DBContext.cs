using System;
using Microsoft.EntityFrameworkCore;
using TailSpin.SpaceGame.Web.Models;

namespace TailSpin.SpaceGame.Web.DB
{
    public class TailspinContext : DbContext
    {
        public TailspinContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Profile>()
                        .Property(e => e.Achievements)
                        .HasConversion(
                            v => string.Join(',', v),
                            v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
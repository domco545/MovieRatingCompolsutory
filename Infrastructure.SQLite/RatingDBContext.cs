using Microsoft.EntityFrameworkCore;
using MovieRatingCompolsutory.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.SQLite
{
    public class RatingDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var rootPath = System.IO.Directory.GetParent(@"../../../../").FullName;
            var dbPath = rootPath + @"\ratings.db";
            optionsBuilder.UseSqlite($@"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>()
                .HasKey(o => new { o.Reviewer, o.Movie });
        }
        public DbSet<Rating> Ratings { get; set; }
    }
}

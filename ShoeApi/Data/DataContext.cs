using AuthApi.Entities;
using AuthApi.Models;
using Microsoft.EntityFrameworkCore;
using ShoeApi.Entities;
using System.Collections.Generic;

namespace ShoeApi.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<ShoeDetail> ShoeDetails { get; set; }
        public DbSet<ShoeReview> ShoeReviews { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TransShoeCategory> TransShoeCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shoe>()
                .HasOne(s => s.ShoeDetails)
                .WithOne(d => d.Shoe)
                .HasForeignKey<ShoeDetail>(d => d.Id);

            modelBuilder.Entity<Shoe>()
                .HasMany(s => s.Reviews)
                .WithOne(u => u.Shoe)
                .HasForeignKey(u => u.ShoeId);

            modelBuilder.Entity<TransShoeCategory>()
                .HasKey(sk => new { sk.ShoeId, sk.CategoryId });

            modelBuilder.Entity<TransShoeCategory>()
                .HasOne(sk => sk.Shoe)
                .WithMany(s => s.TransShoeCategories)
                .HasForeignKey(sk => sk.ShoeId);

            modelBuilder.Entity<TransShoeCategory>()
                .HasOne(sk => sk.Category)
                .WithMany(k => k.TransShoeCategories)
                .HasForeignKey(sk => sk.CategoryId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("ShoeApiDatabase"));
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using royuie.Models;

namespace royuie.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Always call base.OnModelCreating(modelBuilder) when using IdentityDbContext
            base.OnModelCreating(modelBuilder);

            // Ensure usernames are unique
            modelBuilder.Entity<ApplicationUser>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "New & Featured" },
                new Category { Id = 2, Name = "Accessories" },
                new Category { Id = 3, Name = "Clothing" },
                new Category { Id = 4, Name = "Sales" }
            );

            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory { Id = 1, Name = "Trending", CategoryId = 1 },
                new SubCategory { Id = 2, Name = "New Arrivals", CategoryId = 1 },
                new SubCategory { Id = 3, Name = "Best Sellers", CategoryId = 1 },
                new SubCategory { Id = 4, Name = "Necklaces", CategoryId = 2 },
                new SubCategory { Id = 5, Name = "Earrings", CategoryId = 2 },
                new SubCategory { Id = 6, Name = "Bracelets", CategoryId = 2 },
                new SubCategory { Id = 7, Name = "Tops", CategoryId = 3 },
                new SubCategory { Id = 8, Name = "Bottoms", CategoryId = 3 },
                new SubCategory { Id = 9, Name = "Dress", CategoryId = 3 },
                new SubCategory { Id = 10, Name = "Limited Time Offers", CategoryId = 4 }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Y2K Tank Top",
                    Description = "Trendy girlies caught in 2K.",
                    Price = 25,
                    ImagePath = "Tank1.jpg",
                    SubCategoryId = 7
                },
                new Product
                {
                    Id = 2,
                    Name = "Cutie Pookie",
                    Description = "Cute cropped tank in soft cotton.",
                    Price = 25,
                    ImagePath = "Tank2.jpg",
                    SubCategoryId = 7
                },
                new Product
                {
                    Id = 3,
                    Name = "Summer Sun",
                    Description = "Bright tank top perfect for the beach girlies.",
                    Price = 25,
                    ImagePath = "Tank4.jpg",
                    SubCategoryId = 7
                }
            );
        }
    }
}